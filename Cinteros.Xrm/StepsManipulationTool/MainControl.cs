namespace Cinteros.Xrm.StepsManipulationTool
{
    using Common.SDK;
    using Common.Utils;
    using Microsoft.Xrm.Sdk;
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using System.Xml;
    using XrmToolBox.Extensibility;
    using XrmToolBox.Extensibility.Interfaces;
    using System.ComponentModel;
    using System.Diagnostics;

    public partial class MainControl : PluginControlBase, IGitHubPlugin, IWorkerHost
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
                return "XrmToolBox.Plugins";
            }
        }

        public ProcessingStep[] SelectedSteps
        {
            get
            {
                ProcessingStep[] steps = null;
                Invoke(new Action(() =>
                {
                    //steps = lvSteps.SelectedItems.Cast<ListViewItem>().Select<ListViewItem, Entity>(x => ((ProcessingStep)x.Tag).ToEntity()).ToArray();
                    steps = lvSteps.SelectedItems.Cast<ListViewItem>().Select<ListViewItem, ProcessingStep>(x => (ProcessingStep)x.Tag).ToArray();
                }));

                return steps;
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
            this.WorkAsync(new WorkAsyncInfo("Loading assemblies...",
                e =>
                {
                    e.Result = this.Service.GetPluginAssemblies();
                })
            {
                PostWorkCallBack = (e) =>
                {
                    this.PluginAsseblies = ((Entity[])e.Result).Select<Entity, PluginAssembly>(x => new PluginAssembly(x)).ToArray();
                    this.cbSourceAssembly.Items.Clear();
                    this.cbTargetAssembly.Items.Clear();

                    foreach (var assembly in this.PluginAsseblies)
                    {
                        this.cbSourceAssembly.Items.Add(assembly);
                        this.cbTargetAssembly.Items.Add(assembly);
                    }
                }
            });
        }

        /// <summary> Retrieves all steps available in given assembly and selected type </summary>
        /// <param name="pluginAssembly"><see cref="PluginAssembly"/> for which steps should be
        /// retrieved</param> <param name="pluginType"<see cref="PluginType"/> for which steps
        /// should be retrieved</param>
        public void RetrieveSteps(PluginAssembly pluginAssembly, PluginType pluginType)
        {
            WorkAsync(new WorkAsyncInfo("Loading steps...",
                a =>
                {
                    a.Result = (pluginType != null) ? Service.GetSdkMessageProcessingSteps(pluginAssembly.Id, pluginType.Id) : Service.GetSdkMessageProcessingSteps(pluginAssembly.Id);
                })
            {
                PostWorkCallBack = (a) =>
                {
                    PluginTypes = this.cbSourcePlugin.Items.Cast<PluginType>().ToArray();

                    ProcessingSteps = ((Entity[])a.Result).Select<Entity, ProcessingStep>(x =>
                    {
                        return new ProcessingStep(x, pluginAssembly, PluginTypes.Where(y => y.Id == ((EntityReference)x.Attributes[Constants.Crm.Attributes.PLUGIN_TYPE_ID]).Id).FirstOrDefault());
                    }).ToArray();
                    lvSteps.Items.Clear();

                    // var groups = new Dictionary<Guid, int>();

                    // If pluginType is null, so all available in current assembly types are selected

                    //foreach (var type in this.PluginTypes)
                    //{
                    //    var item = new ListViewGroup
                    //    {
                    //        Header = type.FriendlyName,
                    //    };

                    //    this.lvSteps.Groups.Add(item); groups.Add(type.Id, i++);
                    //}

                    foreach (var step in this.ProcessingSteps)
                    {
                        var item = new ListViewItem(new string[] { step.FriendlyName, step.StateCode.ToString() });

                        item.Tag = step;
                        // item.Group = this.lvSteps.Groups[groups[step.ParentType.Id]];

                        this.lvSteps.Items.Add(item);
                    }
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
            this.WorkAsync(new WorkAsyncInfo("Loading types...",
                a =>
                {
                    a.Result = this.Service.GetPluginTypes(pluginAssembly.Id);
                })
            {
                PostWorkCallBack = (a) =>
                {
                    this.PluginTypes = ((Entity[])a.Result).Select(x => new PluginType(x, pluginAssembly)).ToArray();
                    this.cbSourcePlugin.Items.Clear();

                    this.cbSourcePlugin.Items.Add("All types");
                    foreach (var type in this.PluginTypes)
                    {
                        this.cbSourcePlugin.Items.Add(type);
                    }

                    // Select all types
                    this.cbSourcePlugin.SelectedIndex = 0;
                }
            });
        }

        #endregion Public Methods

        #region Private Methods

        private static void AddString(XmlDocument document, XmlElement properties, string name, string value)
        {
            var property = document.CreateElement(name);
            property.InnerText = value;
            properties.AppendChild(property);
        }

        private static void AddEntityReference(XmlDocument document, XmlElement properties, Entity definition, string name)
        {
            if (definition.Attributes.ContainsKey(name))
            {
                AddString(document, properties, name, ((EntityReference)definition.Attributes[name]).Id.ToString());
            }
        }

        private static void AddOptionSetValue(XmlDocument document, XmlElement properties, Entity definition, string name)
        {
            if (definition.Attributes.ContainsKey(name))
            {
                AddString(document, properties, name, ((OptionSetValue)definition.Attributes[name]).Value.ToString());
            }
        }

        private static Entity[] RemoveEarlyBound(Entity[] entities)
        {
            if (entities.FirstOrDefault().GetType() != typeof(Entity))
            {
                entities = entities.Select(x => x.ToEntity<Entity>()).ToArray();
            }

            return entities;
        }

        private void bMove_Click(object sender, EventArgs e)
        {
            var targetType = (PluginType)((ComboBox)cbTargetPlugin).SelectedItem;
            var steps = this.lvSteps.SelectedItems.Cast<ListViewItem>().Select<ListViewItem, Entity>(x => ((ProcessingStep)x.Tag).ToEntity()).ToArray();

            var info = new WorkAsyncInfo();
            info.Message = "Moving steps...";

            info.Work = (worker, a) =>
            {
                foreach (var step in steps)
                {
                    step[Constants.Crm.Attributes.PLUGIN_TYPE_ID] = targetType.ToEntity().ToEntityReference();

                    step.Attributes.Remove("eventhandler");

                    try
                    {
                        this.Service.Update(step);
                    }
                    catch (Exception)
                    {
                        // Failed to match
                    }
                }
            };

            info.PostWorkCallBack = (a) =>
            {
                RetrieveSteps();
            };

            WorkAsync(info);
        }

        private void cbSourceAssembly_SelectedIndexChanged(object sender, EventArgs e)
        {
            // var selectedAssembly = (PluginAssembly)((ComboBox)sender).SelectedItem;

            lvSteps.Items.Clear();
            // this.FillAssemblies(selectedAssembly);

            cbSourcePlugin.RetrieveTypes(this, (PluginAssembly)((ComboBox)sender).SelectedItem, true);
            // this.RetrieveTypes(selectedAssembly);
        }

        private void cbSourcePlugin_SelectedIndexChanged(object sender, EventArgs e)
        {
            RetrieveSteps();
        }

        private void RetrieveSteps()
        {
            var pluginAssembly = this.cbSourceAssembly.SelectedItem as PluginAssembly;
            var pluginType = this.cbSourcePlugin.SelectedItem as PluginType;

            RetrieveSteps(pluginAssembly, pluginType);
        }

        private void cbTargetAssembly_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbTargetPlugin.RetrieveTypes(this, (PluginAssembly)((ComboBox)sender).SelectedItem);
            bMove.Enabled = false;
        }

        private void cbTargetPlugin_SelectedIndexChanged(object sender, EventArgs e)
        {
            bMove.Enabled = true;
        }

        private void cmStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            FillTypes(this.cbSourcePlugin.SelectedItem as PluginType);
        }

        /// <summary>
        /// Dropping selection for all steps available
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dropSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectAndCheckAll(false);
        }

        private void exportSelected_Click(object sender, EventArgs e)
        {
            var info = new WorkAsyncInfo();
            info.Message = "Exporting data...";

            info.Work = (worker, a) =>
            {
                try
                {
                    var images = Service.GetSdkMessageProcessingStepImages(SelectedSteps.Select(x => x.ToEntity()).ToArray());

                    var document = new XmlDocument();

                    document.AppendChild(document.CreateXmlDeclaration("1.0", "UTF-8", "yes"));
                    document.AppendChild(document.CreateComment("Reference snapshot"));

                    var root = document.CreateElement("snapshot");

                    foreach (var pluginDefinition in SelectedSteps.Select(x => x.ParentType).Distinct().ToArray())
                    {
                        var plugin = CreateHeaderElement(document, Constants.Xml.PLUGIN, pluginDefinition.Id, pluginDefinition.FriendlyName);

                        root.AppendChild(plugin);

                        foreach (var stepDefinition in SelectedSteps.Where(x => x.ParentType.Id == pluginDefinition.Id).ToArray())
                        {
                            var step = CreateHeaderElement(document, Constants.Xml.STEP, stepDefinition.Id, stepDefinition.FriendlyName);
                            plugin.AppendChild(step);

                            var stepEntity = stepDefinition.ToEntity();

                            AddEntityReference(document, step, stepEntity, "eventhandler");
                            AddEntityReference(document, step, stepEntity, "sdkmessagefilterid");

                            AddOptionSetValue(document, step, stepEntity, "mode");
                            AddOptionSetValue(document, step, stepEntity, "stage");
                            AddOptionSetValue(document, step, stepEntity, "statecode");
                            AddOptionSetValue(document, step, stepEntity, "statuscode");

                            foreach (var imageDefinition in images.Where(x => ((EntityReference)x.Attributes["sdkmessageprocessingstepid"]).Id == stepDefinition.Id))
                            {
                                var name = (imageDefinition.Attributes.ContainsKey("name")) ? (string)imageDefinition.Attributes["name"] : string.Empty;
                                var image = CreateHeaderElement(document, Constants.Xml.IMAGE, imageDefinition.Id, name);
                                step.AppendChild(image);

                                AddOptionSetValue(document, image, imageDefinition, "imagetype");
                                AddString(document, image, "entityalias", (string)imageDefinition.Attributes["entityalias"]);
                            }
                        }
                    }

                    document.AppendChild(root);

                    a.Result = document;
                }
                catch (Exception ex)
                {
                    // Failed to retrieve images
                }
            };

            info.PostWorkCallBack = (a) =>
            {
                var save = new SaveFileDialog();
                save.FileOk += (s, args) =>
                {
                    if (!args.Cancel)
                    {
                        ((XmlDocument)a.Result).Save(((SaveFileDialog)s).FileName);
                    }
                };

                save.FileName = "reference-snapshot.xml";
                save.ShowDialog();
            };

            WorkAsync(info);
        }

        private static XmlElement CreateHeaderElement(XmlDocument document, string elementName, Guid id, string friendlyName)
        {
            XmlAttribute attribute;

            var element = document.CreateElement(elementName);

            attribute = document.CreateAttribute(Constants.Xml.ID);
            attribute.Value = id.ToString();
            element.Attributes.Append(attribute);

            if (!string.IsNullOrEmpty(friendlyName))
            {
                attribute = document.CreateAttribute(Constants.Xml.FRIENDLY_NAME);
                attribute.Value = friendlyName;
                element.Attributes.Append(attribute);
            }

            return element;
        }

        /// <summary>
        /// Fill drop-down list of assemblies in context menu
        /// </summary>
        /// <param name="selectedAssembly"></param>
        private void FillAssemblies(PluginAssembly selectedAssembly)
        {
            tscAssemblies.Items.Clear();

            foreach (var assembly in this.PluginAsseblies.Where(x => x.Id != selectedAssembly.Id))
            {
                tscAssemblies.Items.Add(assembly);
            }
        }

        /// <summary>
        /// Filling drop-down list of types in context menu
        /// </summary>
        /// <param name="pluginType"></param>
        private void FillTypes(PluginType pluginType = null)
        {
            tscTypes.Items.Clear();

            foreach (var type in (pluginType == null) ? this.PluginTypes : this.PluginTypes.Where(x => x.Id != pluginType.Id).ToArray())
            {
                tscTypes.Items.Add(type);
            }
        }

        private void lvSteps_SelectedIndexChanged(object sender, EventArgs e)
        {
            gbDestination.Enabled = (((ListView)sender).SelectedIndices.Count > 0) ? true : false;
        }

        private void MainControl_Enter(object sender, EventArgs e)
        {
            ExecuteMethod(RetrieveAssemblies);
        }

        private void removeSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvSteps.SelectedItems.Count > 0)
            {
                var result = MessageBox.Show("Confirmation", string.Format("Do you really want to delete {0} steps?", this.lvSteps.SelectedItems.Count), MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    var info = new WorkAsyncInfo();
                    info.Message = "Matching types in source and target assemblies...";

                    info.Work = (worker, a) =>
                    {
                        Invoke(new Action(() =>
                        {
                            foreach (var step in this.lvSteps.SelectedItems.Cast<ListViewItem>().Select<ListViewItem, Entity>(x => ((ProcessingStep)x.Tag).ToEntity()).ToArray())
                            {
                                this.Service.Delete(step.LogicalName, step.Id);
                            }
                        }));
                    };
                }
            }
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
            lvSteps.Items.Cast<ListViewItem>().ToList().ForEach(x => x.Selected = status);
            lvSteps.Items.Cast<ListViewItem>().ToList().ForEach(x => x.Checked = status);
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        private void tscAssemblies_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Resetting selection index ((ToolStripComboBox)sender).SelectedIndex = -1;
            ((ToolStripComboBox)sender).DroppedDown = false;

            var targetAssembly = (PluginAssembly)((ToolStripComboBox)sender).SelectedItem;

            var info = new WorkAsyncInfo();
            info.Message = "Matching types in source and target assemblies...";

            info.Work = (worker, a) =>
            {
                var hits = new MatchResult();

                var sourceTypes = this.PluginTypes.Select(x => x.ToEntity()).ToArray();
                var targetTypes = this.Service.GetPluginTypes(targetAssembly.Id);

                Invoke(new Action(() =>
                {
                    hits.StepsTotal = lvSteps.SelectedItems.Count;
                    foreach (var step in SelectedSteps.Select(x => x.ToEntity()).ToArray())
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
                                hits.StepUpdatedSuccessfully++;
                            }
                            catch (Exception)
                            {
                                // Failed to match
                                hits.StepFailedToUpdate++;
                            }
                        }
                        else
                        {
                            // Missing
                            hits.PluginMissing++;
                        }
                    }
                }));
                a.Result = hits;
            };

            info.PostWorkCallBack = (a) =>
            {
                Invoke(new Action(() =>
                {
                    var hits = (MatchResult)a.Result;
                    var text = string.Format(
@"Total number of steps processed: {0}
Number of steps updated successully: {1}
Number of steps failed to update: {2}
Number of missing types: {3}",
                      hits.StepsTotal,
                      hits.StepUpdatedSuccessfully,
                      hits.StepFailedToUpdate,
                      hits.PluginMissing);

                    MessageBox.Show(text, "Match & Update operation result");
                }));
            };

            WorkAsync(info);
        }

        private void tscTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var targetType = (PluginType)((ToolStripComboBox)sender).SelectedItem;

            var hits = new MatchResult();

            foreach (var step in SelectedSteps.Select(x => x.ToEntity()).ToArray())
            {
                if (targetType != null)
                {
                    step[Constants.Crm.Attributes.PLUGIN_TYPE_ID] = targetType.ToEntity().ToEntityReference();

                    step.Attributes.Remove("eventhandler");

                    try
                    {
                        Service.Update(step);
                        // Matched
                        hits.StepUpdatedSuccessfully++;
                    }
                    catch (Exception)
                    {
                        // Failed to match
                        hits.StepFailedToUpdate++;
                    }
                }
                else
                {
                    // Missing
                    hits.PluginMissing++;
                }
            }
        }

        #endregion Private Methods
    }
}