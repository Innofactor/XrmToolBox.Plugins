namespace Cinteros.Xrm.Common.SDK
{
    using System;

    public class MessageFilter
    {
        #region Public Constructors

        public MessageFilter()
        {
        }

        #endregion Public Constructors

        #region Public Properties

        public string EntityName
        {
            get;
            set;
        }

        public Guid Id
        {
            get;
            set;
        }

        #endregion Public Properties
    }
}