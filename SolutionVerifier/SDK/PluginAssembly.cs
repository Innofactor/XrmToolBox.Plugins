namespace Cinteros.Xrm.SolutionVerifier.SDK
{
    using System;
    using Cinteros.Xrm.SolutionVerifier.Utils;
    using Microsoft.Xrm.Sdk;

    public class PluginAssembly : IComperable
    {
        #region Public Constructors

        public PluginAssembly()
        {
        }

        public PluginAssembly(Entity entity)
        {
            this.FriendlyName = (string)entity.Attributes[Constants.A_NAME];
            this.SolutionId = (Guid)entity.Attributes[Constants.A_SOLUTION_ID];
            this.Version = new Version((string)entity.Attributes[Constants.A_VERSION]);
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

        public string FriendlyName
        {
            get;
            set;
        }

        public string UniqueName
        {
            get;
            set;
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

        #region Public Methods

        public override string ToString()
        {
            return this.FriendlyName;
        }

        #endregion Public Methods
    }
}