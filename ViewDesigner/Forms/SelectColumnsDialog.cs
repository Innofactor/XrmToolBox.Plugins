namespace Cinteros.XTB.ViewDesigner.Forms
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using System.Xml;

    public partial class SelectColumnsDialog : Form
    {
        #region Public Constructors

        public SelectColumnsDialog(XmlDocument fetchXml, XmlDocument layoutXml)
            : this()
        {
            this.LayoutXml = layoutXml;
            var allowed = GetAttributesFromFetch(fetchXml.SelectSingleNode("fetch/entity"));
            var selected = this.LayoutXml.SelectNodes("//cell");

            foreach (var column in allowed)
            {
                var item = selected.Cast<XmlNode>().Where(x => x.Attributes["name"].Value == column).FirstOrDefault();

                var status = (item != null) ? true : false;

                clbColumns.Items.Add(column, status);
            }

            foreach (var oldcol in selected.Cast<XmlNode>())
            {
                var oldcolname = oldcol.Attributes["name"].Value;
                if (!clbColumns.Items.Contains(oldcolname))
                {
                    var i = clbColumns.Items.Add(oldcolname, false);
                }
            }
        }

        #endregion Public Constructors

        #region Private Constructors

        private SelectColumnsDialog()
        {
            InitializeComponent();
        }

        #endregion Private Constructors

        #region Public Properties

        public XmlDocument LayoutXml
        {
            get;
            private set;
        }

        #endregion Public Properties

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            var row = this.LayoutXml.SelectNodes("//row").Cast<XmlNode>().FirstOrDefault();
            foreach (var item in clbColumns.CheckedItems)
            {
                var pattern = string.Format("//cell[@name='{0}']", item.ToString());
                var cell = this.LayoutXml.SelectNodes(pattern).Cast<XmlNode>().FirstOrDefault();
                if (cell == null)
                {
                    cell = this.LayoutXml.CreateNode(XmlNodeType.Element, "cell", string.Empty);
                    var attribute = this.LayoutXml.CreateAttribute("name");
                    attribute.Value = item.ToString();
                    cell.Attributes.Append(attribute);
                    attribute = this.LayoutXml.CreateAttribute("width");
                    attribute.Value = 100.ToString();
                    cell.Attributes.Append(attribute);
                    row.AppendChild(cell);
                }
            }
            var removeNodes = new List<XmlNode>();
            foreach (var cell in this.LayoutXml.SelectNodes("//cell").Cast<XmlNode>())
            {
                var col = cell.Attributes["name"].Value;
                if (!clbColumns.CheckedItems.Contains(col))
                {
                    removeNodes.Add(cell);
                }
            }
            foreach (var node in removeNodes)
            {
                row.RemoveChild(node);
            }
        }

        private List<string> GetAttributesFromFetch(XmlNode entity)
        {
            var result = new List<string>();
            if (entity != null)
            {
                var alias = entity.Attributes["alias"] != null ? entity.Attributes["alias"].Value + "." : "";
                var entityAttributes = entity.SelectNodes("attribute");
                foreach (XmlNode attr in entityAttributes)
                {
                    if (attr.Attributes["alias"] != null)
                    {
                        result.Add(alias + attr.Attributes["alias"].Value);
                    }
                    else if (attr.Attributes["name"] != null)
                    {
                        result.Add(alias + attr.Attributes["name"].Value);
                    }
                }
                var linkEntities = entity.SelectNodes("link-entity");
                foreach (XmlNode link in linkEntities)
                {
                    result.AddRange(GetAttributesFromFetch(link));
                }
            }
            return result;
        }
    }
}