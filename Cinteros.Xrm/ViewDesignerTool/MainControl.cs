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

                //((IUpdateToolStrip)this.control).UpdateToolStrip += this.MainControl_UpdateToolStrip;
                //((IUpdateToolStrip)this.control).JustifyToolStrip();
                //this.JustifyToolStrip();
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
            throw new NotImplementedException();
        }

        public event EventHandler<MessageBusEventArgs> OnOutgoingMessage;
        private Control control;

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.CloseTool();
        }

        private void MainControl_Load(object sender, EventArgs e)
        {
            this.CurrentPage = new ViewEditor();
        }
    }
}
