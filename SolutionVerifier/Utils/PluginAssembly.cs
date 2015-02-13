namespace Cinteros.Xrm.SolutionVerifier.Utils
{
    using System;
    using Microsoft.Xrm.Sdk;

    public class PluginAssembly
    {
        #region Public Constructors

        public PluginAssembly(Entity entity)
        {
            this.Name = (string)entity.Attributes[Constants.A_NAME];
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

        public string Name
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
            return this.Name;
        }

        #endregion Public Methods
    }
}