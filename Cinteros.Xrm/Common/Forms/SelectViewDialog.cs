namespace Cinteros.Xrm.Common.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using Cinteros.Xrm.DataUpdateTool.AppCode;
    using Cinteros.Xrm.XmlEditorUtils;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Query;
    using XrmToolBox.Extensibility;

    public partial class SelectViewDialog : Form
    {
        PluginControlBase Caller;
        public Entity View;
        public Dictionary<string, List<Entity>> Views
        {
            get;
            private set;
        }

        public SelectViewDialog(PluginControlBase caller)
        {
            InitializeComponent();
            Caller = caller;
            PopulateForm();
        }

        private void PopulateForm()
        {
            cmbEntity.Items.Clear();
            //var entities = MainControl.GetDisplayEntities();
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

            if (this.Views.ContainsKey(entity + "|S"))
            {
                var views = this.Views[entity + "|S"];
                cmbView.Items.Add("-- System Views --");
                foreach (var view in views)
                {
                    cmbView.Items.Add(new ViewItem(view));
                }
            }

            if (this.Views.ContainsKey(entity + "|U"))
            {
                var views = this.Views[entity + "|U"];
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
            //Enabled = false;
            cmbView.SelectedIndex = -1;
            cmbEntity.SelectedIndex = -1;
            txtFetch.Text = string.Empty;
            this.Views = new Dictionary<string, List<Entity>>();
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
            this.Caller.WorkAsync("Loading views...",
                (bgworker, workargs) =>
                {
                    // EnableControls(false);
                    if (this.Views == null || Views.Count == 0)
                    {
                        if (this.Caller.Service == null)
                        {
                            throw new Exception("Need a connection to load views.");
                        }
                        var qex = new QueryExpression("savedquery");
                        qex.ColumnSet = new ColumnSet("name", "returnedtypecode", "fetchxml", "layoutxml");
                        qex.Criteria.AddCondition("statecode", ConditionOperator.Equal, 0);
                        qex.Criteria.AddCondition("querytype", ConditionOperator.In, 0, 32);
                        qex.AddOrder("name", OrderType.Ascending);
                        bgworker.ReportProgress(33, "Loading system views...");
                        
                        var sysviews = this.Caller.Service.RetrieveMultiple(qex);
                        foreach (var view in sysviews.Entities)
                        {
                            var entityname = view["returnedtypecode"].ToString();
                            if (!string.IsNullOrWhiteSpace(entityname) /*&& entities.ContainsKey(entityname)*/)
                            {
                                if (!this.Views.ContainsKey(entityname + "|S"))
                                {
                                    this.Views.Add(entityname + "|S", new List<Entity>());
                                }
                                this.Views[entityname + "|S"].Add(view);
                            }
                        }
                        
                        qex.EntityName = "userquery";
                        bgworker.ReportProgress(66, "Loading user views...");

                        var userviews = this.Caller.Service.RetrieveMultiple(qex);
                        foreach (var view in userviews.Entities)
                        {
                            var entityname = view["returnedtypecode"].ToString();
                            if (!string.IsNullOrWhiteSpace(entityname) /*&& entities.ContainsKey(entityname)*/)
                            {
                                if (!this.Views.ContainsKey(entityname + "|U"))
                                {
                                    this.Views.Add(entityname + "|U", new List<Entity>());
                                }
                                this.Views[entityname + "|U"].Add(view);
                            }
                        }
                        bgworker.ReportProgress(100, "Finalizing...");
                    }
                },
                (completedargs) =>
                {
                    //working = false;
                    //EnableControls(true);
                    if (completedargs.Error != null)
                    {
                        MessageBox.Show(completedargs.Error.Message);
                    }
                    else
                    {
                        viewsLoaded();
                    }
                },
                (changeargs) =>
                {
                    // SetWorkingMessage(changeargs.UserState.ToString());
                });
        }
    }
}
