namespace Cinteros.XTB.ViewDesigner
{
    partial class MainControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainControl));
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbPublish = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSelectColumns = new System.Windows.Forms.ToolStripButton();
            this.tsbSnap = new System.Windows.Forms.ToolStripButton();
            this.tsbEditFetch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEditXml = new System.Windows.Forms.ToolStripButton();
            this.ViewEditor = new Cinteros.XTB.ViewDesigner.Controls.ViewEditor();
            this.tsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.toolStripSeparator1,
            this.tsbOpen,
            this.toolStripSeparator5,
            this.tsbSave,
            this.tsbPublish,
            this.toolStripSeparator3,
            this.tsbSelectColumns,
            this.tsbSnap,
            this.toolStripSeparator2,
            this.tsbEditFetch,
            this.tsbEditXml});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(600, 25);
            this.tsMenu.TabIndex = 1;
            this.tsMenu.Text = "toolStrip1";
            // 
            // tsbClose
            // 
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbClose.Image = ((System.Drawing.Image)(resources.GetObject("tsbClose.Image")));
            this.tsbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(23, 22);
            this.tsbClose.Text = "Close";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbOpen
            // 
            this.tsbOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsbOpen.Image")));
            this.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpen.Name = "tsbOpen";
            this.tsbOpen.Size = new System.Drawing.Size(65, 22);
            this.tsbOpen.Text = "Open...";
            this.tsbOpen.Click += new System.EventHandler(this.tsbOpen_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbSave
            // 
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(51, 22);
            this.tsbSave.Text = "Save";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // tsbPublish
            // 
            this.tsbPublish.Image = ((System.Drawing.Image)(resources.GetObject("tsbPublish.Image")));
            this.tsbPublish.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPublish.Name = "tsbPublish";
            this.tsbPublish.Size = new System.Drawing.Size(66, 22);
            this.tsbPublish.Text = "Publish";
            this.tsbPublish.Click += new System.EventHandler(this.tsbPublish_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbSelectColumns
            // 
            this.tsbSelectColumns.Image = ((System.Drawing.Image)(resources.GetObject("tsbSelectColumns.Image")));
            this.tsbSelectColumns.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSelectColumns.Name = "tsbSelectColumns";
            this.tsbSelectColumns.Size = new System.Drawing.Size(109, 22);
            this.tsbSelectColumns.Text = "Select Columns";
            this.tsbSelectColumns.Click += new System.EventHandler(this.tsbEditColumns_Click);
            // 
            // tsbSnap
            // 
            this.tsbSnap.Checked = true;
            this.tsbSnap.CheckOnClick = true;
            this.tsbSnap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsbSnap.Image = ((System.Drawing.Image)(resources.GetObject("tsbSnap.Image")));
            this.tsbSnap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSnap.Name = "tsbSnap";
            this.tsbSnap.Size = new System.Drawing.Size(92, 22);
            this.tsbSnap.Text = "Snap to Grid";
            this.tsbSnap.Click += new System.EventHandler(this.tsbSnap_Click);
            // 
            // tsbEditFetch
            // 
            this.tsbEditFetch.Image = ((System.Drawing.Image)(resources.GetObject("tsbEditFetch.Image")));
            this.tsbEditFetch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditFetch.Name = "tsbEditFetch";
            this.tsbEditFetch.Size = new System.Drawing.Size(82, 22);
            this.tsbEditFetch.Text = "Edit Query";
            this.tsbEditFetch.Click += new System.EventHandler(this.tsbEditFetch_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbEditXml
            // 
            this.tsbEditXml.Image = ((System.Drawing.Image)(resources.GetObject("tsbEditXml.Image")));
            this.tsbEditXml.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditXml.Name = "tsbEditXml";
            this.tsbEditXml.Size = new System.Drawing.Size(74, 22);
            this.tsbEditXml.Text = "Edit XML";
            this.tsbEditXml.Click += new System.EventHandler(this.tsbEditXml_Click);
            // 
            // ViewEditor
            // 
            this.ViewEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ViewEditor.Enabled = false;
            this.ViewEditor.IsFetchXmlChanged = false;
            this.ViewEditor.IsLayoutXmlChanged = false;
            this.ViewEditor.Location = new System.Drawing.Point(0, 25);
            this.ViewEditor.LogicalName = null;
            this.ViewEditor.Name = "ViewEditor";
            this.ViewEditor.Size = new System.Drawing.Size(600, 375);
            this.ViewEditor.TabIndex = 2;
            this.ViewEditor.Title = null;
            this.ViewEditor.ViewEntityName = null;
            // 
            // MainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ViewEditor);
            this.Controls.Add(this.tsMenu);
            this.Name = "MainControl";
            this.Size = new System.Drawing.Size(600, 400);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbPublish;
        private System.Windows.Forms.ToolStripButton tsbEditFetch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tsbSnap;
        private System.Windows.Forms.ToolStripButton tsbSelectColumns;
        private Controls.ViewEditor ViewEditor;
        private System.Windows.Forms.ToolStripButton tsbEditXml;
    }
}
