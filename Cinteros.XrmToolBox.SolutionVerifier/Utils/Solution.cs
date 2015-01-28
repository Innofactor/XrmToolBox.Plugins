namespace Cinteros.XrmToolbox.SolutionVerifier.Utils
{
    using Microsoft.Xrm.Sdk;
    using System;
    using System.Runtime.Serialization;

    [DataContract]
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

        [DataMember]
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

        [DataMember]
        public bool IsManaged
        {
            get;
            private set;
        }

        [DataMember]
        public string UniqueName
        {
            get;
            private set;
        }

        [DataMember]
        public Version Version
        {
            get;
            private set;
        }

        #endregion Public Properties
    }
}