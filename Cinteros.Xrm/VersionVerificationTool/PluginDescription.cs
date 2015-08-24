namespace Cinteros.Xrm.Plugins.VersionVerificationTool
{
    using System.ComponentModel.Composition;
    using Cinteros.Xrm.Common.Utils;
    using Cinteros.Xrm.VersionVerificationTool;
    using XrmToolBox.Extensibility;
    using XrmToolBox.Extensibility.Interfaces;

    [Export(typeof(IXrmToolBoxPlugin)),
    ExportMetadata("Name", "Version Verifier"),
    ExportMetadata("Description", "Tool to compare solution components versions over multiple environments"),
    ExportMetadata("SmallImageBase64", Constants.B64_IMAGE_SMALL), // null for "no logo" image or base64 image content
    ExportMetadata("BigImageBase64", Constants.B64_IMAGE_LARGE), // null for "no logo" image or base64 image content
    ExportMetadata("BackgroundColor", "#ffffff"), // Use a HTML color name
    ExportMetadata("PrimaryFontColor", "#000000"), // Or an hexadecimal code
    ExportMetadata("SecondaryFontColor", "DarkGray")]
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