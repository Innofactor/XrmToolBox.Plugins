namespace Cinteros.XrmToolbox.SolutionVerifier.Utils
{
    using Microsoft.Xrm.Sdk;
    using System;

    public class Solution
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Solution" /> class.
        /// </summary>
        public Solution()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Solution" /> class.
        /// </summary>
        /// <param name="entity">Entity from which solution object is initialized</param>
        public Solution(Entity entity)
        {
            this.Id = (Guid)entity.Attributes[Constants.A_SOLUTIONID];
            this.Version = new Version((string)entity.Attributes[Constants.A_VERSION]);
            this.UniqueName = (string)entity.Attributes[Constants.A_UNIQUENAME];
            this.FriendlyName = (string)entity.Attributes[Constants.A_FRIENDLYNAME];
            this.IsManaged = (bool)entity.Attributes[Constants.A_ISMANAGED];
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
        /// Gets or sets solution's id
        /// </summary>
        public Guid Id
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets solution's isManaged flag
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
    }
}