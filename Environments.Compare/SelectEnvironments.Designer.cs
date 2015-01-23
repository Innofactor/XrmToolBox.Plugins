namespace Environments.Compare
{
    partial class SelectEnvironments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectEnvironments));
            this.gbReference = new System.Windows.Forms.GroupBox();
            this.lvReference = new System.Windows.Forms.ListView();
            this.chRefOrgName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chRefOrgUrl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chRefVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbOrganizations = new System.Windows.Forms.GroupBox();
            this.lvOrganizations = new System.Windows.Forms.ListView();
            this.chOrgName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOrgUrl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOrgVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tsbCompareSolutions = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSelectOrganizations = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.gbReference.SuspendLayout();
            this.gbOrganizations.SuspendLayout();
            this.tsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbReference
            // 
            this.gbReference.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbReference.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbReference.Controls.Add(this.lvReference);
            this.gbReference.Location = new System.Drawing.Point(7, 34);
            this.gbReference.Name = "gbReference";
            this.gbReference.Size = new System.Drawing.Size(486, 89);
            this.gbReference.TabIndex = 8;
            this.gbReference.TabStop = false;
            this.gbReference.Text = "Reference organization";
            // 
            // lvReference
            // 
            this.lvReference.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvReference.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chRefOrgName,
            this.chRefOrgUrl,
            this.chRefVersion});
            this.lvReference.Location = new System.Drawing.Point(7, 20);
            this.lvReference.Name = "lvReference";
            this.lvReference.Size = new System.Drawing.Size(473, 63);
            this.lvReference.TabIndex = 0;
            this.lvReference.UseCompatibleStateImageBehavior = false;
            this.lvReference.View = System.Windows.Forms.View.Details;
            // 
            // chRefOrgName
            // 
            this.chRefOrgName.Text = "Organization";
            this.chRefOrgName.Width = 200;
            // 
            // chRefOrgUrl
            // 
            this.chRefOrgUrl.Text = "URL";
            this.chRefOrgUrl.Width = 500;
            // 
            // chRefVersion
            // 
            this.chRefVersion.Text = "Version";
            this.chRefVersion.Width = 100;
            // 
            // gbOrganizations
            // 
            this.gbOrganizations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbOrganizations.Controls.Add(this.lvOrganizations);
            this.gbOrganizations.Location = new System.Drawing.Point(7, 129);
            this.gbOrganizations.Name = "gbOrganizations";
            this.gbOrganizations.Size = new System.Drawing.Size(486, 307);
            this.gbOrganizations.TabIndex = 9;
            this.gbOrganizations.TabStop = false;
            this.gbOrganizations.Text = "Organizations to compare";
            // 
            // lvOrganizations
            // 
            this.lvOrganizations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvOrganizations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chOrgName,
            this.chOrgUrl,
            this.chOrgVersion});
            this.lvOrganizations.FullRowSelect = true;
            this.lvOrganizations.Location = new System.Drawing.Point(6, 19);
            this.lvOrganizations.Name = "lvOrganizations";
            this.lvOrganizations.Size = new System.Drawing.Size(473, 282);
            this.lvOrganizations.TabIndex = 2;
            this.lvOrganizations.UseCompatibleStateImageBehavior = false;
            this.lvOrganizations.View = System.Windows.Forms.View.Details;
            // 
            // chOrgName
            // 
            this.chOrgName.Text = "Organization";
            this.chOrgName.Width = 200;
            // 
            // chOrgUrl
            // 
            this.chOrgUrl.Text = "URL";
            this.chOrgUrl.Width = 500;
            // 
            // chOrgVersion
            // 
            this.chOrgVersion.Text = "Version";
            this.chOrgVersion.Width = 100;
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.toolStripSeparator1,
            this.tsbSelectOrganizations,
            this.toolStripSeparator2,
            this.tsbCompareSolutions});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(496, 25);
            this.tsMenu.TabIndex = 10;
            this.tsMenu.Text = "toolStrip1";
            // 
            // tsbClose
            // 
            this.tsbClose.Image = ((System.Drawing.Image)(resources.GetObject("tsbClose.Image")));
            this.tsbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(102, 22);
            this.tsbClose.Text = "Close this tool";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tsbCompareSolutions
            // 
            this.tsbCompareSolutions.Image = ((System.Drawing.Image)(resources.GetObject("tsbCompareSolutions.Image")));
            this.tsbCompareSolutions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCompareSolutions.Name = "tsbCompareSolutions";
            this.tsbCompareSolutions.Size = new System.Drawing.Size(127, 22);
            this.tsbCompareSolutions.Text = "Compare solutions";
            this.tsbCompareSolutions.Click += new System.EventHandler(this.tsbCompareSolutions_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbSelectOrganizations
            // 
            this.tsbSelectOrganizations.Enabled = false;
            this.tsbSelectOrganizations.Image = ((System.Drawing.Image)(resources.GetObject("tsbSelectOrganizations.Image")));
            this.tsbSelectOrganizations.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSelectOrganizations.Name = "tsbSelectOrganizations";
            this.tsbSelectOrganizations.Size = new System.Drawing.Size(132, 22);
            this.tsbSelectOrganizations.Text = "Select organizations";
            this.tsbSelectOrganizations.Click += new System.EventHandler(this.tsbSelectOrganizations_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // SelectEnvironments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tsMenu);
            this.Controls.Add(this.gbOrganizations);
            this.Controls.Add(this.gbReference);
            this.Name = "SelectEnvironments";
            this.Size = new System.Drawing.Size(496, 439);
            this.Load += new System.EventHandler(this.EnvironmentsSelector_Load);
            this.gbReference.ResumeLayout(false);
            this.gbOrganizations.ResumeLayout(false);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbReference;
        private System.Windows.Forms.GroupBox gbOrganizations;
        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripButton tsbCompareSolutions;
        private System.Windows.Forms.ListView lvReference;
        private System.Windows.Forms.ColumnHeader chRefOrgName;
        private System.Windows.Forms.ListView lvOrganizations;
        private System.Windows.Forms.ColumnHeader chOrgName;
        private System.Windows.Forms.ColumnHeader chOrgUrl;
        private System.Windows.Forms.ColumnHeader chRefOrgUrl;
        private System.Windows.Forms.ColumnHeader chRefVersion;
        private System.Windows.Forms.ColumnHeader chOrgVersion;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbSelectOrganizations;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}
