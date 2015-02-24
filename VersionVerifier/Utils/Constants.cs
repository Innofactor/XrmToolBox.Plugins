namespace Cinteros.Xrm.VersionVerifier.Utils
{
    internal struct Constants
    {
        #region internal Fields

        internal struct Crm
        {
            internal struct Attributes
            {
                internal const string A_FRIENDLY_NAME = "friendlyname";
                internal const string A_IS_HIDDEN = "ishidden";
                internal const string A_IS_MANAGED = "ismanaged";
                internal const string A_IS_VISIBLE = "isvisible";
                internal const string A_NAME = "name";
                internal const string A_SOLUTION_ID = "solutionid";
                internal const string A_UNIQUE_NAME = "uniquename";
                internal const string A_VERSION = "version";
            }
        }
        
        /// <summary>
        /// Name of the 'pluginassembly' entity
        /// </summary>
        internal const string E_PLUGIN_ASSEMBLY = "pluginassembly";
        
        /// <summary>
        /// Name of the 'solution' entity
        /// </summary>
        internal const string E_SOLUTION = "solution";

        /// <summary>
        /// Text for solutions group
        /// </summary>
        internal const string U_ASSEMBLIES = "Assemblies";

        /// <summary>
        /// Name of toolstrip's Back button
        /// </summary>
        internal const string U_BACK_BUTTON = "tsbBack";

        /// <summary>
        /// Name of toolstrip's Compare button
        /// </summary>
        internal const string U_COMPARE_BUTTON = "tsbCompare";

        internal const int U_HEADER_MAINWIDTH = 200;

        /// <summary>
        /// Text for solution that is not available
        /// </summary>
        internal const string U_ITEM_NA = "N/A";

        /// <summary>
        /// Name of toolstrip's Save button
        /// </summary>
        internal const string U_SAVE_BUTTON = "tsbSave";

        /// <summary>
        /// Default solution unique name
        /// </summary>
        internal const string U_SOLUTION_DEFAULT = "Default";

        /// <summary>
        /// Text for solutions group
        /// </summary>
        internal const string U_SOLUTIONS = "Solutions";

        internal struct Xml
        {
            internal const string ASSEMBLIES = "assemblies";
            internal const string SOLUTIONS = "solutions";
            internal const string FRIENDLY_NAME = "friendly-name";
            internal const string UNIQUE_NAME = "unique-name";
            internal const string VERSION = "version";
        }

        #endregion internal Fields
    }
}