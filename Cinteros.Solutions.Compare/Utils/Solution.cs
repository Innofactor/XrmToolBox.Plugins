namespace Cinteros.Solutions.Compare.Utils
{
    using Microsoft.Xrm.Sdk;
    using System;

    public class Solution
    {
        #region Public Constructors

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

        public string FriendlyName
        {
            get;
            private set;
        }

        public Guid Id
        {
            get;
            private set;
        }

        public bool IsManaged
        {
            get;
            private set;
        }

        public string UniqueName
        {
            get;
            private set;
        }

        public Version Version
        {
            get;
            private set;
        }

        #endregion Public Properties

        #region Public Methods

        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(Solution))
            {
                return this.UniqueName.Equals(((Solution)obj).UniqueName);
            }
            else
            {
                return false;
            }
        }

        #endregion Public Methods
    }
}