using Cinteros.Xrm.AutoDeployTool;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace Cinteros.Xrm.Plugins.AutoDeployTool
{
    public class AutoDeployTool : PluginBase
    {
        #region Public Methods

        public override IXrmToolBoxPluginControl GetControl()
        {
            return new MainControl();
        }

        #endregion Public Methods
    }
}