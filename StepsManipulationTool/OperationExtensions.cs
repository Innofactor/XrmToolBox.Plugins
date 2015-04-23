namespace Cinteros.Xrm.StepsManipulationTool
{
    using System.Linq;
    using System.Windows.Forms;
    using Cinteros.Xrm.SDK;
    using Cinteros.Xrm.Utils;
    using Microsoft.Xrm.Sdk;
    using XrmToolBox;

    public static class OperationExtensions
    {
        #region Public Methods

        public static void RetrieveTypes(this ComboBox comboBox, PluginBase host, PluginAssembly pluginAssembly, bool allTypesOption = false)
        {
            if (comboBox == null || comboBox.Parent == null)
            {
                return;
            }

            host.WorkAsync("Loading types...",
                a =>
                {
                    a.Result = host.Service.GetPluginTypes(pluginAssembly.Id);
                },
                a =>
                {
                    // this.PluginTypes = ((Entity[])a.Result).Select<Entity, PluginType>(x => new
                    // PluginType(x, pluginAssembly)).ToArray();
                    comboBox.Items.Clear();

                    if (allTypesOption)
                    {
                        comboBox.Items.Add(new PluginType
                        {
                            FriendlyName = "All types"
                        });
                    }

                    foreach (var type in ((Entity[])a.Result).Select<Entity, PluginType>(x => new PluginType(x, pluginAssembly)))
                    {
                        comboBox.Items.Add(type);
                    }

                    if (allTypesOption)
                    {
                        // Select all types
                        comboBox.SelectedIndex = 0;
                    }
                });
        }

        #endregion Public Methods
    }
}