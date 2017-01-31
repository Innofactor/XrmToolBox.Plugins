namespace Cinteros.Xrm.Plugins.StepsManipulationTool
{
    using System.ComponentModel.Composition;
    using Common.Utils;
    using Cinteros.Xrm.StepsManipulationTool;
    using XrmToolBox.Extensibility;
    using XrmToolBox.Extensibility.Interfaces;

    [Export(typeof(IXrmToolBoxPlugin)),
    ExportMetadata("Name", "Steps Manipulator"),
    ExportMetadata("Description", "Tool to perform unsafe operations with plugin steps"),
    ExportMetadata("SmallImageBase64", Constants.B64_IMAGE_SMALL), // null for "no logo" image or base64 image content
    ExportMetadata("BigImageBase64", Constants.B64_IMAGE_LARGE), // null for "no logo" image or base64 image content
    ExportMetadata("BackgroundColor", "#ffffff"), // Use a HTML color name
    ExportMetadata("PrimaryFontColor", "#000000"), // Or an hexadecimal code
    ExportMetadata("SecondaryFontColor", "DarkGray")]
    public class StepsManipulationTool : PluginBase
    {
        #region Public Methods

        public override IXrmToolBoxPluginControl GetControl()
        {
            return new MainControl();
        }

        #endregion Public Methods
    }
}