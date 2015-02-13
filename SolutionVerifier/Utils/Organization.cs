namespace Cinteros.Xrm.SolutionVerifier.Utils
{
    using McTools.Xrm.Connection;
    using System.Reflection;

    public class Organization
    {
        public ConnectionDetail ConnectionDetail;

        /// <summary>
        /// Array of solutions available in the organization
        /// </summary>
        public Solution[] Solutions;
    }
}
