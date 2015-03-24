namespace Cinteros.Xrm.VersionVerificationTool.SDK
{
    using System;
    using Cinteros.Xrm.VersionVerificationTool.Utils;
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

            this.IsolationMode = (IsolationMode)((OptionSetValue)entity.Attributes[Constants.Crm.Attributes.ISOLATION_MODE]).Value;

            this.UniqueName = string.Format("{0}, Version={1}, Culture={2}, PublicKeyToken={3}",
                this.FriendlyName,
                this.Version,
                (string)entity.Attributes[Constants.Crm.Attributes.CULTURE],
                (string)entity.Attributes[Constants.Crm.Attributes.PUBLIC_KEY_TOKEN]);

            this.Version = new Version((string)entity.Attributes[Constants.Crm.Attributes.VERSION]);
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets or sets assembly's friendly name
        /// </summary>
        public string FriendlyName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets assembly's Isolation Mode
        /// </summary>
        public IsolationMode IsolationMode
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets assembly's Qualified Name
        /// </summary>
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