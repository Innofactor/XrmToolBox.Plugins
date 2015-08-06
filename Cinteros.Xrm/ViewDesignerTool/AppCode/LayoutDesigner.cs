namespace Cinteros.Xrm.ViewDesignerTool.AppCode
{
    using System.Windows.Forms;
    using System.Xml;
    using Microsoft.Xrm.Sdk;

    public class LayoutDesigner : ListView
    {
        #region Public Constructors

        public LayoutDesigner(Entity view)
            : base()
        {
            this.View = View.Details;

            this.Name = (string)view.Attributes["name"];
            this.FetchXml = new XmlDocument();
            this.LayoutXml = new XmlDocument();

            this.FetchXml.LoadXml((string)view.Attributes["fetchxml"]);
            this.LayoutXml.LoadXml((string)view.Attributes["layoutxml"]);

            var columns = this.LayoutXml.SelectNodes("//cell");

            foreach (XmlNode column in columns)
            {
                var header = new ColumnHeader();
                header.Name = column.Attributes["name"].Value;
                header.Text = column.Attributes["name"].Value;
                header.Width = int.Parse(column.Attributes["width"].Value);

                this.Columns.Add(header);
            }
        }

        #endregion Public Constructors

        #region Public Properties

        public XmlDocument FetchXml
        {
            get;
            set;
        }

        public XmlDocument LayoutXml
        {
            get;
            set;
        }

        #endregion Public Properties
    }
}