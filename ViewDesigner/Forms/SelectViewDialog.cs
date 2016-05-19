namespace Cinteros.XTB.ViewDesigner.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Query;
    using XrmToolBox.Extensibility;
    using AppCode;
    using Xrm.XmlEditorUtils;
    public partial class SelectViewDialog : Form
    {
        #region Public Fields

        public Entity View;

        #endregion Public Fields

        #region Private Fields

        private List<string> entities;
        private PluginControlBase host;
        private Dictionary<string, List<Entity>> views;

        #endregion Private Fields

        #region Public Constructors

        public SelectViewDialog(PluginControlBase sender)
        {
            InitializeComponent();
            this.host = sender;
        }

        #endregion Public Constructors

        #region Internal Methods

        internal void LoadViews(Action action)
        {
            this.host.WorkAsync("Loading views...",
                (a) =>
                {
                    this.views = new Dictionary<string, List<Entity>>();

                    if (views.Count == 0)
                    {
                        var combinedResult = new Dictionary<string, DataCollection<Entity>>();
                        DataCollection<Entity> singleResult;

                        var qex = new QueryExpression();

                        qex.ColumnSet = new ColumnSet("name", "returnedtypecode", "fetchxml", "layoutxml");
                        qex.Criteria.AddCondition("statecode", ConditionOperator.Equal, 0);
                        qex.AddOrder("name", OrderType.Ascending);

                        foreach (var entity in new string[] { "savedquery", "userquery" })
                        {
                            qex.EntityName = entity;

                            singleResult = this.host.Service.RetrieveMultiple(qex).Entities;
                            if (singleResult.Count > 0)
                            {
                                combinedResult.Add(qex.EntityName, singleResult);
                            }
                        }

                        a.Result = combinedResult;
                    }
                },
                (a) =>
                {
                    var allViews = (Dictionary<string, DataCollection<Entity>>)a.Result;

                    foreach (var key in allViews.Keys)
                    {
                        this.ExtractViews(allViews[key]);
                    }

                    this.entities = this.views.Keys.Select(x => x.Split('|')[0]).Distinct().ToList();

                    action();
                });
        }

        #endregion Internal Methods

        #region Private Methods

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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cmbEntity.SelectedIndex = -1;
            cmbEntity.Items.Clear();

            cmbView.SelectedIndex = -1;
            cmbView.Items.Clear();

            txtFetch.Text = string.Empty;

            this.LoadViews(this.PopulateForm);
        }

        private void cmbEntity_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateViews();
        }

        private void cmbView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbView.SelectedItem is ViewItem)
            {
                txtFetch.Text = ((ViewItem)cmbView.SelectedItem).GetLayout();
                txtFetch.Process();
                btnOk.Enabled = true;
            }
            else
            {
                txtFetch.Text = string.Empty;
                btnOk.Enabled = false;
            }
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

        private void PopulateForm()
        {
            cmbView.Items.Clear();
            cmbView.Text = string.Empty;
            txtFetch.Text = string.Empty;

            if (entities != null)
            {
                foreach (var entity in entities)
                {
                    cmbEntity.Items.Add(entity);
                }
            }
        }

        private void SelectViewDialog_Load(object sender, EventArgs e)
        {
            if (this.host.Service == null)
            {
                MessageBox.Show("Need a connection to load views!", "Connection problem", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                this.Close();

                return;
            }

            this.LoadViews(this.PopulateForm);
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

        #endregion Private Methods
    }
}