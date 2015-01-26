namespace Cinteros.Solutions.Compare
{
    partial class SelectOrganizations
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
            this.gbReference = new System.Windows.Forms.GroupBox();
            this.lvReference = new System.Windows.Forms.ListView();
            this.chRefOrgName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chRefServer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gbSolutions = new System.Windows.Forms.GroupBox();
            this.lvSolutions = new System.Windows.Forms.ListView();
            this.chSolutionName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSolutionVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbOrganizations = new System.Windows.Forms.GroupBox();
            this.lvOrganizations = new System.Windows.Forms.ListView();
            this.chOrgName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOrgService = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbReference.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.gbSolutions.SuspendLayout();
            this.gbOrganizations.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbReference
            // 
            this.gbReference.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbReference.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbReference.Controls.Add(this.lvReference);
            this.gbReference.Location = new System.Drawing.Point(0, 34);
            this.gbReference.Name = "gbReference";
            this.gbReference.Size = new System.Drawing.Size(597, 89);
            this.gbReference.TabIndex = 10;
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
            this.chRefServer});
            this.lvReference.Enabled = false;
            this.lvReference.Location = new System.Drawing.Point(7, 20);
            this.lvReference.Name = "lvReference";
            this.lvReference.Size = new System.Drawing.Size(584, 63);
            this.lvReference.TabIndex = 0;
            this.lvReference.UseCompatibleStateImageBehavior = false;
            this.lvReference.View = System.Windows.Forms.View.Details;
            // 
            // chRefOrgName
            // 
            this.chRefOrgName.Text = "Organization";
            this.chRefOrgName.Width = 200;
            // 
            // chRefServer
            // 
            this.chRefServer.Text = "Server";
            this.chRefServer.Width = 400;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.gbOrganizations, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gbSolutions, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 123);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(597, 274);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // gbSolutions
            // 
            this.gbSolutions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSolutions.Controls.Add(this.lvSolutions);
            this.gbSolutions.Location = new System.Drawing.Point(3, 3);
            this.gbSolutions.Name = "gbSolutions";
            this.gbSolutions.Size = new System.Drawing.Size(292, 268);
            this.gbSolutions.TabIndex = 13;
            this.gbSolutions.TabStop = false;
            this.gbSolutions.Text = "Solutions to compare";
            // 
            // lvSolutions
            // 
            this.lvSolutions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvSolutions.CheckBoxes = true;
            this.lvSolutions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chSolutionName,
            this.chSolutionVersion});
            this.lvSolutions.FullRowSelect = true;
            this.lvSolutions.Location = new System.Drawing.Point(6, 19);
            this.lvSolutions.Name = "lvSolutions";
            this.lvSolutions.Size = new System.Drawing.Size(279, 243);
            this.lvSolutions.TabIndex = 2;
            this.lvSolutions.UseCompatibleStateImageBehavior = false;
            this.lvSolutions.View = System.Windows.Forms.View.Details;
            // 
            // chSolutionName
            // 
            this.chSolutionName.Text = "Solution";
            this.chSolutionName.Width = 200;
            // 
            // chSolutionVersion
            // 
            this.chSolutionVersion.Text = "Version";
            this.chSolutionVersion.Width = 400;
            // 
            // gbOrganizations
            // 
            this.gbOrganizations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbOrganizations.Controls.Add(this.lvOrganizations);
            this.gbOrganizations.Location = new System.Drawing.Point(301, 3);
            this.gbOrganizations.Name = "gbOrganizations";
            this.gbOrganizations.Size = new System.Drawing.Size(293, 268);
            this.gbOrganizations.TabIndex = 14;
            this.gbOrganizations.TabStop = false;
            this.gbOrganizations.Text = "Organizations to compare";
            // 
            // lvOrganizations
            // 
            this.lvOrganizations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvOrganizations.CheckBoxes = true;
            this.lvOrganizations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chOrgName,
            this.chOrgService});
            this.lvOrganizations.FullRowSelect = true;
            this.lvOrganizations.Location = new System.Drawing.Point(6, 19);
            this.lvOrganizations.Name = "lvOrganizations";
            this.lvOrganizations.Size = new System.Drawing.Size(280, 243);
            this.lvOrganizations.TabIndex = 2;
            this.lvOrganizations.UseCompatibleStateImageBehavior = false;
            this.lvOrganizations.View = System.Windows.Forms.View.Details;
            // 
            // chOrgName
            // 
            this.chOrgName.Text = "Organization";
            this.chOrgName.Width = 200;
            // 
            // chOrgService
            // 
            this.chOrgService.Text = "Server";
            this.chOrgService.Width = 400;
            // 
            // SelectOrganizations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.gbReference);
            this.Name = "SelectOrganizations";
            this.Size = new System.Drawing.Size(600, 400);
            this.gbReference.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.gbSolutions.ResumeLayout(false);
            this.gbOrganizations.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbReference;
        private System.Windows.Forms.ListView lvReference;
        private System.Windows.Forms.ColumnHeader chRefOrgName;
        private System.Windows.Forms.ColumnHeader chRefServer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox gbOrganizations;
        private System.Windows.Forms.ListView lvOrganizations;
        private System.Windows.Forms.ColumnHeader chOrgName;
        private System.Windows.Forms.ColumnHeader chOrgService;
        private System.Windows.Forms.GroupBox gbSolutions;
        private System.Windows.Forms.ListView lvSolutions;
        private System.Windows.Forms.ColumnHeader chSolutionName;
        private System.Windows.Forms.ColumnHeader chSolutionVersion;

    }
}
