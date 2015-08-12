namespace Cinteros.Xrm.ViewDesignerTool
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using XrmToolBox.Extensibility.Interfaces;
    using XrmToolBox.Extensibility;
    using Cinteros.Xrm.ViewDesignerTool.Controls;
    using Microsoft.Xrm.Sdk.Query;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Crm.Sdk.Messages;
    using Cinteros.Xrm.ViewDesignerTool.AppCode;
    using Cinteros.Xrm.FetchXmlBuilder;
    using System.Xml;
    using Cinteros.Xrm.Common.Forms;

    public partial class MainControl : PluginControlBase, IGitHubPlugin, IMessageBusHost
    {
        public MainControl()
        {
            InitializeComponent();
        }

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

        private void UpdateFetch(string fetchxml)
        {
            var view = (LayoutDesigner)this.CurrentPage.Controls.Find("lvDesign", true).FirstOrDefault();
            if (view != null)
            {
                view.FetchXml.LoadXml(fetchxml);
            }
        }

        public event EventHandler<MessageBusEventArgs> OnOutgoingMessage;
        private Control control;

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.CloseTool();
        }

        private void MainControl_Load(object sender, EventArgs e)
        {
            if (sender != null)
            {
                if (sender is MainControl)
                {
                    var plugin = ((MainControl)sender);
                    // In case if connection updated on main application, update assemblies list inside the plugin
                    // plugin.ConnectionUpdated += MainControl_ConnectionUpdated;

                    // this.ExecuteMethod(this.RetrieveViews);

                    //if (plugin.Service != null)
                    //{
                    //    // Execute assemblies retrieve only if Service object is set for correct sender.
                    //    // This will help plugin act predicatable when it was loaded in offline mode;
                    //    // Plugin will not insist on connecting to server. Will scinetly obey instead.
                    //    this.ExecuteMethod(this.RetrieveViews);
                    //}
                }

                this.ExecuteMethod(() =>
                    {
                        this.CurrentPage = new ViewEditor();
                    });

            }
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            var view = (LayoutDesigner)this.CurrentPage.Controls.Find("lvDesign", true).FirstOrDefault();
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

        private void tsbEditFetch_Click(object sender, EventArgs e)
        {
            var view = (LayoutDesigner)this.Controls.Find("lvDesign", true).FirstOrDefault();
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

        private void tsbSnap_Click(object sender, EventArgs e)
        {
            var view = (LayoutDesigner)this.Controls.Find("lvDesign", true).FirstOrDefault();
            if (view != null)
            {
                view.Snap(((ToolStripButton)sender).Checked);
            }
        }

        private void tsbOpen_Click(object sender, EventArgs e)
        {
            var views = new SelectViewDialog(this);
            views.ShowDialog();
        }
    }
}
