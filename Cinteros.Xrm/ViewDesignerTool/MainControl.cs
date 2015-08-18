namespace Cinteros.Xrm.ViewDesignerTool
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using Cinteros.Xrm.Common.Forms;
    using Cinteros.Xrm.FetchXmlBuilder;
    using Cinteros.Xrm.ViewDesignerTool.Controls;
    using Microsoft.Crm.Sdk.Messages;
    using Microsoft.Xrm.Sdk;
    using XrmToolBox.Extensibility;
    using XrmToolBox.Extensibility.Interfaces;
    using System.Collections.Generic;
    using Cinteros.Xrm.XmlEditorUtils;
    using System.Threading.Tasks;
    using System.Reflection;

    public partial class MainControl : PluginControlBase, IGitHubPlugin, IMessageBusHost
    {
        #region Private Fields

        private Control control;

        #endregion Private Fields

        #region Public Constructors

        public MainControl()
        {
            InitializeComponent();
        }

        #endregion Public Constructors

        #region Public Events

        public event EventHandler<MessageBusEventArgs> OnOutgoingMessage;

        #endregion Public Events

        #region Public Properties

        /// <summary>
        /// Gets or sets control, that would be seen as current page
        /// </summary>
        public Control CurrentPage
        {
            get
            {
                return this.control;
            }
            set
            {
                value.Size = this.Size;
                value.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;

                this.Controls.Remove(this.control);
                this.Controls.Add(value);

                this.control = value;
            }
        }

        string IGitHubPlugin.RepositoryName
        {
            get
            {
                return "XrmToolBox.Plugins";
            }
        }

        string IGitHubPlugin.UserName
        {
            get
            {
                return "Cinteros";
            }
        }

        #endregion Public Properties

        #region Public Methods

        public void OnIncomingMessage(MessageBusEventArgs message)
        {
            if (message.SourcePlugin == "FetchXML Builder" &&
                message.TargetArgument != null &&
                message.TargetArgument is FXBMessageBusArgument)
            {
                var fxbArg = (FXBMessageBusArgument)message.TargetArgument;
                UpdateFetch(fxbArg.FetchXML);
            }
        }

        #endregion Public Methods

        #region Private Methods

        private void MainControl_Load(object sender, EventArgs e)
        {
            if (sender != null)
            {
                if (sender is MainControl)
                {
                    var plugin = ((MainControl)sender);
                    // In case if connection updated on main application, update assemblies list
                    // inside the plugin plugin.ConnectionUpdated += MainControl_ConnectionUpdated;

                    // this.ExecuteMethod(this.RetrieveViews);

                    //if (plugin.Service != null)
                    //{
                    //    // Execute assemblies retrieve only if Service object is set for correct sender.
                    //    // This will help plugin act predicatable when it was loaded in offline mode;
                    //    // Plugin will not insist on connecting to server. Will scinetly obey instead.
                    //    this.ExecuteMethod(this.RetrieveViews);
                    //}
                }

                //this.ExecuteMethod(() =>
                //    {
                //        this.CurrentPage = new ViewEditor();
                //    });
            }
            DateTime lastCheck = DateTime.MinValue;
            var tasks = new List<Task>
            {
                VersionCheck.LaunchVersionCheck(Assembly.GetExecutingAssembly().GetName().Version.ToString(), "Cinteros", "XrmToolBox.Plugins", "http://cinteros.xrmtoolbox.com/?src=FXB.{0}", lastCheck, this),
            };
            tasks.ForEach(x => x.Start());
            lastCheck = DateTime.Now;
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.CloseTool();
        }

        private void tsbEditFetch_Click(object sender, EventArgs e)
        {
            if (this.Service == null)
            {
                MessageBox.Show("Please connect to CRM.", "Edit query", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Entity view = ViewEditor != null ? ViewEditor.ToEntity() : null;
            if (view == null || string.IsNullOrEmpty(view.LogicalName))
            {
                MessageBox.Show("First select a view to design.", "Edit query", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var messageBusEventArgs = new MessageBusEventArgs("FetchXML Builder");
            var fXBMessageBusArgument = new FXBMessageBusArgument(FXBMessageBusRequest.FetchXML);
            if (ViewEditor != null && ViewEditor.FetchXml != null && ViewEditor.FetchXml.OuterXml != null)
            {
                fXBMessageBusArgument.FetchXML = ViewEditor.FetchXml.OuterXml;
            }
            messageBusEventArgs.TargetArgument = fXBMessageBusArgument;
            try
            {
                OnOutgoingMessage(this, messageBusEventArgs);
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
        }

        internal static void DownloadFXB()
        {
            var currentVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            System.Diagnostics.Process.Start("http://fxb.xrmtoolbox.com/?src=VD." + currentVersion);
        }

        private void tsbOpen_Click(object sender, EventArgs e)
        {
            if (this.Service == null)
            {
                MessageBox.Show("Please connect to CRM.", "Open", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var select = new SelectViewDialog(this);
            select.StartPosition = FormStartPosition.CenterParent;
            if (select.ShowDialog() == DialogResult.OK)
            {
                tsbSnap.Checked = true;

                ViewEditor.Enabled = true;
                ViewEditor.Set(select.View);
                tsbSnap.Checked = ViewEditor.Snapped;
            }
        }

        private void tsbPublish_Click(object sender, EventArgs e)
        {
            if (this.Service == null)
            {
                MessageBox.Show("Please connect to CRM.", "Publish", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string entity = ViewEditor != null ? ViewEditor.ViewEntityName : null;
            if (string.IsNullOrEmpty(entity))
            {
                MessageBox.Show("First select a view to design.", "Publish", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.WorkAsync("Publishing changes",
                a =>
                {
                    var pubRequest = new PublishXmlRequest();
                    pubRequest.ParameterXml = string.Format("<importexportxml><entities><entity>{0}</entity></entities><nodes/><securityroles/><settings/><workflows/></importexportxml>", entity);
                    this.Service.Execute(pubRequest);
                },
                a =>
                {
                    if (a.Error != null)
                    {
                        MessageBox.Show(a.Error.Message, "Publish", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                });
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            if (this.Service == null)
            {
                MessageBox.Show("Please connect to CRM.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Entity view = ViewEditor != null ? ViewEditor.ToEntity() : null;
            if (view == null || string.IsNullOrEmpty(view.LogicalName))
            {
                MessageBox.Show("First select a view to design.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.WorkAsync("Saving changes",
                a =>
                {
                    this.Service.Update(view);
                },
                a =>
                {
                    if (a.Error != null)
                    {
                        MessageBox.Show(a.Error.Message, "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                });
        }

        private void tsbSnap_Click(object sender, EventArgs e)
        {
            ViewEditor.Snap(((ToolStripButton)sender).Checked);
        }

        private void UpdateFetch(string fetchxml)
        {
            ViewEditor.FetchXml.LoadXml(fetchxml);
            ViewEditor.IsFetchXmlChanged = true;
        }

        #endregion Private Methods

        private void tsbEditColumns_Click(object sender, EventArgs e)
        {
            if (ViewEditor == null || ViewEditor.FetchXml == null)
            {
                MessageBox.Show("First select a view to design.", "Columns", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var select = new SelectColumnsDialog(ViewEditor.FetchXml, ViewEditor.LayoutXml);
            select.StartPosition = FormStartPosition.CenterParent;
            if (select.ShowDialog() == DialogResult.OK)
            {
                var entity = new Entity();
                entity.Attributes.Add("layoutxml", select.LayoutXml.OuterXml);

                //tsbSnap.Checked = true;

                ViewEditor.Set(entity);
                ViewEditor.IsLayoutXmlChanged = true;
            }
        }
    }
}