namespace Cinteros.XrmToolbox.SolutionVerifier.Utils
{
    using System;
    using System.Text;

    public static class Extensions
    {
        #region Public Methods

        public static string CSV(this Solution[] solutions)
        {
            var builder = new StringBuilder();

            builder.Append("FriendlyName,UniqueName,Version");
            builder.Append(Environment.NewLine);

            foreach (var solution in solutions)
            {
                builder.Append(string.Format("{0},{1},{2}", solution.FriendlyName, solution.UniqueName, solution.Version.ToString()));
                builder.Append(Environment.NewLine);
            }

            return builder.ToString();
        }

        #endregion Public Methods
    }
}