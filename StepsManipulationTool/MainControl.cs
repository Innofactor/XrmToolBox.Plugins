namespace Cinteros.Xrm.StepsManipulator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using Cinteros.Xrm.SDK;
    using Microsoft.Xrm.Sdk;
    using XrmToolBox;

    public partial class MainControl : PluginBase, IGitHubPlugin
    {
        #region Private Methods

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.CloseTool();
        }

        #endregion Private Methods

        #region Public Constructors

        public MainControl()
        {
            InitializeComponent();

            this.PluginAsseblies = new List<PluginAssembly>();
            this.PluginTypes = new List<PluginType>();
            this.ProcessingSteps = new List<ProcessingStep>();

            this.Enter += MainControl_Enter;
        }

        #endregion Public Constructors

        #region Public Properties

        public List<PluginAssembly> PluginAsseblies
        {
            get;
            private set;
        }

        public List<PluginType> PluginTypes
        {
            get;
            private set;
        }

        public List<ProcessingStep> ProcessingSteps
        {
            get;
            private set;
        }

        public string RepositoryName
        {
            get
            {
                return "StepsManipulator";
            }
        }

        public string UserName
        {
            get
            {
                return "Cinteros";
            }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Retrieves all plugin assemblies available in given environment
        /// </summary>
        public void RetrieveAssemblies()
        {
            this.WorkAsync("Loading assemblies...",
                e =>
                {
                    e.Result = this.Service.GetPluginAssemblies();
                },
                e =>
                {
                    this.PluginAsseblies.Clear();
                    this.cbAssemblies.Items.Clear();
                    foreach (var entity in (Entity[])e.Result)
                    {
                        var item = new PluginAssembly(entity);

                        this.PluginAsseblies.Add(item);
                        this.cbAssemblies.Items.Add(item);
                    }
                });
        }

        /// <summary>
        /// Retrieves all steps available in given assembly and selected type
        /// </summary>
        /// <param name="pluginAssembly"><see cref="PluginAssembly"/> for which steps should be retrieved</param>
        /// <param name="pluginType"<see cref="PluginType"/> for which steps should be retrieved</param>
        public void RetrieveSteps(PluginAssembly pluginAssembly, PluginType pluginType)
        {
            this.WorkAsync("Loading steps...",
                a =>
                {
                    a.Result = (pluginType != null) ? this.Service.GetSdkMessageProcessingSteps(pluginAssembly.Id, pluginType.Id) : this.Service.GetSdkMessageProcessingSteps(pluginAssembly.Id);
                },
                a =>
                {
                    this.ProcessingSteps.Clear();
                    this.lvSteps.Items.Clear();

                    var groups = new Dictionary<Guid, int>();
                    var i = 0;

                    foreach (var type in this.PluginTypes)
                    {
                        var item = new ListViewGroup
                        {
                            Header = type.FriendlyName,
                        };

                        this.lvSteps.Groups.Add(item);
                        groups.Add(type.Id, i++);
                    }

                    foreach (var entity in (Entity[])a.Result)
                    {
                        var item = new ListViewItem
                        {
                            Text = (string)entity["name"],
                            Group = this.lvSteps.Groups[groups[((EntityReference)entity["plugintypeid"]).Id]],
                            Tag = new ProcessingStep(entity, pluginAssembly, pluginType)
                        };

                        this.lvSteps.Items.Add(item);
                    }
                });
        }

        /// <summary>
        /// Retrieves all types available in given assembly
        /// </summary>
        /// <param name="pluginAssembly">
        /// <see cref="PluginAssembly"/> for which there types should be retrieved
        /// </param>
        public void RetrieveTypes(PluginAssembly pluginAssembly)
        {
            this.WorkAsync("Loading types...",
                a =>
                {
                    a.Result = this.Service.GetPluginTypes(pluginAssembly.Id);
                },
                a =>
                {
                    this.PluginTypes.Clear();
                    this.cbTypes.Items.Clear();

                    this.cbTypes.Items.Add("All types");
                    foreach (var entity in (Entity[])a.Result)
                    {
                        var item = new PluginType(entity, pluginAssembly);

                        this.cbTypes.Items.Add(item);
                    }

                    // Select all types
                    this.cbTypes.SelectedIndex = 0;
                });
        }

        #endregion Public Methods

        private void cbAssemblies_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lvSteps.Items.Clear();
            this.RetrieveTypes((PluginAssembly)((ComboBox)sender).SelectedItem);
        }

        private void cbTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var pluginAssembly = (PluginAssembly)this.cbAssemblies.SelectedItem;
            var pluginType = ((ComboBox)sender).SelectedItem as PluginType;

            this.RetrieveSteps(pluginAssembly, pluginType);
        }

        /// <summary>
        /// Dropping selection for all steps available
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dropSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SelectAndCheckAll(false);
        }

        private void MainControl_Enter(object sender, EventArgs e)
        {
            this.ExecuteMethod(RetrieveAssemblies);
        }

        /// <summary>
        /// Selecting and checking all the steps available
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SelectAndCheckAll(true);
        }

        private void SelectAndCheckAll(bool status)
        {
            this.lvSteps.Items.Cast<ListViewItem>().ToList().ForEach(x => x.Selected = status);
            this.lvSteps.Items.Cast<ListViewItem>().ToList().ForEach(x => x.Checked = status);
        }
    }
}