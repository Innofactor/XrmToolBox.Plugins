namespace Cinteros.Xrm.VersionVerifier.Utils
{
    internal struct Constants
    {
        #region Internal Fields

        internal const int U_HEADER_MAINWIDTH = 200;

        /// <summary>
        /// Text for solution that is not available
        /// </summary>
        internal const string U_ITEM_NA = "N/A";

        /// <summary>
        /// Default solution unique name
        /// </summary>
        internal const string U_SOLUTION_DEFAULT = "Default";

        #endregion Internal Fields

        #region Internal Structs

        internal struct Crm
        {
            #region Internal Structs

            internal struct Attributes
            {
                #region Internal Fields

                internal const string FRIENDLY_NAME = "friendlyname";
                internal const string IS_HIDDEN = "ishidden";
                internal const string IS_MANAGED = "ismanaged";
                internal const string IS_VISIBLE = "isvisible";
                internal const string NAME = "name";
                internal const string SOLUTION_ID = "solutionid";
                internal const string UNIQUE_NAME = "uniquename";
                internal const string VERSION = "version";

                #endregion Internal Fields
            }

            internal struct Entities
            {
                #region Internal Fields

                #region Internal Fields

                /// <summary>
                /// Name of the 'pluginassembly' entity
                /// </summary>
                internal const string PLUGIN_ASSEMBLY = "pluginassembly";

                #endregion Internal Fields

                #region Internal Fields

                /// <summary>
                /// Name of the 'solution' entity
                /// </summary>
                internal const string SOLUTION = "solution";

                #endregion Internal Fields

                #endregion Internal Fields
            }

            #endregion Internal Structs
        }

        internal struct UI
        {
            #region Internal Structs

            #region Internal Structs

            internal struct Buttons
            {
                #region Internal Fields

                #region Internal Fields

                /// <summary>
                /// Name of toolstrip's Back button
                /// </summary>
                internal const string BACK = "tsbBack";

                /// <summary>
                /// Name of toolstrip's Compare button
                /// </summary>
                internal const string COMPARE = "tsbCompare";

                /// <summary>
                /// Name of toolstrip's Save button
                /// </summary>
                internal const string SAVE = "tsbSave";

                #endregion Internal Fields

                #endregion Internal Fields
            }

            #endregion Internal Structs

            internal struct Labels
            {
                #region Internal Fields

                /// <summary>
                /// Text for solutions group
                /// </summary>
                internal const string ASSEMBLIES = "Assemblies";

                /// <summary>
                /// Text for solutions group
                /// </summary>
                internal const string SOLUTIONS = "Solutions";

                #endregion Internal Fields
            }

            #endregion Internal Structs
        }

        internal struct Xml
        {
            #region Internal Fields

            #region Internal Fields

            internal const string ASSEMBLIES = "assemblies";
            internal const string FRIENDLY_NAME = "friendly-name";
            internal const string SOLUTIONS = "solutions";
            internal const string UNIQUE_NAME = "unique-name";

            #endregion Internal Fields

            internal const string VERSION = "version";

            #endregion Internal Fields
        }

        #endregion Internal Structs
    }
}