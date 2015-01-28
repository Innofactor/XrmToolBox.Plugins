namespace Cinteros.XrmToolbox.SolutionVerifier.Utils
{
    using System.Xml;

    public static class Extensions
    {
        #region Public Methods

        public static XmlDocument ToXml(this Solution[] solutions)
        {
            var document = new XmlDocument();

            document.AppendChild(document.CreateXmlDeclaration("1.0", "UTF-8", "yes"));

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