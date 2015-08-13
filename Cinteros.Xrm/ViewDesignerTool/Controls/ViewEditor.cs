namespace Cinteros.Xrm.ViewDesignerTool.Controls
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using System.Xml;
    using System.Xml.Linq;
    using Microsoft.Xrm.Sdk;

    public partial class ViewEditor : UserControl
    {
        #region Private Fields

        private bool isFetchXmlChanged;
        private bool isLayoutXmlChanged;
        private bool isNameChanged;
        private bool isSnapped;

        #endregion Private Fields

        #region Public Constructors

        public ViewEditor()
        {
            InitializeComponent();
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

        public void Open(Entity view)
        {
            lvDesign.ColumnWidthChanged -= ViewDesigner_ColumnWidthChanged;
            lvDesign.ColumnReordered -= ViewDesigner_ColumnReordered;

            this.Id = view.Id;
            this.LogicalName = view.LogicalName;
            this.Title = (string)view.Attributes["name"];
            this.FetchXml = new XmlDocument();
            this.LayoutXml = new XmlDocument();

            this.FetchXml.LoadXml((string)view.Attributes["fetchxml"]);
            this.LayoutXml.LoadXml((string)view.Attributes["layoutxml"]);

            this.isSnapped = true;

            var columns = this.LayoutXml.SelectNodes("//cell");

            foreach (XmlNode definition in columns)
            {
                var column = new ColumnHeader();
                column.Name = definition.Attributes["name"].Value;
                column.Text = definition.Attributes["name"].Value;
                column.Width = int.Parse(definition.Attributes["width"].Value);
                column.Tag = definition;

                lvDesign.Columns.Add(column);
            }

            tbName.Text = this.Title;
            tbId.Text = this.Id.ToString();

            lvDesign.ColumnReordered += ViewDesigner_ColumnReordered;
            lvDesign.ColumnWidthChanged += ViewDesigner_ColumnWidthChanged;
        }

        public void Snap(bool allow)
        {
            if (allow)
            {
                this.isSnapped = true;

                for (var i = 0; i < lvDesign.Columns.Count; i++)
                {
                    // OnColumnWidthChanged(new ColumnWidthChangedEventArgs(i));
                }
            }
            else
            {
                this.isSnapped = false;
            }
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

        private void ViewDesigner_ColumnReordered(object sender, ColumnReorderedEventArgs e)
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

        private void ViewDesigner_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            lvDesign.ColumnWidthChanged -= ViewDesigner_ColumnWidthChanged;

            var layout = ((ListView)sender);

            var column = layout.Columns[e.ColumnIndex];
            var definition = (XmlNode)column.Tag;

            if (this.isSnapped)
            {
                column.Width = this.NormalizeWidth(column.Width);
            }

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

            lvDesign.ColumnWidthChanged += ViewDesigner_ColumnWidthChanged;
        }

        #endregion Private Methods
    }
}