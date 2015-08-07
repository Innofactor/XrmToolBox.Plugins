namespace Cinteros.Xrm.ViewDesignerTool.AppCode
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using System.Xml;
    using System.Xml.Linq;
    using Microsoft.Xrm.Sdk;

    public class LayoutDesigner : ListView
    {
        #region Private Fields

        private bool isFetchXmlChanged;
        private bool isLayoutXmlChanged;
        private bool isNameChanged;

        #endregion Private Fields

        #region Public Constructors

        public LayoutDesigner()
            : base()
        {
            this.View = View.Details;
            this.FullRowSelect = true;
            this.GridLines = true;
            this.AllowColumnReorder = true;

            ColumnReordered += LayoutDesigner_ColumnReordered;
        }

        public LayoutDesigner(Entity view)
            : this()
        {
            this.Load(view);
        }

        #endregion Public Constructors

        #region Public Properties

        public XmlDocument FetchXml
        {
            get;
            private set;
        }

        public Guid Id
        {
            get;
            private set;
        }

        public XmlDocument LayoutXml
        {
            get;
            private set;
        }

        public string LogicalName { get; set; }

        public string Title { get; set; }

        #endregion Public Properties

        #region Public Methods

        public void Load(Entity view)
        {
            ColumnWidthChanged -= LayoutDesigner_ColumnWidthChanged;

            this.Id = view.Id;
            this.LogicalName = view.LogicalName;
            this.Title = (string)view.Attributes["name"];
            this.FetchXml = new XmlDocument();
            this.LayoutXml = new XmlDocument();

            this.FetchXml.LoadXml((string)view.Attributes["fetchxml"]);
            this.LayoutXml.LoadXml((string)view.Attributes["layoutxml"]);

            var columns = this.LayoutXml.SelectNodes("//cell");

            foreach (XmlNode definition in columns)
            {
                var column = new ColumnHeader();
                column.Name = definition.Attributes["name"].Value;
                column.Text = definition.Attributes["name"].Value;
                column.Width = int.Parse(definition.Attributes["width"].Value);
                column.Tag = definition;

                this.Columns.Add(column);
            }

            ColumnWidthChanged += LayoutDesigner_ColumnWidthChanged;
        }

        #endregion Public Methods

        #region Internal Methods

        internal Entity ToEntity()
        {
            var entity = new Entity(this.LogicalName);
            entity.Id = this.Id;

            if (this.isNameChanged)
            {
                entity.Attributes["name"] = this.Title;
            }

            if (this.isFetchXmlChanged)
            {
                entity.Attributes["fetchxml"] = this.FetchXml.OuterXml;
            }

            if (this.isLayoutXmlChanged)
            {
                entity.Attributes["layoutxml"] = this.LayoutXml.OuterXml;
            }

            return entity;
        }

        #endregion Internal Methods

        #region Private Methods

        private void LayoutDesigner_ColumnReordered(object sender, ColumnReorderedEventArgs e)
        {
            var layout = XDocument.Parse(this.LayoutXml.OuterXml);

            var cells = layout.Descendants().First().Descendants().First().Descendants();

            var source = cells.ElementAt(e.OldDisplayIndex);
            var target = cells.ElementAt(e.NewDisplayIndex);

            if (e.OldDisplayIndex > e.NewDisplayIndex)
            {
                target.AddBeforeSelf(source);
            }
            else
            {
                target.AddAfterSelf(source);
            }

            source.Remove();

            this.LayoutXml.LoadXml(layout.ToString());

            this.isLayoutXmlChanged = true;
        }

        private void LayoutDesigner_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            ColumnWidthChanged -= LayoutDesigner_ColumnWidthChanged;

            var layout = ((LayoutDesigner)sender);

            var column = layout.Columns[e.ColumnIndex];
            var definition = (XmlNode)column.Tag;

            column.Width = this.NormalizeWidth(column.Width);

            var attribute = definition.Attributes["width"];
            var width = column.Width.ToString();

            if (!attribute.Value.Equals(width))
            {
                attribute.Value = width;

                var pattern = string.Format("//cell[@name=\"{0}\"]", definition.Attributes["name"].Value);
                var cell = this.LayoutXml.SelectNodes(pattern).Cast<XmlNode>().FirstOrDefault();
                cell = definition;

                this.isLayoutXmlChanged = true;
            }

            ColumnWidthChanged += LayoutDesigner_ColumnWidthChanged;
        }

        private int NormalizeWidth(int width)
        {
            if (width < 25)
            {
                width = 25;
            }
            else if (width > 25 && width < 150)
            {
                width = (int)Math.Round((decimal)(width / 25)) * 25;
            }
            else if (width > 150 && width < 200)
            {
                width = (int)Math.Round((decimal)((width - 150) / 50)) * 50 + 150;
            }
            else if (width > 200 && width < 300)
            {
                width = (int)Math.Round((decimal)((width - 200) / 100)) * 100 + 200;
            }
            else if (width > 300)
            {
                width = 300;
            }

            return width;
        }

        #endregion Private Methods
    }
}