namespace Cinteros.XTB.ViewDesigner.Controls
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using System.Xml;
    using System.Xml.Linq;
    using Microsoft.Xrm.Sdk;
    using System.Collections.Generic;
    using Forms;
    public partial class ViewEditor : UserControl
    {
        #region Private Fields

        private static List<int> snapWidths = new List<int>(new int[] { 25, 50, 75, 100, 125, 150, 200, 300 });
        private bool isTitleChanged;

        #endregion Private Fields

        #region Public Constructors

        public ViewEditor()
        {
            InitializeComponent();
        }

        #endregion Public Constructors

        #region Public Properties

        public bool IsFetchXmlChanged { get; set; }
        public bool IsLayoutXmlChanged { get; set; }

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

        public bool Snapped { get; private set; }

        public string LogicalName { get; set; }

        public string ViewEntityName { get; set; }

        public string Title { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Updates view designer with most recent definition of the view
        /// </summary>
        /// <param name="view"></param>
        public void Set(Entity view)
        {
            lvDesign.ColumnWidthChanged -= lvDesign_ColumnWidthChanged;
            lvDesign.ColumnReordered -= lvDesign_ColumnReordered;

            this.UpdateTitle(view);
            this.UpdateId(view);
            this.UpdateLogicalName(view);
            this.UpdateFetchXml(view);
            this.UpdateLayoutXml(view);

            lvDesign.ColumnReordered += lvDesign_ColumnReordered;
            lvDesign.ColumnWidthChanged += lvDesign_ColumnWidthChanged;
        }

        /// <summary>
        /// Snaps columns width for standard values used in CRM (25..300)
        /// </summary>
        /// <param name="allow"></param>
        public void Snap(bool allow)
        {
            if (allow)
            {
                this.Snapped = true;

                for (var i = 0; i < lvDesign.Columns.Count; i++)
                {
                    lvDesign.Columns[i].Width += 1;
                }
            }
            else
            {
                this.Snapped = false;
            }
        }

        #endregion Public Methods

        #region Internal Methods

        /// <summary>
        /// Combines all information about design to CRM entity representation. Only changed
        /// attributes will be added
        /// </summary>
        /// <returns></returns>
        internal Entity ToEntity()
        {
            var entity = new Entity(this.LogicalName);
            entity.Id = this.Id;

            if (this.isTitleChanged)
            {
                entity.Attributes["name"] = this.Title;
            }

            if (this.IsFetchXmlChanged)
            {
                entity.Attributes["fetchxml"] = this.FetchXml.OuterXml;
            }

            if (this.IsLayoutXmlChanged)
            {
                entity.Attributes["layoutxml"] = this.LayoutXml.OuterXml;
            }

            return entity;
        }

        #endregion Internal Methods

        #region Private Methods

        private void lvDesign_ColumnReordered(object sender, ColumnReorderedEventArgs e)
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

            this.IsLayoutXmlChanged = true;
        }

        private void lvDesign_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            lvDesign.ColumnWidthChanged -= lvDesign_ColumnWidthChanged;

            var layout = ((ListView)sender);

            var column = layout.Columns[e.ColumnIndex];
            var definition = (XmlNode)column.Tag;

            if (this.Snapped)
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

                this.IsLayoutXmlChanged = true;
            }

            lvDesign.ColumnWidthChanged += lvDesign_ColumnWidthChanged;
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

        private void UpdateFetchXml(Entity view)
        {
            if (view.Attributes.ContainsKey("fetchxml"))
            {
                this.FetchXml = new XmlDocument();
                this.FetchXml.LoadXml((string)view.Attributes["fetchxml"]);
                var entity = this.FetchXml.SelectSingleNode("fetch/entity");
                this.ViewEntityName = entity != null && entity.Attributes["name"] != null ? entity.Attributes["name"].Value : "";
            }
        }

        private void UpdateId(Entity view)
        {
            if (!view.Id.Equals(Guid.Empty))
            {
                this.Id = view.Id;
                tbId.Text = this.Id.ToString();
            }
        }

        private void UpdateLayoutXml(Entity view)
        {
            if (view.Attributes.ContainsKey("layoutxml"))
            {
                this.LayoutXml = new XmlDocument();
                this.LayoutXml.LoadXml((string)view.Attributes["layoutxml"]);

                this.Snapped = true;

                var columns = this.LayoutXml.SelectNodes("//cell");

                lvDesign.Columns.Clear();

                foreach (XmlNode definition in columns)
                {
                    var column = new ColumnHeader();
                    column.Name = definition.Attributes["name"].Value;
                    column.Text = definition.Attributes["name"].Value;
                    column.Width = int.Parse(definition.Attributes["width"].Value);
                    column.Tag = definition;
                    if (!snapWidths.Contains(column.Width))
                    {
                        Snapped = false;
                    }

                    lvDesign.Columns.Add(column);
                }
            }
        }

        private void UpdateLogicalName(Entity view)
        {
            if (view.LogicalName != null && !view.LogicalName.Equals(string.Empty))
            {
                this.LogicalName = view.LogicalName;
            }
        }

        private void UpdateTitle(Entity view)
        {
            if (view.Attributes.ContainsKey("name"))
            {
                this.Title = (string)view.Attributes["name"];
                tbName.Text = this.Title;
            }
        }

        private void ViewDesigner_TextChanged(object sender, EventArgs e)
        {
            var title = (TextBox)sender;
            this.Title = title.Text;
            this.isTitleChanged = true;
        }

        #endregion Private Methods

        private void lvDesign_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            var column = ((ListView)sender).Columns[e.Column];

            var setSizeDialog = new SetSizeDialog(column.Name, column.Width);
            setSizeDialog.StartPosition = FormStartPosition.CenterParent;
            setSizeDialog.OnSet += (o, size) =>
            {
                column.Width = size;
            };

            setSizeDialog.ShowDialog();
        }
        
    }
}