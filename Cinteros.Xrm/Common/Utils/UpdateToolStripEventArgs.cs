namespace Cinteros.Xrm.Common.Utils
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
            : this(buttonName, buttonStatus, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateToolStripEventArgs"/> class.
        /// </summary>
        /// <param name="buttonName"></param>
        /// <param name="buttonStatus"></param>
        /// <param name="buttonClick"></param>
        public UpdateToolStripEventArgs(string buttonName, bool? buttonStatus, EventHandler buttonClick)
        {
            this.ButtonName = buttonName;
            if (buttonStatus != null)
            {
                this.ButtonStatus = (bool)buttonStatus;
            }
            this.ButtonClick = buttonClick;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateToolStripEventArgs"/> class.
        /// </summary>
        /// <param name="buttonName"></param>
        /// <param name="buttonClick"></param>
        public UpdateToolStripEventArgs(string buttonName, EventHandler buttonClick)
            : this(buttonName, null, buttonClick)
        {
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets handler that will be executed when button is clicked
        /// </summary>
        public EventHandler ButtonClick
        {
            get;
            private set;
        }

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