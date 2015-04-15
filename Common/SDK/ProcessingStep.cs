namespace Cinteros.Xrm.SDK
{
    using System;
    using Cinteros.Xrm.Utils;
    using Microsoft.Xrm.Sdk;

    public class ProcessingStep
    {
        #region Public Methods

        public override string ToString()
        {
            return this.FriendlyName;
        }

        #endregion Public Methods

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
            this.Id = entity.Id;
            this.ParentAssembly = parentAssembly;
            this.ParentType = parentType;

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

        #endregion Public Properties
    }
}