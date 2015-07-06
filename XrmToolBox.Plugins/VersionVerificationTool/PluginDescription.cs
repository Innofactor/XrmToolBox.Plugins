using Cinteros.Xrm.AutoDeployTool;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace Cinteros.Xrm.Plugins.VersionVerificationTool
{
    public class VersionVerificationTool : PluginBase
    {
        #region Public Methods

        public override IXrmToolBoxPluginControl GetControl()
        {
            return new MainControl();
        }

        #endregion Public Methods
    }
}