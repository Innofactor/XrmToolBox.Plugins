﻿namespace Cinteros.XrmToolbox.SolutionVerifier.Utils
{
    using System;

    public interface IUpdateToolStrip
    {
        #region Public Events

        event EventHandler<UpdateToolStripEventArgs> UpdateToolStrip;

        #endregion Public Events
    }
}