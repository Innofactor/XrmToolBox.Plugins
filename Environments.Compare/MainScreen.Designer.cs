namespace Environments.Compare
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
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSelectOrganizations = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCompareSolutions = new System.Windows.Forms.ToolStripButton();
            this.tsMenu.SuspendLayout();
            this.SuspendLayout();
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
            this.tsMenu.Size = new System.Drawing.Size(600, 25);
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
            // tsbCompareSolutions
            // 
            this.tsbCompareSolutions.Image = ((System.Drawing.Image)(resources.GetObject("tsbCompareSolutions.Image")));
            this.tsbCompareSolutions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCompareSolutions.Name = "tsbCompareSolutions";
            this.tsbCompareSolutions.Size = new System.Drawing.Size(127, 22);
            this.tsbCompareSolutions.Text = "Compare solutions";
            this.tsbCompareSolutions.Click += new System.EventHandler(this.tsbCompareSolutions_Click);
            // 
            // StartingPoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tsMenu);
            this.Name = "StartingPoint";
            this.Size = new System.Drawing.Size(600, 400);
            this.Load += new System.EventHandler(this.EnvironmentsSelector_Load);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripButton tsbCompareSolutions;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbSelectOrganizations;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}
