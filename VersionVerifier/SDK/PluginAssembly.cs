namespace Cinteros.Xrm.VersionVerifier.SDK
{
    using System;
    using Cinteros.Xrm.VersionVerifier.Utils;
    using Microsoft.Xrm.Sdk;

    public class PluginAssembly : IComparableEntity
    {
        #region Public Constructors

        public PluginAssembly()
        {
        }

        public PluginAssembly(Entity entity)
        {
            this.FriendlyName = (string)entity.Attributes[Constants.Crm.Attributes.NAME];
            this.Version = new Version((string)entity.Attributes[Constants.Crm.Attributes.VERSION]);
        }

        #endregion Public Constructors

        #region Public Properties

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