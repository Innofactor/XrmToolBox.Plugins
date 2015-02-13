namespace Cinteros.Xrm.SolutionVerifier.Utils
{
    using McTools.Xrm.Connection;

    public class Organization
    {
        #region Public Fields

        public ConnectionDetail ConnectionDetail;

        /// <summary>
        /// Array of solutions available in the organization
        /// </summary>
        public Solution[] Solutions;

        #endregion Public Fields
    }
}