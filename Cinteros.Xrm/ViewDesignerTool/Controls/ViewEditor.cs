namespace Cinteros.Xrm.ViewDesignerTool.Controls
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using Cinteros.Xrm.ViewDesignerTool.AppCode;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Query;
    using XrmToolBox.Extensibility;

    public partial class ViewEditor : UserControl
    {
        private PluginControlBase host;

        public ViewEditor()
        {
            InitializeComponent();
        }

        private void ViewEditor_Load(object sender, EventArgs e)
        {
            this.host = (PluginControlBase)this.Parent;

            host.WorkAsync("Getting list of entities",
                a =>
                {
                    var query = new QueryExpression("savedquery");
                    query.Distinct = true;

                    query.ColumnSet.AddColumns("returnedtypecode");

                    a.Result = host.Service.RetrieveMultiple(query).Entities.ToArray<Entity>();

                },
                a =>
                {
                    var result = (Entity[])a.Result;

                    foreach (var entity in result.Where(x => (string)x.Attributes["returnedtypecode"] != "none"))
                    {
                        cbEntity.Items.Add(entity.Attributes["returnedtypecode"]);
                    }
                });
        }

        private void cbEntity_SelectedIndexChanged(object sender, EventArgs e)
        {
            var name = (string)((ComboBox)sender).SelectedItem;

            host.WorkAsync("Getting list of views",
                a =>
                {
                    var query = new QueryExpression("savedquery");
                    query.Distinct = true;

                    query.ColumnSet.AddColumn("savedqueryid");
                    query.ColumnSet.AddColumn("name");
                    query.ColumnSet.AddColumn("fetchxml");
                    query.ColumnSet.AddColumn("layoutxml");

                    query.Criteria = new FilterExpression();
                    query.Criteria.AddCondition("returnedtypecode", ConditionOperator.Equal, name);

                    a.Result = host.Service.RetrieveMultiple(query).Entities.ToArray<Entity>();
                },
                a =>
                {
                    gbDesign.Controls.Clear();

                    cbView.Items.Clear();
                    cbView.SelectedItem = null;
                    cbView.SelectedText = string.Empty;
                    cbView.SelectedIndex = -1;
                    cbView.Tag = (Entity[])a.Result;

                    foreach (var entity in (Entity[])a.Result)
                    {
                        cbView.Items.Add(entity.Attributes["name"]);
                    }
                });
        }

        private void cbView_SelectedIndexChanged(object sender, EventArgs e)
        {
            gbDesign.Controls.Clear();

            var views = (ComboBox)sender;
            var view = new LayoutDesigner();

            var menu = (ToolStrip)this.Parent.Controls.Find("tsMenu", true).FirstOrDefault();

            var snap = (ToolStripButton)menu.Items.Find("tsbSnap", true).FirstOrDefault();
            snap.Checked = true;

            view.Load(((Entity[])views.Tag)[views.SelectedIndex]);
            view.Name = "lvDesign";
            view.Size = gbDesign.Size;
            view.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left;

            gbDesign.Controls.Add(view);
        }
    }
}