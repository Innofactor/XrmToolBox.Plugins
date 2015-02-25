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
                    Version = new Version(element.Attributes[Constants.Xml.VERSION].Value),
                    UniqueName = element.Attributes[Constants.Xml.UNIQUE_NAME].Value,
                    FriendlyName = element.Attributes[Constants.Xml.FRIENDLY_NAME].Value
                };

                solutions.Add(solution);
            }

            return solutions.ToArray();
        }

        public static XmlDocument ToXml(this OrganizationSnapshot[] matrix)
        {
            return null;
        }

        #endregion Public Methods
    }
}