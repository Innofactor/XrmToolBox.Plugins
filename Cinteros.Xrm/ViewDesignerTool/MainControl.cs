namespace Cinteros.Xrm.ViewDesignerTool
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using Cinteros.Xrm.Common.Forms;
    using Cinteros.Xrm.FetchXmlBuilder;
    using Cinteros.Xrm.ViewDesignerTool.Controls;
    using Microsoft.Crm.Sdk.Messages;
    using XrmToolBox.Extensibility;
    using XrmToolBox.Extensibility.Interfaces;

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
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.CloseTool();
        }

        private void tsbEditFetch_Click(object sender, EventArgs e)
        {
            var view = (ViewEditor)this.Controls.Find("lvDesign", true).FirstOrDefault();
            if (view != null)
            {
                var messageBusEventArgs = new MessageBusEventArgs("FetchXML Builder");
                var fXBMessageBusArgument = new FXBMessageBusArgument(FXBMessageBusRequest.FetchXML)
                {
                    FetchXML = view.FetchXml.OuterXml
                };
                messageBusEventArgs.TargetArgument = fXBMessageBusArgument;
                OnOutgoingMessage(this, messageBusEventArgs);
            }
        }

        private void tsbOpen_Click(object sender, EventArgs e)
        {
            var select = new SelectViewDialog(this);
            select.StartPosition = FormStartPosition.CenterParent;
            if (select.ShowDialog() == DialogResult.OK)
            {
                tsbSnap.Checked = true;

                var editor = (ViewEditor)this.Controls.Find("ViewEditor", true).FirstOrDefault();

                if (editor == null)
                {
                    editor = new ViewEditor()
                    {
                        Name = "ViewEditor",
                        Size = this.Size,
                        Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left
                    };

                    this.Controls.Add(editor);
                }
                editor.Open(select.View);
            }
        }

        private void tsbPublish_Click(object sender, EventArgs e)
        {
            this.WorkAsync("Publishing changes",
                a =>
                {
                    this.Service.Execute(new PublishAllXmlRequest());
                },
                a =>
                {
                });
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            var view = (ViewEditor)this.Controls.Find("ViewEditor", true).FirstOrDefault();
            var result = view.LayoutXml.OuterXml;

            this.WorkAsync("Saving changes",
                a =>
                {
                    this.Service.Update(view.ToEntity());
                },
                a =>
                {
                });
        }

        private void tsbSnap_Click(object sender, EventArgs e)
        {
            var view = (ViewEditor)this.Controls.Find("ViewEditor", true).FirstOrDefault();
            if (view != null)
            {
                view.Snap(((ToolStripButton)sender).Checked);
            }
        }

        private void UpdateFetch(string fetchxml)
        {
            var view = (ViewEditor)this.Controls.Find("ViewEditor", true).FirstOrDefault();
            if (view != null)
            {
                view.FetchXml.LoadXml(fetchxml);
            }
        }

        #endregion Private Methods

        private void tsbEditColumns_Click(object sender, EventArgs e)
        {
            var view = (ViewEditor)this.Controls.Find("ViewEditor", true).FirstOrDefault();

            var select = new SelectColumnsDialog();
            select.StartPosition = FormStartPosition.CenterParent;
            if (select.ShowDialog() == DialogResult.OK)
            {
            }
        }
    }
}