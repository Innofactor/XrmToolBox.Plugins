namespace Cinteros.Xrm.SolutionVerifier.Utils
{
    using Microsoft.Xrm.Sdk;
    using System;

    public class PluginAssembly
    {
        #region Public Properties

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

        #region Public Constructors

        public PluginAssembly(Entity entity)
        {
            this.Name = (string)entity.Attributes[Constants.A_NAME];
            this.SolutionId = (Guid)entity.Attributes[Constants.A_SOLUTION_ID];
            this.Version = new Version((string)entity.Attributes[Constants.A_VERSION]);
        }

        #endregion Public Constructors

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

        public override string ToString()
        {
            return this.Name;
        }
    }
}