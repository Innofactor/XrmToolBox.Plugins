namespace Cinteros.Xrm.VersionVerifier.SDK
{
    using System;
    using Cinteros.Xrm.VersionVerifier.Utils;
    using Microsoft.Xrm.Sdk;

    public class PluginAssembly : IComparableEntity
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PluginAssembly"/> class.
        /// </summary>
        public PluginAssembly()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PluginAssembly"/> class.
        /// </summary>
        /// <param name="entity"></param>
        public PluginAssembly(Entity entity)
        {
            this.FriendlyName = (string)entity.Attributes[Constants.Crm.Attributes.NAME];
            this.Version = new Version((string)entity.Attributes[Constants.Crm.Attributes.VERSION]);

            this.UniqueName = string.Format("{0}, Version={1}, Culture={2}, PublicKeyToken={3}",
                this.FriendlyName,
                this.Version,
                (string)entity.Attributes[Constants.Crm.Attributes.CULTURE],
                (string)entity.Attributes[Constants.Crm.Attributes.PUBLIC_KEY_TOKEN]);
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