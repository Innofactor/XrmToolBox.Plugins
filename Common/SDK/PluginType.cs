namespace Cinteros.Xrm.SDK
{
    using System;
    using Cinteros.Xrm.Utils;
    using Microsoft.Xrm.Sdk;

    public class PluginType
    {
        #region Private Fields

        private Entity origin;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PluginType"/> class.
        /// </summary>
        public PluginType()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PluginType"/> class.
        /// </summary>
        /// <param name="entity"></param>
        public PluginType(Entity entity, PluginAssembly parentAssembly)
        {
            this.origin = entity;

            this.Id = entity.Id;
            this.ParentAssembly = parentAssembly;

            this.FriendlyName = (string)entity.Attributes[Constants.Crm.Attributes.NAME];
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets friendly name of plugin type
        /// </summary>
        public string FriendlyName
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets id of plugin type
        /// </summary>
        public Guid Id
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets information about parent assembly
        /// </summary>
        public PluginAssembly ParentAssembly
        {
            get;
            private set;
        }

        #endregion Public Properties

        #region Public Methods

        public Entity ToEntity()
        {
            return this.origin;
        }

        public override string ToString()
        {
            return this.FriendlyName;
        }

        #endregion Public Methods
    }
}