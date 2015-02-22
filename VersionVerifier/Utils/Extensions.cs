namespace Cinteros.Xrm.VersionVerifier.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Xml;
    using Cinteros.Xrm.VersionVerifier.SDK;

    public static class Extensions
    {
        #region Public Methods

        public static Solution[] ToArray(this XmlDocument document)
        {
            var solutions = new List<Solution>();

            foreach (XmlElement element in document.DocumentElement.ChildNodes)
            {
                var solution = new Solution
                {
                    Version = new Version(element.Attributes["version"].Value),
                    UniqueName = element.Attributes["unique-name"].Value,
                    FriendlyName = element.Attributes["unique-name"].Value
                };

                solutions.Add(solution);
            }

            return solutions.ToArray();
        }

        #endregion Public Methods
    }
}