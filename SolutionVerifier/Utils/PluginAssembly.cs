namespace Cinteros.Xrm.SolutionVerifier.Utils
{
    using Microsoft.Xrm.Sdk;
    using System;
    using System.Reflection;

    public class PluginAssembly : Assembly
    {
        #region Public Constructors

        public PluginAssembly(Entity entity)
        {
            this.SolutionId = (Guid)entity.Attributes[Constants.A_SOLUTION_ID];
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets assembly's id
        /// </summary>
        public Guid Id
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets solution's id
        /// </summary>
        public Guid SolutionId
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets assembly's version
        /// </summary>
        public Version Version
        {
            get;
            set;
        }

        #endregion Public Properties
    }
}