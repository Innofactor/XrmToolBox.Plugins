namespace Cinteros.Xrm.DataUpdateTool.Forms
{
    using Cinteros.Xrm.DataUpdateTool.AppCode;
    using Cinteros.Xrm.XmlEditorUtils;
    using Microsoft.Xrm.Sdk;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class SelectViewDialog : Form
    {
        DataUpdater Caller;
        public Entity View;

        public SelectViewDialog(DataUpdater caller)
        {
            InitializeComponent();
            Caller = caller;
            PopulateForm();
        }

        private void PopulateForm()
        {
            cmbEntity.Items.Clear();
            var entities = DataUpdater.GetDisplayEntities();
            if (entities != null)
            {
                foreach (var entity in entities)
                {
                    if (entity.Value.IsIntersect != true && DataUpdater.views.ContainsKey(entity.Value.LogicalName + "|S"))
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
            if (DataUpdater.views.ContainsKey(entity + "|S"))
            {
                var views = DataUpdater.views[entity + "|S"];
                cmbView.Items.Add("-- System Views --");
                foreach (var view in views)
                {
                    cmbView.Items.Add(new ViewItem(view));
                }
            }
            if (DataUpdater.views.ContainsKey(entity + "|U"))
            {
                var views = DataUpdater.views[entity + "|U"];
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
            DataUpdater.views = null;
            Caller.LoadViews(PopulateForm);
        }
    }
}
