namespace Cinteros.Xrm.VersionVerificationTool.Utils
{
    using System;

    public interface IUpdateToolStrip
    {
        #region Public Events

        event EventHandler<UpdateToolStripEventArgs> UpdateToolStrip;

        #endregion Public Events

        #region Public Methods

        void JustifyToolStrip();

        #endregion Public Methods
    }
}