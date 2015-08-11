namespace Cinteros.Xrm.Common.SDK
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