namespace Cinteros.Xrm.StepsManipulationTool
{
    using System.Linq;
    using System.Windows.Forms;
    using Common.SDK;
    using Common.Utils;
    using Microsoft.Xrm.Sdk;
    using XrmToolBox.Extensibility;

    public static class OperationExtensions
    {
        #region Public Methods

        public static void RetrieveTypes(this ComboBox comboBox, PluginControlBase host, PluginAssembly pluginAssembly, bool allTypesOption = false)
        {
            if (comboBox == null || comboBox.Parent == null)
            {
                return;
            }

            var info = new WorkAsyncInfo();
            info.Message = "Loading types...";

            info.Work = (worker, a) =>
            {
                a.Result = host.Service.GetPluginTypes(pluginAssembly.Id);
            };

            info.PostWorkCallBack = (a) =>
            {
                comboBox.Items.Clear();

                if (allTypesOption)
                {
                    comboBox.Items.Add(new PluginType
                    {
                        FriendlyName = "All types"
                    });
                }

                foreach (var type in ((Entity[])a.Result).Select(x => new PluginType(x, pluginAssembly)))
                {
                    comboBox.Items.Add(type);
                }

                if (allTypesOption)
                {
                    // Select all types
                    comboBox.SelectedIndex = 0;
                }
            };

            host.WorkAsync(info);
        }

        #endregion Public Methods
    }
}