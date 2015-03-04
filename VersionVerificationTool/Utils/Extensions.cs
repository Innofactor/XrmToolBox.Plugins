namespace Cinteros.Xrm.VersionVerificationTool.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Xml;
    using Cinteros.Xrm.VersionVerificationTool.SDK;

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
            var document = new XmlDocument();

            document.AppendChild(document.CreateXmlDeclaration("1.0", "UTF-8", "yes"));
            document.AppendChild(document.CreateComment("Comparison matrix"));

            var root = document.CreateElement("matrix");
            document.AppendChild(root);

            XmlElement element;
            XmlAttribute attribute;

            var solutions = document.CreateElement(Constants.Xml.SOLUTIONS);
            root.AppendChild(solutions);

            foreach (var solution in matrix[0].Solutions)
            {
                element = document.CreateElement(Constants.Xml.SOLUTION);

                attribute = document.CreateAttribute(Constants.Xml.UNIQUE_NAME);
                attribute.Value = solution.UniqueName;
                element.Attributes.Append(attribute);

                attribute = document.CreateAttribute(Constants.Xml.FRIENDLY_NAME);
                attribute.Value = solution.FriendlyName;
                element.Attributes.Append(attribute);

                attribute = document.CreateAttribute(Constants.Xml.VERSION);
                attribute.Value = solution.Version.ToString();
                element.Attributes.Append(attribute);

                solutions.AppendChild(element);
            }

            var assemblies = document.CreateElement(Constants.Xml.ASSEMBLIES);
            root.AppendChild(assemblies);

            foreach (var assembly in matrix[0].Assemblies)
            {
                element = document.CreateElement(Constants.Xml.ASSEMBLY);

                attribute = document.CreateAttribute(Constants.Xml.FRIENDLY_NAME);
                attribute.Value = assembly.FriendlyName;
                element.Attributes.Append(attribute);

                attribute = document.CreateAttribute(Constants.Xml.VERSION);
                attribute.Value = assembly.Version.ToString();
                element.Attributes.Append(attribute);

                assemblies.AppendChild(element);
            }

            return document;

        }

        #endregion Public Methods
    }
}