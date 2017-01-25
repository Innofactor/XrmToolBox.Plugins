namespace Cinteros.Xrm.StepsManipulationTool
{
    using System.Linq;
    using System.Windows.Forms;
    using Cinteros.Xrm.Common.SDK;
    using Cinteros.Xrm.Common.Utils;
    using Microsoft.Xrm.Sdk;
    using XrmToolBox;
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
            };

            host.WorkAsync(info);
        }

        #endregion Public Methods
    }
}