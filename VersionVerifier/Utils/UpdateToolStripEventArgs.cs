namespace Cinteros.Xrm.VersionVerifier.Utils
{
    using System;

    public class UpdateToolStripEventArgs : EventArgs
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateToolStripEventArgs"/> class.
        /// </summary>
        /// <param name="buttonName"></param>
        /// <param name="buttonStatus"></param>
        public UpdateToolStripEventArgs(string buttonName, bool buttonStatus)
        {
            this.ButtonName = buttonName;
            this.ButtonStatus = buttonStatus;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets name of toolstrip button to change enabled flag
        /// </summary>
        public string ButtonName
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets enabled flag value for selected toolstrip button
        /// </summary>
        public bool ButtonStatus
        {
            get;
            private set;
        }

        #endregion Public Properties
    }
}