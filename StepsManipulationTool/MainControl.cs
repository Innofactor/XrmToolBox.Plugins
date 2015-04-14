namespace Cinteros.Xrm.StepsManipulator
{
    using System;
    using System.Windows.Forms;
    using Cinteros.Xrm.SDK;
    using Microsoft.Xrm.Sdk;
    using XrmToolBox;

    public partial class MainControl : PluginBase, IGitHubPlugin
    {
        #region Public Properties

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

        #endregion Public Methods

        #region Private Methods

        private void cbAssemblies_SelectedIndexChanged(object sender, EventArgs e)
        {
            var pluginAssembly = (PluginAssembly)((ComboBox)sender).SelectedItem;

            this.WorkAsync("Loading steps...",
                a =>
                {
                    a.Result = this.Service.GetPluginTypes(pluginAssembly.Id);
                },
                a =>
                {
                    this.PluginTypes = (Entity[])a.Result;
                    this.cbTypes.Items.Clear();
                    foreach (var entity in this.PluginTypes)
                    {
                        var item = new PluginType(entity, pluginAssembly);

                        this.cbTypes.Items.Add(item);
                    }
                });

            //var selectedItem = ((ComboBox)sender).SelectedItem;

            //var previousGroups = this.lvSteps.Groups;
            //var previousItems = this.lvSteps.Items;

            //this.WorkAsync("Loading steps...",
            //    a =>
            //    {
            //        a.Result = this.Service.GetSdkMessageProcessingSteps(((PluginAssembly)selectedItem).Id);
            //    },
            //    a =>
            //    {
            //        this.lvSteps.Items.Clear();
            //        this.lvSteps.Groups.Clear();

            // var steps = (Entity[])a.Result; var types = steps.GroupBy(x =>
            // x["plugintypeid"]).Select(y => y.First()).ToArray();

            // var groups = new Dictionary<Guid, int>(); var i = 0;

            // foreach (var type in types) { var item = new ListViewGroup { Header =
            // ((AliasedValue)type.Attributes["plugintype.typename"]).Value.ToString(), };
            // this.lvSteps.Groups.Add(item); groups.Add(((EntityReference)type["plugintypeid"]).Id,
            // i++); }

            // foreach (var step in steps) { var item = new ListViewItem { Text =
            // (string)step["name"], Group =
            // this.lvSteps.Groups[groups[((EntityReference)step["plugintypeid"]).Id]] };

            // this.lvSteps.Items.Add(item); } });
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

        #region Public Constructors

        public MainControl()
        {
            InitializeComponent();

            this.Enter += MainControl_Enter;
        }

        #endregion Public Constructors

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
    }
}