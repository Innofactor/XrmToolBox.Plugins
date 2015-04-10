namespace Cinteros.Xrm.StepsManipulator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using Cinteros.Xrm.VersionVerificationTool.SDK;
    using Microsoft.Xrm.Sdk;
    using XrmToolBox;

    public partial class MainControl : PluginBase, IGitHubPlugin
    {
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

                    foreach (var entity in this.PluginAsseblies)
                    {
                        var item = new PluginAssembly(entity);

                        this.cbAssemblies.Items.Add(item);
                    }
                });
        }

        public void RetrieveSteps()
        {
            this.WorkAsync("Loading steps...",
                e =>
                {
                    e.Result = this.Service.GetSdkMessageProcessingSteps();
                },
                e =>
                {
                    var steps = (Entity[])e.Result;
                    var types = steps.GroupBy(x => x["plugintypeid"]).Select(y => y.First()).ToArray();

                    var groups = new Dictionary<Guid, int>();
                    var i = 0;

                    foreach (var type in types)
                    {
                        var item = new ListViewGroup
                        {
                            Header = ((AliasedValue)type.Attributes["plugintype.typename"]).Value.ToString(),
                        };
                        this.lvSteps.Groups.Add(item);
                        groups.Add(((EntityReference)type["plugintypeid"]).Id, i++);
                    }

                    foreach (var step in steps)
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

        #endregion Public Methods

        #region Private Methods

        private void cbAssemblies_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void MainControl_Enter(object sender, EventArgs e)
        {
            this.ExecuteMethod(RetrieveAssemblies);
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.CloseTool();
        }

        #endregion Private Methods
    }
}