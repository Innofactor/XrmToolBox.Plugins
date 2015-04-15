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

        private void MainControl_Enter(object sender, EventArgs e)
        {
            this.ExecuteMethod(RetrieveAssemblies);
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.CloseTool();
        }

        #endregion Private Methods

        #region Public Constructors

        public MainControl()
        {
            InitializeComponent();

            this.Enter += MainControl_Enter;
        }

        #endregion Public Constructors

        #region Public Properties

        public Entity[] PluginAsseblies
        {
            get;
            private set;
        }

        public Entity[] PluginTypes
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

        public void RetrieveAssemblies()
        {
            this.WorkAsync("Loading assemblies...",
                e =>
                {
                    e.Result = this.Service.GetPluginAssemblies();
                },
                e =>
                {
                    this.PluginAsseblies = (Entity[])e.Result;
                    this.cbAssemblies.Items.Clear();
                    foreach (var entity in this.PluginAsseblies)
                    {
                        var item = new PluginAssembly(entity);

                        this.cbAssemblies.Items.Add(item);
                    }
                });
        }

        /// <summary>
        /// Retrieves all types available in given assembly
        /// </summary>
        /// <param name="pluginAssembly"><see cref="PluginAssembly"/> for which there types should be retrieved</param>
        public void RetrieveTypes(PluginAssembly pluginAssembly)
        {
            this.WorkAsync("Loading types...",
                a =>
                {
                    a.Result = this.Service.GetPluginTypes(pluginAssembly.Id);
                },
                a =>
                {
                    this.PluginTypes = (Entity[])a.Result;
                    this.cbTypes.Items.Clear();
                    this.cbTypes.Items.Add("All types");
                    foreach (var entity in this.PluginTypes)
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

        private void RetrieveSteps(PluginAssembly pluginAssembly, PluginType pluginType)
        {
            this.WorkAsync("Loading steps...",
                a =>
                {
                    a.Result = (pluginType != null) ? this.Service.GetSdkMessageProcessingSteps(pluginAssembly.Id, pluginType.Id) : this.Service.GetSdkMessageProcessingSteps(pluginAssembly.Id);
                },
                a =>
                {
                    this.ProcessingSteps = (Entity[])a.Result;
                    this.lvSteps.Items.Clear();

                    var groups = new Dictionary<Guid, int>();
                    var i = 0;

                    foreach (var type in this.PluginTypes)
                    {
                        var item = new ListViewGroup
                        {
                            Header = (string)type.Attributes["name"],
                        };

                        this.lvSteps.Groups.Add(item);
                        groups.Add(type.Id, i++);
                    }

                    foreach (var step in this.ProcessingSteps)
                    {
                        var item = new ListViewItem
                        {
                            Text = (string)step["name"],
                            Group = this.lvSteps.Groups[groups[((EntityReference)step["plugintypeid"]).Id]]
                        };

                        this.lvSteps.Items.Add(item);
                    }
                });
        }

        public Entity[] ProcessingSteps 
        { 
            get; 
            private set; 
        }
    }
}