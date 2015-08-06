namespace Cinteros.Xrm.ViewDesignerTool.Controls
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Microsoft.Xrm.Sdk;
    using XrmToolBox.Extensibility;
    using Microsoft.Xrm.Sdk.Messages;
    using Microsoft.Xrm.Sdk.Query;

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

                    query.ColumnSet.AddColumns("name");
                    query.ColumnSet.AddColumns("fetchxml");
                    query.ColumnSet.AddColumns("layoutxml");

                    query.Criteria = new FilterExpression();
                    query.Criteria.AddCondition("returnedtypecode", ConditionOperator.Equal, name);

                    a.Result = host.Service.RetrieveMultiple(query).Entities.ToArray<Entity>();
                },
                a =>
                {
                    cbView.Items.Clear();
                    cbView.Tag = (Entity[])a.Result;

                    foreach (var entity in (Entity[])a.Result)
                    {
                        cbView.Items.Add(entity.Attributes["name"]);
                    }
                });
        }
    }
}