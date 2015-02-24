namespace Cinteros.Xrm.VersionVerifier.Utils
{
    internal struct Constants
    {
        #region Public Fields

        public const string A_FRIENDLY_NAME = "friendlyname";
        public const string A_IS_HIDDEN = "ishidden";
        public const string A_IS_MANAGED = "ismanaged";
        public const string A_IS_VISIBLE = "isvisible";
        public const string A_NAME = "name";
        public const string A_SOLUTION_ID = "solutionid";
        public const string A_UNIQUE_NAME = "uniquename";
        public const string A_VERSION = "version";
        
        /// <summary>
        /// Name of the 'pluginassembly' entity
        /// </summary>
        public const string E_PLUGIN_ASSEMBLY = "pluginassembly";
        
        /// <summary>
        /// Name of the 'solution' entity
        /// </summary>
        public const string E_SOLUTION = "solution";

        /// <summary>
        /// Text for solutions group
        /// </summary>
        public const string U_ASSEMBLIES = "Assemblies";

        /// <summary>
        /// Name of toolstrip's Back button
        /// </summary>
        public const string U_BACK_BUTTON = "tsbBack";

        /// <summary>
        /// Name of toolstrip's Compare button
        /// </summary>
        public const string U_COMPARE_BUTTON = "tsbCompare";

        public const int U_HEADER_MAINWIDTH = 200;

        /// <summary>
        /// Text for solution that is not available
        /// </summary>
        public const string U_ITEM_NA = "N/A";

        /// <summary>
        /// Name of toolstrip's Save button
        /// </summary>
        public const string U_SAVE_BUTTON = "tsbSave";

        /// <summary>
        /// Default solution unique name
        /// </summary>
        public const string U_SOLUTION_DEFAULT = "Default";

        /// <summary>
        /// Text for solutions group
        /// </summary>
        public const string U_SOLUTIONS = "Solutions";

        public struct Xml
        {
            public const string ASSEMBLIES = "assemblies";
            public const string SOLUTIONS = "solutions";
            public const string FRIENDLY_NAME = "friendly-name";
            public const string UNIQUE_NAME = "unique-name";
            public const string VERSION = "version";
        }

        #endregion Public Fields
    }
}