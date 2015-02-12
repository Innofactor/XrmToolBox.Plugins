namespace Cinteros.Xrm.SolutionVerifier.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

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

        public static XmlDocument ToXml(this Solution[] solutions)
        {
            var document = new XmlDocument();

            document.AppendChild(document.CreateXmlDeclaration("1.0", "UTF-8", "yes"));
            document.AppendChild(document.CreateComment("Reference solutions"));

            var root = document.CreateElement("solutions");
            document.AppendChild(root);

            XmlElement element;
            XmlAttribute attribute;

            foreach (var solution in solutions)
            {
                element = document.CreateElement("solution");

                attribute = document.CreateAttribute("unique-name");
                attribute.Value = solution.UniqueName;
                element.Attributes.Append(attribute);

                attribute = document.CreateAttribute("friendly-name");
                attribute.Value = solution.FriendlyName;
                element.Attributes.Append(attribute);

                attribute = document.CreateAttribute("version");
                attribute.Value = solution.Version.ToString();
                element.Attributes.Append(attribute);

                root.AppendChild(element);
            }

            return document;
        }

        #endregion Public Methods
    }
}