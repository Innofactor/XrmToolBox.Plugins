namespace Cinteros.XrmToolbox.SolutionVerifier
{
    partial class MainScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScreen));
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tsbBack = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsddOpen = new System.Windows.Forms.ToolStripDropDownButton();
            this.fromConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromReferenceFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCompare = new System.Windows.Forms.ToolStripButton();
            this.tsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMenu
            // 
            this.tsMenu.AccessibleName = "Menu";
            this.tsMenu.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.tsbBack,
            this.toolStripSeparator1,
            this.tsddOpen,
            this.tsbSave,
            this.toolStripSeparator2,
            this.tsbCompare});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(600, 25);
            this.tsMenu.TabIndex = 10;
            this.tsMenu.Text = "toolStrip1";
            // 
            // tsbClose
            // 
            this.tsbClose.Image = ((System.Drawing.Image)(resources.GetObject("tsbClose.Image")));
            this.tsbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(56, 22);
            this.tsbClose.Text = "Close";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tsbBack
            // 
            this.tsbBack.Enabled = false;
            this.tsbBack.Image = ((System.Drawing.Image)(resources.GetObject("tsbBack.Image")));
            this.tsbBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBack.Name = "tsbBack";
            this.tsbBack.Size = new System.Drawing.Size(52, 22);
            this.tsbBack.Text = "Back";
            this.tsbBack.Click += new System.EventHandler(this.tsbSelectOrganizations_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsddOpen
            // 
            this.tsddOpen.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fromConnectionToolStripMenuItem,
            this.fromReferenceFileToolStripMenuItem});
            this.tsddOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsddOpen.Image")));
            this.tsddOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddOpen.Name = "tsddOpen";
            this.tsddOpen.Size = new System.Drawing.Size(103, 22);
            this.tsddOpen.Text = "Open from...";
            // 
            // fromConnectionToolStripMenuItem
            // 
            this.fromConnectionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("fromConnectionToolStripMenuItem.Image")));
            this.fromConnectionToolStripMenuItem.Name = "fromConnectionToolStripMenuItem";
            this.fromConnectionToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.fromConnectionToolStripMenuItem.Text = "Current connection";
            // 
            // fromReferenceFileToolStripMenuItem
            // 
            this.fromReferenceFileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("fromReferenceFileToolStripMenuItem.Image")));
            this.fromReferenceFileToolStripMenuItem.Name = "fromReferenceFileToolStripMenuItem";
            this.fromReferenceFileToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.fromReferenceFileToolStripMenuItem.Text = "Reference file...";
            this.fromReferenceFileToolStripMenuItem.Click += new System.EventHandler(this.fromReferenceFileToolStripMenuItem_Click);
            // 
            // tsbSave
            // 
            this.tsbSave.Enabled = false;
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(93, 22);
            this.tsbSave.Text = "Save to file...";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbCompare
            // 
            this.tsbCompare.Enabled = false;
            this.tsbCompare.Image = ((System.Drawing.Image)(resources.GetObject("tsbCompare.Image")));
            this.tsbCompare.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCompare.Name = "tsbCompare";
            this.tsbCompare.Size = new System.Drawing.Size(127, 22);
            this.tsbCompare.Text = "Compare solutions";
            this.tsbCompare.Click += new System.EventHandler(this.tsbCompare_Click);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tsMenu);
            this.Name = "MainScreen";
            this.Size = new System.Drawing.Size(600, 400);
            this.Load += new System.EventHandler(this.MainScreen_Load);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripButton tsbCompare;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbBack;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripDropDownButton tsddOpen;
        private System.Windows.Forms.ToolStripMenuItem fromConnectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromReferenceFileToolStripMenuItem;
    }
}
