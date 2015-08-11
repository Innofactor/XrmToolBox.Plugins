namespace Cinteros.Xrm.Common.Forms
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using Cinteros.Xrm.DataUpdateTool.AppCode;
    using Cinteros.Xrm.XmlEditorUtils;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Query;
    using XrmToolBox.Extensibility;

    public partial class SelectViewDialog : Form
    {
        private PluginControlBase host;

        public Entity View;

        private Dictionary<string, List<Entity>> views;
        private List<string> entities;

        public SelectViewDialog(PluginControlBase sender)
        {
            InitializeComponent();
            this.host = sender;
            PopulateForm();
        }

        private void PopulateForm()
        {
            cmbEntity.Items.Clear();
            this.LoadViews(() => { });
            
            //if (entities != null)
            //{
            //    foreach (var entity in entities)
            //    {
            //        if (entity.Value.IsIntersect != true && this.Views.ContainsKey(entity.Value.LogicalName + "|S"))
            //        {
            //            cmbEntity.Items.Add(new EntityItem(entity.Value));
            //        }
            //    }
            //}
            //Enabled = true;
        }

        private void cmbEntity_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateViews();
        }

        private void UpdateViews()
        {
            cmbView.Items.Clear();
            cmbView.Text = string.Empty;
            txtFetch.Text = string.Empty;
            btnOk.Enabled = false;
            var entity = ControlUtils.GetValueFromControl(cmbEntity);

            if (this.views.ContainsKey(entity + "|S"))
            {
                var views = this.views[entity + "|S"];
                cmbView.Items.Add("-- System Views --");
                foreach (var view in views)
                {
                    cmbView.Items.Add(new ViewItem(view));
                }
            }

            if (this.views.ContainsKey(entity + "|U"))
            {
                var views = this.views[entity + "|U"];
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
                this.View = ((ViewItem)cmbView.SelectedItem).GetView();
            }
            else
            {
                this.View = null;
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
            //Enabled = false;
            cmbView.SelectedIndex = -1;
            cmbEntity.SelectedIndex = -1;
            txtFetch.Text = string.Empty;
            this.LoadViews(PopulateForm);
        }

        internal void LoadViews(Action viewsLoaded)
        {
            //if (working)
            //{
            //    return;
            //}
            //if (entities == null || entities.Count == 0)
            //{
            //    LoadEntities(viewsLoaded);
            //    return;
            //}
            //working = true;
            this.host.WorkAsync("Loading views...",
                (bgworker, workargs) =>
                {
                    this.views = new Dictionary<string, List<Entity>>();

                    // EnableControls(false);
                    if (views.Count == 0)
                    {
                        if (this.host.Service == null)
                        {
                            throw new Exception("Need a connection to load views.");
                        }
                        var qex = new QueryExpression("savedquery");

                        qex.ColumnSet = new ColumnSet("name", "returnedtypecode", "fetchxml", "layoutxml");
                        qex.Criteria.AddCondition("statecode", ConditionOperator.Equal, 0);
                        qex.Criteria.AddCondition("querytype", ConditionOperator.In, 0, 32);
                        qex.AddOrder("name", OrderType.Ascending);
                        // bgworker.ReportProgress(33, "Loading system views...");

                        var result = new Dictionary<string, EntityCollection>();
                        result.Add("sysviews", this.host.Service.RetrieveMultiple(qex));
                        
                        qex.EntityName = "userquery";
                        // bgworker.ReportProgress(66, "Loading user views...");

                        result.Add("userviews", this.host.Service.RetrieveMultiple(qex));
                        //bgworker.ReportProgress(100, "Finalizing...");

                        workargs.Result = result;
                    }
                },
                (completedargs) =>
                {
                    var allViews = (Dictionary<string, EntityCollection>)completedargs.Result;
                    
                    this.ExtractViews(allViews["sysviews"].Entities);
                    this.ExtractViews(allViews["userviews"].Entities);

                    this.entities = this.views.Keys.Select(x => x.Split('|')[0]).ToList();
                },
                (changeargs) =>
                {
                    // SetWorkingMessage(changeargs.UserState.ToString());
                });
        }

        private void ExtractViews(DataCollection<Entity> views)
        {
            var suffix = (views.FirstOrDefault().LogicalName == "savedquery") ? "|S" : "|U";
            
            foreach (var view in views)
            {
                var entityname = view["returnedtypecode"].ToString();
                
                if (!string.IsNullOrWhiteSpace(entityname))
                {
                    if (!this.views.ContainsKey(entityname + suffix))
                    {
                        this.views.Add(entityname + suffix, new List<Entity>());
                    }
                    this.views[entityname + suffix].Add(view);
                }
            }
        }
    }
}
