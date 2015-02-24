namespace Cinteros.Xrm.VersionVerifier.SDK
{
    using System;
    using Cinteros.Xrm.VersionVerifier.Utils;
    using Microsoft.Xrm.Sdk;

    public class Solution : IComparableEntity
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Solution"/> class.
        /// </summary>
        public Solution()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Solution"/> class.
        /// </summary>
        /// <param name="entity">Entity from which solution object is initialized</param>
        public Solution(Entity entity)
        {
            this.Id = (Guid)entity.Attributes[Constants.Crm.Attributes.A_SOLUTION_ID];
            this.Version = new Version((string)entity.Attributes[Constants.Crm.Attributes.A_VERSION]);
            this.UniqueName = (string)entity.Attributes[Constants.Crm.Attributes.A_UNIQUE_NAME];
            this.FriendlyName = (string)entity.Attributes[Constants.Crm.Attributes.A_FRIENDLY_NAME];
            this.IsManaged = (bool)entity.Attributes[Constants.Crm.Attributes.A_IS_MANAGED];
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets or sets solution's friendly name
        /// </summary>
        public string FriendlyName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets solution's id
        /// </summary>
        public Guid Id
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets a value indicating whether solution is managed or not
        /// </summary>
        public bool IsManaged
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets solution's unique name
        /// </summary>
        public string UniqueName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets solution's version
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