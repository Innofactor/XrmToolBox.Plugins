using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cinteros.Xrm.DataUpdater.Forms;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using Cinteros.Xrm.XmlEditorUtils;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Cinteros.Xrm.DataUpdater.AppCode;
using System.Configuration;
using System.Reflection;

namespace Cinteros.Xrm.DataUpdater
{
    public partial class DataUpdater : XrmToolBox.PluginBase, XrmToolBox.IGitHubPlugin, XrmToolBox.IPayPalPlugin
    {
        const string settingfile = "Cinteros.Xrm.DataUpdater.Settings.xml";
        private static string fetchTemplate = "<fetch><entity name=\"\"/></fetch>";

        private string fetchXml = fetchTemplate;
        private EntityCollection records;
        private bool working = false;
        private static Dictionary<string, EntityMetadata> entities;
        internal static List<string> entityShitList = new List<string>(); // Oops, did I name that one??
        internal static bool useFriendlyNames = false;
        private static bool showAttributesAll = true;
        private static bool showAttributesManaged = true;
        private static bool showAttributesUnmanaged = true;
        private static bool showAttributesCustomizable = true;
        private static bool showAttributesUncustomizable = true;
        private static bool showAttributesCustom = true;
        private static bool showAttributesStandard = true;
        private static bool showAttributesOnlyValidAF = true;

        public DataUpdater()
        {
            InitializeComponent();
        }

        #region interface implementation

        public override Image PluginLogo
        {
            get
            {
                return imageList1.Images[0];
            }
        }

        public override void ClosingPlugin(XrmToolBox.PluginCloseInfo info)
        {
            SaveSetting();
        }

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

        #endregion interface implementation

        #region Event handlers

        private void DataUpdater_Load(object sender, EventArgs e)
        {
            LoadSetting();
        }

        private void DataUpdater_ConnectionUpdated(object sender, ConnectionUpdatedEventArgs e)
        {
            entities = null;
            entityShitList.Clear();
            EnableControls(true);
        }

        private void tsbCloseThisTab_Click(object sender, EventArgs e)
        {
            CloseTool();
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
            LoadControlValue(config, tsmiAttributesManaged);
            LoadControlValue(config, tsmiAttributesUnmanaged);
            LoadControlValue(config, tsmiAttributesCustomizable);
            LoadControlValue(config, tsmiAttributesUncustomizable);
            LoadControlValue(config, tsmiAttributesCustom);
            LoadControlValue(config, tsmiAttributesStandard);
            LoadControlValue(config, tsmiAttributesOnlyValidAF);
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
            btnGetRecords.Enabled = enabled && Service != null;
        }

        private void GetRecords()
        {
            var fetchwin = new XmlContentDisplayDialog(fetchXml, "Enter FetchXML to retrieve records to update", true, true);
            if (fetchwin.ShowDialog() == DialogResult.OK)
            {
                fetchXml = fetchwin.txtXML.Text;
                RetrieveRecords(fetchXml, RetrieveRecordsReady);
            }
        }

        private void RetrieveRecords(string fetch, Action AfterRetrieve)
        {
            if (working)
            {
                return;
            }
            lblRecords.Text = "Loading records...";
            records = null;
            WorkAsync("Retrieving records...",
                (eventargs) =>
                {
                    eventargs.Result = Service.RetrieveMultiple(new FetchExpression(fetch));
                },
                (completedargs) =>
                {
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
            }
        }

        private void LoadEntityDetails(string entityName, Action detailsLoaded)
        {
            working = true;
            WorkAsync("Loading " + entityName + "...",
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
                        working = false;
                        detailsLoaded();
                    }
                    working = false;
                });
        }

        private static AttributeMetadata[] GetDisplayAttributes(string entityName)
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

        internal static string GetAttributeDisplayName(AttributeMetadata attribute)
        {
            string attributeName = attribute.LogicalName;
            if (useFriendlyNames)
            {
                if (attribute.DisplayName.UserLocalizedLabel != null)
                {
                    attributeName = attribute.DisplayName.UserLocalizedLabel.Label;
                }
                //else
                //{
                //    foreach (var label in attribute.DisplayName.LocalizedLabels)
                //    {
                //        if (label.LanguageCode == userLCID)
                //        {
                //            attributeName = label.Label;
                //            break;
                //        }
                //    }
                //}
                if (attributeName == attribute.LogicalName && attribute.DisplayName.LocalizedLabels.Count > 0)
                {
                    attributeName = attribute.DisplayName.LocalizedLabels[0].Label;
                }
            }
            return attributeName;
        }

        private void UpdateRecords()
        {
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
                        if (!onlychange || !value.ToString().Equals(currentvalue.ToString()))
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
                    var value = ((OptionsetItem)cmbValue.SelectedValue).meta.Value;
                    return new OptionSetValue((int)value);
                    break;
                default:
                    throw new Exception("Attribute of type " + type.ToString() + " is currently not supported.");
            }
        }

        private void UpdateValueField()
        {
            var attribute = (AttributeItem)cmbAttribute.SelectedValue;
            if (attribute == null)
            {
                return;
            }
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
        }

        #endregion Methods
    }
}
