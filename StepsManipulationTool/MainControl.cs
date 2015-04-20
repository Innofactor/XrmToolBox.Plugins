namespace Cinteros.Xrm.StepsManipulationTool
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using Cinteros.Xrm.SDK;
    using Cinteros.Xrm.Utils;
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

        /// <summary>
        /// Gets array of plugin assemblies used
        /// </summary>
        public PluginAssembly[] PluginAsseblies
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets array of plugin types used
        /// </summary>
        public PluginType[] PluginTypes
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets array of processing steps used
        /// </summary>
        public ProcessingStep[] ProcessingSteps
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
                    this.PluginAsseblies = ((Entity[])e.Result).Select<Entity, PluginAssembly>(x => new PluginAssembly(x)).ToArray();
                    this.cbAssemblies.Items.Clear();

                    foreach (var assembly in this.PluginAsseblies)
                    {
                        this.cbAssemblies.Items.Add(assembly);
                    }
                });
        }

        /// <summary> Retrieves all steps available in given assembly and selected type </summary>
        /// <param name="pluginAssembly"><see cref="PluginAssembly"/> for which steps should be
        /// retrieved</param> <param name="pluginType"<see cref="PluginType"/> for which steps
        /// should be retrieved</param>
        public void RetrieveSteps(PluginAssembly pluginAssembly, PluginType pluginType)
        {
            this.WorkAsync("Loading steps...",
                a =>
                {
                    a.Result = (pluginType != null) ? this.Service.GetSdkMessageProcessingSteps(pluginAssembly.Id, pluginType.Id) : this.Service.GetSdkMessageProcessingSteps(pluginAssembly.Id);
                },
                a =>
                {
                    this.ProcessingSteps = ((Entity[])a.Result).Select<Entity, ProcessingStep>(x =>
                        {
                            return new ProcessingStep(x, pluginAssembly, this.PluginTypes.Where(y => y.Id == ((EntityReference)x.Attributes[Constants.Crm.Attributes.PLUGIN_TYPE_ID]).Id).FirstOrDefault());
                        }).ToArray();
                    this.lvSteps.Items.Clear();

                    var groups = new Dictionary<Guid, int>();

                    // If pluginType is null, so all available in current assembly types are selected
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

                    foreach (var step in this.ProcessingSteps)
                    {
                        var item = new ListViewItem(new string[] { step.FriendlyName, step.StateCode.ToString() });

                        item.Tag = step;
                        item.Group = this.lvSteps.Groups[groups[step.ParentType.Id]];

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
                    this.PluginTypes = ((Entity[])a.Result).Select<Entity, PluginType>(x => new PluginType(x, pluginAssembly)).ToArray();
                    this.cbTypes.Items.Clear();

                    this.cbTypes.Items.Add("All types");
                    foreach (var type in this.PluginTypes)
                    {
                        this.cbTypes.Items.Add(type);
                    }

                    // Select all types
                    this.cbTypes.SelectedIndex = 0;
                });
        }

        #endregion Public Methods

        #region Private Methods

        private void cbAssemblies_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedAssembly = (PluginAssembly)((ComboBox)sender).SelectedItem;

            this.lvSteps.Items.Clear();
            this.FillAssemblies(selectedAssembly);

            this.RetrieveTypes(selectedAssembly);
        }

        private void cbTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var pluginAssembly = (PluginAssembly)this.cbAssemblies.SelectedItem;
            var pluginType = ((ComboBox)sender).SelectedItem as PluginType;

            this.RetrieveSteps(pluginAssembly, pluginType);
        }

        private void cmStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.FillTypes(this.cbTypes.SelectedItem as PluginType);
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

        /// <summary>
        /// Fill drop-down list of assemblies in context menu
        /// </summary>
        /// <param name="selectedAssembly"></param>
        private void FillAssemblies(PluginAssembly selectedAssembly)
        {
            this.tscAssemblies.Items.Clear();

            foreach (var assembly in this.PluginAsseblies.Where(x => x.Id != selectedAssembly.Id))
            {
                this.tscAssemblies.Items.Add(assembly);
            }
        }

        /// <summary>
        /// Filling drop-down list of types in context menu
        /// </summary>
        /// <param name="pluginType"></param>
        private void FillTypes(PluginType pluginType = null)
        {
            this.tscTypes.Items.Clear();

            foreach (var type in (pluginType == null) ? this.PluginTypes : this.PluginTypes.Where(x => x.Id != pluginType.Id).ToArray())
            {
                tscTypes.Items.Add(type);
            }
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

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.CloseTool();
        }

        private void tscAssemblies_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Resetting selection index ((ToolStripComboBox)sender).SelectedIndex = -1;

            var targetAssembly = (PluginAssembly)((ToolStripComboBox)sender).SelectedItem;

            var steps = this.lvSteps.SelectedItems.Cast<ListViewItem>().Select<ListViewItem, ProcessingStep>(x => (ProcessingStep)x.Tag).ToArray();

            this.WorkAsync("Matching types in source and target assemblies...",
                a =>
                {
                    var hits = new int[] { 0, 0, 0 };

                    var sourceTypes = this.PluginTypes.Select(x => x.ToEntity()).ToArray();
                    var targetTypes = this.Service.GetPluginTypes(targetAssembly.Id);

                    foreach (var step in this.lvSteps.SelectedItems.Cast<ListViewItem>().Select<ListViewItem, Entity>(x => ((ProcessingStep)x.Tag).ToEntity()).ToArray())
                    {
                        var sourcePluginTypeId = (EntityReference)step[Constants.Crm.Attributes.PLUGIN_TYPE_ID];
                        var sourceSdkMessageProcessingStepId = step.Id;
                        var sourceType = sourceTypes.Where(x => ((Guid)x[Constants.Crm.Attributes.PLUGIN_TYPE_ID]) == sourcePluginTypeId.Id).FirstOrDefault<Entity>();
                        var targetType = targetTypes.Where(x => (string)x[Constants.Crm.Attributes.NAME] == (string)sourceType[Constants.Crm.Attributes.NAME]).FirstOrDefault<Entity>();

                        if (targetType != null)
                        {
                            step[Constants.Crm.Attributes.PLUGIN_TYPE_ID] = targetType.ToEntityReference();

                            step.Attributes.Remove("eventhandler");

                            try
                            {
                                this.Service.Update(step);
                                // Matched
                                hits[1]++;
                            }
                            catch (Exception)
                            {
                                // Failed to match
                                hits[2]++;
                            }
                        }
                        else
                        {
                            // Missing
                            hits[0]++;
                        }
                    }
                    a.Result = hits;
                },
                a =>
                {
                });
        }

        private void tscTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var targetType = (PluginType)((ToolStripComboBox)sender).SelectedItem;

            foreach (var step in this.lvSteps.SelectedItems.Cast<ListViewItem>().Select<ListViewItem, Entity>(x => ((ProcessingStep)x.Tag).ToEntity()).ToArray())
            {
                if (targetType != null)
                {
                    step[Constants.Crm.Attributes.PLUGIN_TYPE_ID] = targetType.ToEntity().ToEntityReference();

                    step.Attributes.Remove("eventhandler");

                    try
                    {
                        this.Service.Update(step);
                        // Matched hits[1]++;
                    }
                    catch (Exception)
                    {
                        // Failed to match hits[2]++;
                    }
                }
                else
                {
                    // Missing hits[0]++;
                }
            }
        }

        #endregion Private Methods
    }
}