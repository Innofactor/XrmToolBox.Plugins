namespace Cinteros.Xrm.Common.SDK
{
    using System;
    using Utils;
    using Microsoft.Xrm.Sdk;

    public class ProcessingStep
    {
        #region Private Fields

        private Entity origin;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessingStep"/> class.
        /// </summary>
        public ProcessingStep()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessingStep"/> class.
        /// </summary>
        /// <param name="entity"></param>
        public ProcessingStep(Entity entity, PluginAssembly parentAssembly, PluginType parentType)
        {
            this.origin = entity;

            this.Id = entity.Id;
            this.ParentAssembly = parentAssembly;
            this.ParentType = parentType;

            this.FriendlyName = (string)entity.Attributes[Constants.Crm.Attributes.NAME];
            this.StateCode = (StateCode)((OptionSetValue)entity.Attributes[Constants.Crm.Attributes.STATE_CODE]).Value;
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
        /// Gets information about parent plugin assembly
        /// </summary>
        public PluginAssembly ParentAssembly
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets information about parent plugin type
        /// </summary>
        public PluginType ParentType
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets information about state code of the entity
        /// </summary>
        public StateCode StateCode
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