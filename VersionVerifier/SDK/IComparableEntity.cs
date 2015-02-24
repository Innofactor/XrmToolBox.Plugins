namespace Cinteros.Xrm.VersionVerifier.SDK
{
    using System;

    public interface IComparableEntity
    {
        #region Public Properties

        string FriendlyName
        {
            get;
            set;
        }

        Guid Id
        {
            get;
        }

        string UniqueName
        {
            get;
            set;
        }

        Version Version
        {
            get;
            set;
        }

        #endregion Public Properties
    }
}