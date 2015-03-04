namespace Cinteros.Xrm.StepsManipulator
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Microsoft.Xrm.Sdk;
    using XrmToolBox;

    public partial class MainControl : PluginBase, IGitHubPlugin
    {
        public MainControl()
        {
            InitializeComponent();

            this.Enter += MainControl_Enter;
        }

        void MainControl_Enter(object sender, EventArgs e)
        {
            this.ExecuteMethod(RetrieveSteps);
        }

        public void RetrieveSteps()
        {
            this.WorkAsync("Loading steps...",
                e =>
                {
                    e.Result = this.Service.GetSdkMessageProcessingSteps();
                },
                e =>
                {
                    var steps = (Entity[])e.Result;
                    var types = steps.GroupBy(x => x["plugintypeid"]).Select(y => y.First()).ToArray();

                    var groups = new Dictionary<Guid, int>();
                    var i = 0;

                    foreach (var type in types)
                    {
                        var item = new ListViewGroup
                        {
                            Header = ((AliasedValue)type.Attributes["plugintype.typename"]).Value.ToString(),
                        };
                        this.lvSteps.Groups.Add(item);
                        groups.Add(((EntityReference)type["plugintypeid"]).Id, i++);
                    }

                    foreach (var step in steps)
                    {
                        var item = new ListViewItem
                        {
                            Text = (string)step["name"],
                            Group = this.lvSteps.Groups[groups[((EntityReference)step["plugintypeid"]).Id]]
                        };
                        
                        this.lvSteps.Items.Add(item);
                    }
                });
        }


        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.CloseTool();
        }

        public string UserName
        {
            get 
            { 
                return "Cinteros"; 
            }
        }

        public string RepositoryName
        {
            get 
            {
                return "StepsManipulator";
            }
        }
    }
}
