namespace AutoDeployTool
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
    using XrmToolBox;

    public partial class MainControl : PluginBase, IGitHubPlugin
    {
        public MainControl()
        {
            InitializeComponent();
        }

        string IGitHubPlugin.RepositoryName
        {
            get { throw new NotImplementedException(); }
        }

        string IGitHubPlugin.UserName
        {
            get { throw new NotImplementedException(); }
        }
    }
}
