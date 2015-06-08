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
    using System.IO;
    using System.Reflection;
    using Microsoft.Xrm.Sdk.Query;
    using Microsoft.Xrm.Sdk;

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

        private void button1_Click(object sender, EventArgs e)
        {
            ofdPlugin.Filter = "MS CRM Plugins|*.dll";
            ofdPlugin.FileOk += (s, a) =>
                {
                    this.lPlugin.Text = ofdPlugin.FileName;

                    watcher = new FileSystemWatcher();
                    watcher.Path = Path.GetDirectoryName(this.lPlugin.Text);
                    watcher.Filter = Path.GetFileName(this.lPlugin.Text);

                    watcher.NotifyFilter = NotifyFilters.LastWrite;
                    watcher.EnableRaisingEvents = true;

                    watcher.Changed += watcher_Changed;
                };
            ofdPlugin.ShowDialog();
        }

        void watcher_Changed(object sender, FileSystemEventArgs e)
        {
            var lastWriteTime = File.GetLastWriteTime(this.lPlugin.Text);
            if (lastWriteTime != lastRead)
            {
                this.Invoke(new Action(() =>
                    {
                        this.WorkAsync("Deploying plugin",
                            a =>
                            {
                                //var tempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
                                //Directory.CreateDirectory(tempDirectory);

                                //var resultFile = Path.Combine(tempDirectory, Path.GetFileName(this.lPlugin.Text));

                                //File.Copy(fileName, resultFile);

                                byte[] buffer = null;
                                using (var fs = new FileStream(this.lPlugin.Text, FileMode.Open, FileAccess.Read))
                                {
                                    buffer = new byte[fs.Length];
                                    fs.Read(buffer, 0, (int)fs.Length);
                                }

                                var assembly = Assembly.Load(buffer);
                                var chunks = assembly.FullName.Split(new string[] { ", ", "Version=", "Culture=", "PublicKeyToken=" }, StringSplitOptions.RemoveEmptyEntries);

                                var query = new QueryExpression("pluginassembly");
                                query.Criteria.AddCondition("name", ConditionOperator.Equal, chunks[0]);
                                query.Criteria.AddCondition("version", ConditionOperator.Equal, chunks[1]);
                                query.Criteria.AddCondition("culture", ConditionOperator.Equal, chunks[2]);
                                query.Criteria.AddCondition("publickeytoken", ConditionOperator.Equal, chunks[3]);

                                var plugin = new Entity("pluginassembly");
                                plugin.Id = this.Service.RetrieveMultiple(query).Entities.FirstOrDefault().Id;

                                plugin["content"] = Convert.ToBase64String(buffer);

                                this.Service.Update(plugin);
                            },
                            a =>
                            {
                            });
                    }));

                lastRead = lastWriteTime;
            }
        }

        public static FileSystemWatcher watcher 
        { 
            get; 
            set; 
        }

        public DateTime lastRead 
        { 
            get;
            set; 
        }
    }
}
