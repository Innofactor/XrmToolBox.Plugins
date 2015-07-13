namespace Cinteros.Xrm.DataUpdateTool
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Xml;
    using Cinteros.Xrm.DataUpdateTool.AppCode;
    using Cinteros.Xrm.DataUpdateTool.Forms;
    using Cinteros.Xrm.FetchXmlBuilder;
    using Cinteros.Xrm.XmlEditorUtils;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Messages;
    using Microsoft.Xrm.Sdk.Metadata;
    using Microsoft.Xrm.Sdk.Query;
    using XrmToolBox.Extensibility;
    using XrmToolBox.Extensibility.Interfaces;
    using XrmToolBox.Forms;

    public partial class DataUpdater : PluginControlBase, IGitHubPlugin, IPayPalPlugin, IMessageBusHost
    {
        const string settingfile = "Cinteros.Xrm.DataUpdater.Settings.xml";
        private static string fetchTemplate = "<fetch><entity name=\"\"/></fetch>";

        private string fetchXml = fetchTemplate;
        private EntityCollection records;
        private bool working = false;
        private static Dictionary<string, EntityMetadata> entities;
        internal List<string> entityShitList = new List<string>(); // Oops, did I name that one??
        internal static Dictionary<string, List<Entity>> views;
        private Entity view;
        internal static bool useFriendlyNames = false;
        private bool showAttributesAll = true;
        private bool showAttributesManaged = true;
        private bool showAttributesUnmanaged = true;
        private bool showAttributesCustomizable = true;
        private bool showAttributesUncustomizable = true;
        private bool showAttributesCustom = true;
        private bool showAttributesStandard = true;
        private bool showAttributesOnlyValidAF = true;
        private Dictionary<string, string> entityAttributes = new Dictionary<string, string>();

        public DataUpdater()
        {
            InitializeComponent();
        }

        #region interface implementation

        //public override void ClosingPlugin(XrmToolBox.PluginCloseInfo info)
        //{
        //    SaveSetting();
        //}

        public string RepositoryName
        {
            get { return "DataUpdater"; }
        }

        public string UserName
        {
            get { return "Cinteros"; }
        }

        public string DonationDescription
        {
            get { return "Donation to DataUpdater for XrmToolBox"; }
        }

        public string EmailAccount
        {
            get { return "jonas@rappen.net"; }
        }

        public event EventHandler<XrmToolBox.Extensibility.MessageBusEventArgs> OnOutgoingMessage;

        public void OnIncomingMessage(XrmToolBox.Extensibility.MessageBusEventArgs message)
        {
            if (message.SourcePlugin == "FetchXML Builder" &&
                message.TargetArgument != null &&
                message.TargetArgument is FXBMessageBusArgument)
            {
                var fxbArg = (FXBMessageBusArgument)message.TargetArgument;
                FetchUpdated(fxbArg.FetchXML);
            }
        }

        #endregion interface implementation

        #region Event handlers

        private void DataUpdater_Load(object sender, EventArgs e)
        {
            EnableControls(false);
            LoadSetting();
            var tasks = new List<Task>
            {
                this.LaunchVersionCheck("Cinteros", "XrmToolBox.Plugins", "http://cinteros.xrmtoolbox.com/?src=DBU.{0}")
            };
            tasks.ForEach(x => x.Start());
            EnableControls(true);
        }

        private void DataUpdater_ConnectionUpdated(object sender, XrmToolBox.Extensibility.PluginControlBase.ConnectionUpdatedEventArgs e)
        {
            entities = null;
            entityShitList.Clear();
            EnableControls(true);
        }

        private void tsbCloseThisTab_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        private void tsmiOpenFile_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void tsmiOpenView_Click(object sender, EventArgs e)
        {
            OpenView();
        }

        private void tsmiFriendly_Click(object sender, EventArgs e)
        {
            useFriendlyNames = tsmiFriendly.Checked;
            RefreshAttributes();
        }

        private void tsmiAttributes_Click(object sender, EventArgs e)
        {
            if (sender != tsmiAttributesAll)
            {
                tsmiAttributesAll.Checked =
                    tsmiAttributesManaged.Checked &&
                    tsmiAttributesUnmanaged.Checked &&
                    tsmiAttributesCustomizable.Checked &&
                    tsmiAttributesUncustomizable.Checked &&
                    tsmiAttributesCustom.Checked &&
                    tsmiAttributesStandard.Checked &&
                    !tsmiAttributesOnlyValidAF.Checked;
            }
            if (!tsmiAttributesManaged.Checked && !tsmiAttributesUnmanaged.Checked)
            {   // Neither managed nor unmanaged is not such a good idea...
                tsmiAttributesUnmanaged.Checked = true;
            }
            if (!tsmiAttributesCustomizable.Checked && !tsmiAttributesUncustomizable.Checked)
            {   // Neither customizable nor uncustomizable is not such a good idea...
                tsmiAttributesCustomizable.Checked = true;
            }
            if (!tsmiAttributesCustom.Checked && !tsmiAttributesStandard.Checked)
            {   // Neither custom nor standard is not such a good idea...
                tsmiAttributesCustom.Checked = true;
            }
            tsmiAttributesManaged.Enabled = !tsmiAttributesAll.Checked;
            tsmiAttributesUnmanaged.Enabled = !tsmiAttributesAll.Checked;
            tsmiAttributesCustomizable.Enabled = !tsmiAttributesAll.Checked;
            tsmiAttributesUncustomizable.Enabled = !tsmiAttributesAll.Checked;
            tsmiAttributesCustom.Enabled = !tsmiAttributesAll.Checked;
            tsmiAttributesStandard.Enabled = !tsmiAttributesAll.Checked;
            tsmiAttributesOnlyValidAF.Enabled = !tsmiAttributesAll.Checked;
            showAttributesAll = tsmiAttributesAll.Checked;
            showAttributesManaged = tsmiAttributesManaged.Checked;
            showAttributesUnmanaged = tsmiAttributesUnmanaged.Checked;
            showAttributesCustomizable = tsmiAttributesCustomizable.Checked;
            showAttributesUncustomizable = tsmiAttributesUncustomizable.Checked;
            showAttributesCustom = tsmiAttributesCustom.Checked;
            showAttributesStandard = tsmiAttributesStandard.Checked;
            showAttributesOnlyValidAF = tsmiAttributesOnlyValidAF.Checked;
            RefreshAttributes();
        }

        private void btnGetRecords_Click(object sender, EventArgs e)
        {
            GetRecords();
        }

        private void cmbAttribute_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateValueField();
        }

        private void cmbAttribute_TextChanged(object sender, EventArgs e)
        {
            EnableControls(true);
        }

        private void rbSet_CheckedChanged(object sender, EventArgs e)
        {
            cmbValue.Enabled = rbSetValue.Checked;
            chkOnlyChange.Enabled = !rbSetTouch.Checked;
            if (rbSetTouch.Checked)
            {
                chkOnlyChange.Checked = false;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateRecords();
        }

        private void tsbAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Data Updater for XrmToolBox\n" +
                "Version: " + Assembly.GetExecutingAssembly().GetName().Version + "\n\n" +
                "Developed by Jonas Rapp at Cinteros AB.",
                "About Data Updater", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion Event handlers

        #region Methods

        private void SaveSetting()
        {
            var map = new ExeConfigurationFileMap { ExeConfigFilename = settingfile };
            System.Configuration.Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            config.AppSettings.Settings.Clear();
            if (!string.IsNullOrWhiteSpace(fetchXml))
            {
                config.AppSettings.Settings.Add("FetchXML", fetchXml);
            }
            if (entityAttributes != null && entityAttributes.Count > 0)
            {
                var entattrstr = "";
                foreach (var entattr in entityAttributes)
                {
                    entattrstr += entattr.Key + ":" + entattr.Value + "|";
                }
                config.AppSettings.Settings.Add("EntityAttributes", entattrstr);
            }
            SaveControlValue(config, tsmiFriendly);
            SaveControlValue(config, tsmiAttributesManaged);
            SaveControlValue(config, tsmiAttributesUnmanaged);
            SaveControlValue(config, tsmiAttributesCustomizable);
            SaveControlValue(config, tsmiAttributesUncustomizable);
            SaveControlValue(config, tsmiAttributesCustom);
            SaveControlValue(config, tsmiAttributesStandard);
            SaveControlValue(config, tsmiAttributesOnlyValidAF);
            config.Save();
        }

        private void LoadSetting()
        {
            var map = new ExeConfigurationFileMap { ExeConfigFilename = settingfile };
            System.Configuration.Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            if (config.AppSettings.Settings["FetchXML"] != null)
            {
                fetchXml = config.AppSettings.Settings["FetchXML"].Value;
            }
            if (config.AppSettings.Settings["EntityAttributes"] != null)
            {
                var entattrstr = config.AppSettings.Settings["EntityAttributes"].Value;
                foreach (var entattr in entattrstr.Split('|'))
                {
                    if (!string.IsNullOrEmpty(entattr) && entattr.Contains(':'))
                    {
                        var entity = entattr.Split(':')[0];
                        var attr = entattr.Split(':')[1];
                        entityAttributes.Add(entity, attr);
                    }
                }
            }
            LoadControlValue(config, tsmiFriendly);
            LoadControlValue(config, tsmiAttributesManaged);
            LoadControlValue(config, tsmiAttributesUnmanaged);
            LoadControlValue(config, tsmiAttributesCustomizable);
            LoadControlValue(config, tsmiAttributesUncustomizable);
            LoadControlValue(config, tsmiAttributesCustom);
            LoadControlValue(config, tsmiAttributesStandard);
            LoadControlValue(config, tsmiAttributesOnlyValidAF);
            tsmiFriendly_Click(null, null);
            tsmiAttributes_Click(null, null);
        }

        private void SaveControlValue(Configuration config, object control)
        {
            if (control is ToolStripMenuItem)
            {
                config.AppSettings.Settings.Add(((ToolStripMenuItem)control).Name, ((ToolStripMenuItem)control).Checked ? "1" : "0");
            }
            else if (control is ToolStripComboBox)
            {
                config.AppSettings.Settings.Add(((ToolStripComboBox)control).Name, ((ToolStripComboBox)control).SelectedIndex.ToString());
            }
        }

        private void LoadControlValue(Configuration config, object control)
        {
            if (control is ToolStripMenuItem)
            {
                var name = ((ToolStripMenuItem)control).Name;
                if (config.AppSettings.Settings[name] != null)
                {
                    ((ToolStripMenuItem)control).Checked = config.AppSettings.Settings[name].Value == "1";
                }
            }
            else if (control is ToolStripComboBox)
            {
                var name = ((ToolStripComboBox)control).Name;
                if (config.AppSettings.Settings[name] != null)
                {
                    var index = 0;
                    if (int.TryParse(config.AppSettings.Settings[name].Value, out index) && ((ToolStripComboBox)control).Items.Count > index)
                    {
                        ((ToolStripComboBox)control).SelectedIndex = index;
                    }
                }
            }
        }

        private void EnableControls(bool enabled)
        {
            MethodInvoker mi = delegate
            {
                try
                {
                    gb1select.Enabled = enabled && Service != null;
                    gb2attribute.Enabled = gb1select.Enabled && records != null && records.Entities.Count > 0;
                    gb3value.Enabled = gb2attribute.Enabled && cmbAttribute.SelectedItem is AttributeItem;
                    gb4update.Enabled = gb3value.Enabled;
                }
                catch
                {
                    // Now what?
                }
            };
            if (InvokeRequired)
            {
                Invoke(mi);
            }
            else
            {
                mi();
            }
        }

        private string OpenFile()
        {
            var result = "";
            var ofd = new OpenFileDialog
            {
                Title = "Select an XML file containing FetchXML",
                Filter = "XML file (*.xml)|*.xml"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                EnableControls(false);
                var fetchDoc = new XmlDocument();
                fetchDoc.Load(ofd.FileName);

                if (fetchDoc.DocumentElement.Name != "fetch" ||
                    fetchDoc.DocumentElement.ChildNodes.Count > 0 &&
                    fetchDoc.DocumentElement.ChildNodes[0].Name == "fetch")
                {
                    MessageBox.Show(this, "Invalid Xml: Definition XML root must be fetch!", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    result = fetchDoc.OuterXml;
                    EnableControls(true);
                }
            }
            return result;
        }

        private void OpenView()
        {
            EnableControls(false);
            if (views == null || views.Count == 0)
            {
                LoadViews(OpenView);
                return;
            }
            var viewselector = new SelectViewDialog(this);
            viewselector.StartPosition = FormStartPosition.CenterParent;
            if (viewselector.ShowDialog() == DialogResult.OK)
            {
                view = viewselector.View;
                var fetchDoc = new XmlDocument();
                if (view.Contains("fetchxml"))
                {
                    fetchDoc.LoadXml(view["fetchxml"].ToString());
                    FetchUpdated(fetchDoc.OuterXml);
                }
            }
            EnableControls(true);
        }

        private void GetRecords()
        {
            switch (cmbSource.SelectedIndex)
            {
                case 0: // Edit
                    GetFromEditor();
                    break;
                case 1: // FXB
                    try
                    {
                        GetFromFXB();
                    }
                    catch (System.IO.FileNotFoundException)
                    {
                        if (MessageBox.Show("FetchXML Builder is not installed.\nDownload latest version from\n\nhttp://fxb.xrmtoolbox.com", "FetchXML Builder",
                            MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                        {
                            DownloadFXB();
                        }
                    }
                    catch (PluginNotFoundException)
                    {
                        if (MessageBox.Show("FetchXML Builder was not found.\nDownload latest version from\n\nhttp://fxb.xrmtoolbox.com", "FetchXML Builder",
                            MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                        {
                            DownloadFXB();
                        }
                    }
                    break;
                case 2: // File
                    FetchUpdated(OpenFile());
                    break;
                case 3: // View
                    OpenView();
                    break;
                default:
                    MessageBox.Show("Select record source.", "Get Records", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
            }
        }

        private void GetFromEditor()
        {
            var fetchwin = new XmlContentDisplayDialog(fetchXml, "Enter FetchXML to retrieve records to update", true, true);
            fetchwin.StartPosition = FormStartPosition.CenterParent;
            if (fetchwin.ShowDialog() == DialogResult.OK)
            {
                FetchUpdated(fetchwin.txtXML.Text);
            }
        }

        private void GetFromFXB()
        {
            var messageBusEventArgs = new MessageBusEventArgs("FetchXML Builder");
            var fXBMessageBusArgument = new FXBMessageBusArgument(FXBMessageBusRequest.FetchXML)
            {
                FetchXML = fetchXml
            };
            messageBusEventArgs.TargetArgument = fXBMessageBusArgument;
            OnOutgoingMessage(this, messageBusEventArgs);
        }

        private void FetchUpdated(string fetch)
        {
            if (!string.IsNullOrWhiteSpace(fetch))
            {
                fetchXml = fetch;
                RetrieveRecords(fetchXml, RetrieveRecordsReady);
            }
        }

        private void RetrieveRecordsReady()
        {
            if (records != null)
            {
                lblRecords.Text = records.Entities.Count.ToString() + " records of entity " + records.EntityName;
            }
            RefreshAttributes();
        }

        private bool NeedToLoadEntity(string entityName)
        {
            return
                !string.IsNullOrEmpty(entityName) &&
                !entityShitList.Contains(entityName) &&
                Service != null &&
                (entities == null ||
                 !entities.ContainsKey(entityName) ||
                 entities[entityName].Attributes == null);
        }

        private void RefreshAttributes()
        {
            EnableControls(false);
            cmbAttribute.Items.Clear();
            if (records != null)
            {
                var entityName = records.EntityName;
                if (NeedToLoadEntity(entityName))
                {
                    if (!working)
                    {
                        LoadEntityDetails(entityName, RefreshAttributes);
                    }
                    return;
                }
                var attributes = GetDisplayAttributes(entityName);
                foreach (var attribute in attributes)
                {
                    AttributeItem.AddAttributeToComboBox(cmbAttribute, attribute, true);
                }
                if (entityAttributes.ContainsKey(records.EntityName))
                {
                    var attr = entityAttributes[records.EntityName];
                    var coll = new Dictionary<string, string>();
                    coll.Add("attribute", attr);
                    ControlUtils.FillControl(coll, cmbAttribute);
                }
            }
            EnableControls(true);
        }

        internal static Dictionary<string, EntityMetadata> GetDisplayEntities()
        {
            var result = new Dictionary<string, EntityMetadata>();
            if (entities != null)
            {
                foreach (var entity in entities)
                {
                    //if (!showEntitiesAll)
                    //{
                    //    if (!showEntitiesManaged && entity.Value.IsManaged == true) { continue; }
                    //    if (!showEntitiesUnmanaged && entity.Value.IsManaged == false) { continue; }
                    //    if (!showEntitiesCustomizable && entity.Value.IsCustomizable.Value) { continue; }
                    //    if (!showEntitiesUncustomizable && !entity.Value.IsCustomizable.Value) { continue; }
                    //    if (!showEntitiesStandard && entity.Value.IsCustomEntity == false) { continue; }
                    //    if (!showEntitiesCustom && entity.Value.IsCustomEntity == true) { continue; }
                    //    if (!showEntitiesIntersect && entity.Value.IsIntersect == true) { continue; }
                    //    if (showEntitiesOnlyValidAF && entity.Value.IsValidForAdvancedFind == false) { continue; }
                    //}
                    result.Add(entity.Key, entity.Value);
                }
            }
            return result;
        }

        private AttributeMetadata[] GetDisplayAttributes(string entityName)
        {
            var result = new List<AttributeMetadata>();
            AttributeMetadata[] attributes = null;
            if (entities != null && entities.ContainsKey(entityName))
            {
                attributes = entities[entityName].Attributes;
                if (attributes != null)
                {
                    foreach (var attribute in attributes)
                    {
                        if (!showAttributesAll)
                        {
                            if (!string.IsNullOrEmpty(attribute.AttributeOf)) { continue; }
                            if (!showAttributesManaged && attribute.IsManaged == true) { continue; }
                            if (!showAttributesUnmanaged && attribute.IsManaged == false) { continue; }
                            if (!showAttributesCustomizable && attribute.IsCustomizable.Value) { continue; }
                            if (!showAttributesUncustomizable && !attribute.IsCustomizable.Value) { continue; }
                            if (!showAttributesStandard && attribute.IsCustomAttribute == false) { continue; }
                            if (!showAttributesCustom && attribute.IsCustomAttribute == true) { continue; }
                            if (showAttributesOnlyValidAF && attribute.IsValidForAdvancedFind.Value == false) { continue; }
                        }
                        result.Add(attribute);
                    }
                }
            }
            return result.ToArray();
        }

        internal static string GetEntityDisplayName(string entityName)
        {
            if (!useFriendlyNames)
            {
                return entityName;
            }
            if (entities != null && entities.ContainsKey(entityName))
            {
                entityName = GetEntityDisplayName(entities[entityName]);
            }
            return entityName;
        }

        internal static string GetEntityDisplayName(EntityMetadata entity)
        {
            var result = entity.LogicalName;
            if (useFriendlyNames)
            {
                if (entity.DisplayName.UserLocalizedLabel != null)
                {
                    result = entity.DisplayName.UserLocalizedLabel.Label;
                }
                if (result == entity.LogicalName && entity.DisplayName.LocalizedLabels.Count > 0)
                {
                    result = entity.DisplayName.LocalizedLabels[0].Label;
                }
            }
            return result;
        }

        internal static string GetAttributeDisplayName(AttributeMetadata attribute)
        {
            string attributeName = attribute.LogicalName;
            if (useFriendlyNames)
            {
                if (attribute.DisplayName.UserLocalizedLabel != null)
                {
                    attributeName = attribute.DisplayName.UserLocalizedLabel.Label;
                }
                if (attributeName == attribute.LogicalName && attribute.DisplayName.LocalizedLabels.Count > 0)
                {
                    attributeName = attribute.DisplayName.LocalizedLabels[0].Label;
                }
                attributeName += " (" + attribute.LogicalName + ")";
            }
            return attributeName;
        }

        private bool ValuesEqual(object value1, object value2)
        {
            if (value1 != null && value2 != null)
            {
                if (value1 is OptionSetValue && value2 is OptionSetValue)
                {
                    return ((OptionSetValue)value1).Value == ((OptionSetValue)value2).Value;
                }
                else
                {
                    return value1.ToString().Equals(value2.ToString());
                }
            }
            else
            {
                return value1 == null && value2 == null;
            }
        }

        private object GetValue(AttributeTypeCode? type)
        {
            switch (type)
            {
                case AttributeTypeCode.String:
                case AttributeTypeCode.Memo:
                    return cmbValue.Text;
                    break;
                case AttributeTypeCode.BigInt:
                case AttributeTypeCode.Integer:
                    return int.Parse(cmbValue.Text);
                    break;
                case AttributeTypeCode.Picklist:
                case AttributeTypeCode.State:
                case AttributeTypeCode.Status:
                    var value = ((OptionsetItem)cmbValue.SelectedItem).meta.Value;
                    return new OptionSetValue((int)value);
                    break;
                default:
                    throw new Exception("Attribute of type " + type.ToString() + " is currently not supported.");
            }
        }

        private void UpdateValueField()
        {
            var attribute = (AttributeItem)cmbAttribute.SelectedItem;
            if (attribute != null)
            {
                if (attribute.Metadata is EnumAttributeMetadata)
                {
                    var options = ((EnumAttributeMetadata)attribute.Metadata).OptionSet;
                    if (options != null)
                    {
                        foreach (var option in options.Options)
                        {
                            cmbValue.Items.Add(new OptionsetItem(option));
                        }
                    }
                    cmbValue.DropDownStyle = ComboBoxStyle.DropDownList;
                }
                else
                {
                    cmbValue.Items.Clear();
                    cmbValue.DropDownStyle = ComboBoxStyle.Simple;
                }
                if (entityAttributes.ContainsKey(records.EntityName))
                {
                    entityAttributes[records.EntityName] = attribute.GetValue();
                }
                else
                {
                    entityAttributes.Add(records.EntityName, attribute.GetValue());
                }
            }
            EnableControls(true);
        }

        private Task LaunchVersionCheck(string ghUser, string ghRepo, string dlUrl)
        {
            return new Task(() =>
            {
                var currentVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                var cvc = new XrmToolBox.AppCode.GithubVersionChecker(currentVersion, ghUser, ghRepo);

                cvc.Run();

                if (cvc.Cpi != null && !string.IsNullOrEmpty(cvc.Cpi.Version))
                {
                    this.Invoke(new Action(() =>
                    {
                        var nvForm = new NewVersionForm(currentVersion, cvc.Cpi.Version, cvc.Cpi.Description, ghUser, ghRepo, new Uri(string.Format(dlUrl, currentVersion)));
                        nvForm.ShowDialog(this);
                    }));
                }
            });
        }

        internal static void DownloadFXB()
        {
            var currentVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            System.Diagnostics.Process.Start("http://fxb.xrmtoolbox.com/?src=DBU." + currentVersion);
        }

        #endregion Methods

        #region Async SDK methods

        internal void LoadViews(Action viewsLoaded)
        {
            if (working)
            {
                return;
            }
            if (entities == null || entities.Count == 0)
            {
                LoadEntities(viewsLoaded);
                return;
            }
            working = true;
            WorkAsync("Loading views...",
                (bgworker, workargs) =>
                {
                    EnableControls(false);
                    if (views == null || views.Count == 0)
                    {
                        if (Service == null)
                        {
                            throw new Exception("Need a connection to load views.");
                        }
                        var qex = new QueryExpression("savedquery");
                        qex.ColumnSet = new ColumnSet("name", "returnedtypecode", "fetchxml");
                        qex.Criteria.AddCondition("statecode", ConditionOperator.Equal, 0);
                        qex.Criteria.AddCondition("querytype", ConditionOperator.In, 0, 32);
                        qex.AddOrder("name", OrderType.Ascending);
                        bgworker.ReportProgress(33, "Loading system views...");
                        var sysviews = Service.RetrieveMultiple(qex);
                        foreach (var view in sysviews.Entities)
                        {
                            var entityname = view["returnedtypecode"].ToString();
                            if (!string.IsNullOrWhiteSpace(entityname) && entities.ContainsKey(entityname))
                            {
                                if (views == null)
                                {
                                    views = new Dictionary<string, List<Entity>>();
                                }
                                if (!views.ContainsKey(entityname + "|S"))
                                {
                                    views.Add(entityname + "|S", new List<Entity>());
                                }
                                views[entityname + "|S"].Add(view);
                            }
                        }
                        qex.EntityName = "userquery";
                        bgworker.ReportProgress(66, "Loading user views...");
                        var userviews = Service.RetrieveMultiple(qex);
                        foreach (var view in userviews.Entities)
                        {
                            var entityname = view["returnedtypecode"].ToString();
                            if (!string.IsNullOrWhiteSpace(entityname) && entities.ContainsKey(entityname))
                            {
                                if (views == null)
                                {
                                    views = new Dictionary<string, List<Entity>>();
                                }
                                if (!views.ContainsKey(entityname + "|U"))
                                {
                                    views.Add(entityname + "|U", new List<Entity>());
                                }
                                views[entityname + "|U"].Add(view);
                            }
                        }
                        bgworker.ReportProgress(100, "Finalizing...");
                    }
                },
                (completedargs) =>
                {
                    working = false;
                    EnableControls(true);
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
                    SetWorkingMessage(changeargs.UserState.ToString());
                });
        }

        private void LoadEntities(Action AfterLoad)
        {
            if (working)
            {
                return;
            }
            entities = null;
            entityShitList = new List<string>();
            working = true;
            WorkAsync("Loading entities metadata...",
                (eventargs) =>
                {
                    EnableControls(false);
                    var req = new RetrieveAllEntitiesRequest()
                    {
                        EntityFilters = EntityFilters.Entity,
                        RetrieveAsIfPublished = true
                    };
                    eventargs.Result = Service.Execute(req);
                },
                (completedargs) =>
                {
                    working = false;
                    if (completedargs.Error != null)
                    {
                        MessageBox.Show(completedargs.Error.Message);
                    }
                    else
                    {
                        if (completedargs.Result is RetrieveAllEntitiesResponse)
                        {
                            entities = new Dictionary<string, EntityMetadata>();
                            foreach (var entity in ((RetrieveAllEntitiesResponse)completedargs.Result).EntityMetadata)
                            {
                                entities.Add(entity.LogicalName, entity);
                            }
                        }
                    }
                    EnableControls(true);
                    if (AfterLoad != null)
                    {
                        AfterLoad();
                    }
                });
        }

        private void LoadEntityDetails(string entityName, Action detailsLoaded)
        {
            if (working)
            {
                return;
            }
            working = true;
            WorkAsync("Loading " + GetEntityDisplayName(entityName) + " metadata...",
                (eventargs) =>
                {
                    var req = new RetrieveEntityRequest()
                    {
                        LogicalName = entityName,
                        EntityFilters = EntityFilters.Attributes | EntityFilters.Relationships,
                        RetrieveAsIfPublished = true
                    };
                    eventargs.Result = Service.Execute(req);
                },
                (completedargs) =>
                {
                    working = false;
                    if (completedargs.Error != null)
                    {
                        entityShitList.Add(entityName);
                        MessageBox.Show(completedargs.Error.Message, "Load attribute metadata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (completedargs.Result is RetrieveEntityResponse)
                        {
                            var resp = (RetrieveEntityResponse)completedargs.Result;
                            if (entities == null)
                            {
                                entities = new Dictionary<string, EntityMetadata>();
                            }
                            if (entities.ContainsKey(entityName))
                            {
                                entities[entityName] = resp.EntityMetadata;
                            }
                            else
                            {
                                entities.Add(entityName, resp.EntityMetadata);
                            }
                        }
                        detailsLoaded();
                    }
                    working = false;
                });
        }

        private void RetrieveRecords(string fetch, Action AfterRetrieve)
        {
            if (working)
            {
                return;
            }
            lblRecords.Text = "Retrieving records...";
            records = null;
            working = true;
            WorkAsync("Retrieving records...",
                (eventargs) =>
                {
                    eventargs.Result = Service.RetrieveMultiple(new FetchExpression(fetch));
                },
                (completedargs) =>
                {
                    working = false;
                    if (completedargs.Error != null)
                    {
                        MessageBox.Show(completedargs.Error.Message, "Retrieve Records", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (completedargs.Result is EntityCollection)
                    {
                        records = (EntityCollection)completedargs.Result;
                    }
                    AfterRetrieve();
                });
        }

        private void UpdateRecords()
        {
            if (working)
            {
                return;
            }
            if (!(cmbAttribute.SelectedItem is AttributeItem))
            {
                MessageBox.Show("Select an attribute to update from the list.");
                return;
            }
            if (MessageBox.Show("All selected records will unconditionally be updated.\nUI defined rules will not be enforced.\n\nConfirm update!",
                "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) != DialogResult.OK)
            {
                return;
            }
            var attributeitem = (AttributeItem)cmbAttribute.SelectedItem;
            var onlychange = chkOnlyChange.Checked;
            var entity = records.EntityName;
            var attribute = attributeitem.GetValue();
            var touch = rbSetTouch.Checked;
            var value = rbSetValue.Checked ? GetValue(attributeitem.Metadata.AttributeType) : null;
            working = true;
            WorkAsync("Updating records",
                (bgworker, workargs) =>
                {
                    var total = records.Entities.Count;
                    var current = 0;
                    var updated = 0;
                    foreach (var record in records.Entities)
                    {
                        current++;
                        var pct = 100 * current / total;
                        if (onlychange && !record.Contains(attribute))
                        {
                            bgworker.ReportProgress(pct, "Reloading record " + current.ToString());
                            var newrecord = Service.Retrieve(entity, record.Id, new ColumnSet(attribute));
                            if (newrecord.Contains(attribute))
                            {
                                record.Attributes.Add(attribute, newrecord[attribute]);
                            }
                        }
                        bgworker.ReportProgress(pct, "Updating record " + current.ToString());
                        var currentvalue = record.Contains(attribute) ? record[attribute] : null;
                        var updaterecord = new Entity(entity);
                        updaterecord.Id = record.Id;
                        if (touch)
                        {
                            value = currentvalue;
                        }
                        if (!onlychange || !ValuesEqual(value, currentvalue))
                        {
                            updaterecord.Attributes.Add(attribute, value);
                            Service.Update(updaterecord);
                            if (record.Contains(attribute))
                            {
                                record[attribute] = value;
                            }
                            else
                            {
                                record.Attributes.Add(attribute, value);
                            }
                            updated++;
                        }
                    }
                    workargs.Result = updated;
                },
                (completedargs) =>
                {
                    working = false;
                    if (completedargs.Error != null)
                    {
                        MessageBox.Show(completedargs.Error.Message, "Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        lblUpdateStatus.Text = completedargs.Result.ToString() + " records updated";
                    }
                },
                (changeargs) =>
                {
                    SetWorkingMessage(changeargs.UserState.ToString());
                });
        }

        #endregion Async SDK methods
    }
}
