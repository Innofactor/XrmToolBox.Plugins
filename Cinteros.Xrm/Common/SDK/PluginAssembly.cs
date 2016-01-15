namespace Cinteros.Xrm.Common.SDK
{
    using System;
    using Cinteros.Xrm.Common.Utils;
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
            Id = entity.Id;

            FriendlyName = (string)entity.Attributes[Constants.Crm.Attributes.NAME];

            if (entity.Attributes.Contains(Constants.Crm.Attributes.ISOLATION_MODE))
            {
                IsolationMode = (IsolationMode)((OptionSetValue)entity.Attributes[Constants.Crm.Attributes.ISOLATION_MODE]).Value;
            }

            UniqueName = string.Format("{0}, Version={1}, Culture={2}, PublicKeyToken={3}",
                FriendlyName,
                Version,
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
        /// Gets assembly's id
        /// </summary>
        public Guid Id
        {
            get;
            private set;
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
            return $"{FriendlyName} {Version}";
        }

        #endregion Public Methods
    }
}