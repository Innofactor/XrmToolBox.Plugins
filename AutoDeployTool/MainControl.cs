namespace AutoDeployTool
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Query;
    using XrmToolBox;

    public partial class MainControl : PluginBase, IGitHubPlugin
    {
        #region Public Constructors

        public MainControl()
        {
            InitializeComponent();
        }

        #endregion Public Constructors

        #region Public Properties

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

        internal DateTime LastRead
        {
            get;
            private set;
        }

        internal Guid PluginId
        {
            get;
            private set;
        }

        internal FileSystemWatcher Watcher
        {
            get;
            private set;
        }

        #endregion Public Properties

        #region Private Methods

        private void button1_Click(object sender, EventArgs e)
        {
            ofdPlugin.Filter = "MS CRM Plugins|*.dll";
            ofdPlugin.FileOk += (s, a) =>
                {
                    this.lPlugin.Text = ofdPlugin.FileName;

                    this.PluginId = this.GetAssemblyId();

                    this.Watcher = new FileSystemWatcher();
                    this.Watcher.Path = Path.GetDirectoryName(this.lPlugin.Text);
                    this.Watcher.Filter = Path.GetFileName(this.lPlugin.Text);

                    this.Watcher.NotifyFilter = NotifyFilters.LastWrite;
                    this.Watcher.EnableRaisingEvents = true;

                    this.Watcher.Changed += Plugin_Changed;
                };
            ofdPlugin.ShowDialog();
        }

        private Guid GetAssemblyId()
        {
            var chunks = Assembly.Load(this.ReadFile()).FullName.Split(new string[] { ", ", "Version=", "Culture=", "PublicKeyToken=" }, StringSplitOptions.RemoveEmptyEntries);

            var query = new QueryExpression("pluginassembly");
            query.Criteria.AddCondition("name", ConditionOperator.Equal, chunks[0]);
            query.Criteria.AddCondition("version", ConditionOperator.Equal, chunks[1]);
            query.Criteria.AddCondition("culture", ConditionOperator.Equal, chunks[2]);
            query.Criteria.AddCondition("publickeytoken", ConditionOperator.Equal, chunks[3]);

            return this.Service.RetrieveMultiple(query).Entities.FirstOrDefault().Id;
        }

        private void Plugin_Changed(object sender, FileSystemEventArgs e)
        {
            try
            {
                var lastWriteTime = File.GetLastWriteTime(this.lPlugin.Text);
                if (lastWriteTime != LastRead)
                {
                    tbLog.Text += string.Format("{0}: Assembly '{1}' was changed.\r\n", DateTime.Now, Path.GetFileName(this.lPlugin.Text));

                    var plugin = new Entity("pluginassembly")
                    {
                        Id = this.PluginId
                    };

                    plugin["content"] = Convert.ToBase64String(this.ReadFile());

                    this.Service.Update(plugin);

                    tbLog.Text += string.Format("{0}: Assembly '{1}' was updated on the server.\r\n", DateTime.Now, Path.GetFileName(this.lPlugin.Text));

                    LastRead = lastWriteTime;
                }
            }
            catch (Exception ex)
            {
                tbLog.Text += string.Format("{0}: Assembly '{1}' was not updated. The reason is exception raised: '{2}'.\r\n", DateTime.Now, Path.GetFileName(this.lPlugin.Text), ex.Message);
            }
        }

        private byte[] ReadFile()
        {
            byte[] buffer = null;
            using (var fs = new FileStream(this.lPlugin.Text, FileMode.Open, FileAccess.Read))
            {
                buffer = new byte[fs.Length];
                fs.Read(buffer, 0, (int)fs.Length);
            }
            return buffer;
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.CloseTool();
        }

        #endregion Private Methods
    }
}