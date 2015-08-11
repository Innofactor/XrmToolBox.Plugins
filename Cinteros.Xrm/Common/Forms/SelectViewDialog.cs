namespace Cinteros.Xrm.DataUpdateTool.Forms
{
    using System;
    using System.Windows.Forms;
    using Cinteros.Xrm.DataUpdateTool.AppCode;
    using Cinteros.Xrm.XmlEditorUtils;
    using Microsoft.Xrm.Sdk;

    public partial class SelectViewDialog : Form
    {
        MainControl Caller;
        public Entity View;

        public SelectViewDialog(MainControl caller)
        {
            InitializeComponent();
            Caller = caller;
            PopulateForm();
        }

        private void PopulateForm()
        {
            cmbEntity.Items.Clear();
            var entities = MainControl.GetDisplayEntities();
            if (entities != null)
            {
                foreach (var entity in entities)
                {
                    if (entity.Value.IsIntersect != true && MainControl.views.ContainsKey(entity.Value.LogicalName + "|S"))
                    {
                        cmbEntity.Items.Add(new EntityItem(entity.Value));
                    }
                }
            }
            Enabled = true;
        }

        private void cmbEntity_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateViews();
        }

        private void UpdateViews()
        {
            cmbView.Items.Clear();
            cmbView.Text = "";
            txtFetch.Text = "";
            btnOk.Enabled = false;
            var entity = ControlUtils.GetValueFromControl(cmbEntity);
            if (MainControl.views.ContainsKey(entity + "|S"))
            {
                var views = MainControl.views[entity + "|S"];
                cmbView.Items.Add("-- System Views --");
                foreach (var view in views)
                {
                    cmbView.Items.Add(new ViewItem(view));
                }
            }
            if (MainControl.views.ContainsKey(entity + "|U"))
            {
                var views = MainControl.views[entity + "|U"];
                cmbView.Items.Add("-- Personal Views --");
                foreach (var view in views)
                {
                    cmbView.Items.Add(new ViewItem(view));
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (cmbView.SelectedItem is ViewItem)
            {
                View = ((ViewItem)cmbView.SelectedItem).GetView();
            }
            else
            {
                View = null;
            }
        }

        private void cmbView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbView.SelectedItem is ViewItem)
            {
                txtFetch.Text = ((ViewItem)cmbView.SelectedItem).GetFetch();
                txtFetch.Process();
                btnOk.Enabled = true;
            }
            else
            {
                txtFetch.Text = "";
                btnOk.Enabled = false;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Enabled = false;
            cmbView.SelectedIndex = -1;
            cmbEntity.SelectedIndex = -1;
            txtFetch.Text = "";
            MainControl.views = null;
            Caller.LoadViews(PopulateForm);
        }
    }
}
