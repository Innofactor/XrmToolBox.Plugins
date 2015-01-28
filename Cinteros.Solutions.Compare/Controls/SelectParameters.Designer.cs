namespace Cinteros.XrmToolbox.Compare.Controls
{
    partial class SelectParameters
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
            this.gbOrganizations = new System.Windows.Forms.GroupBox();
            this.cbToggleOrganizations = new System.Windows.Forms.CheckBox();
            this.lvOrganizations = new System.Windows.Forms.ListView();
            this.chOrgName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOrgService = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbSolutions = new System.Windows.Forms.GroupBox();
            this.cbToggleSolutions = new System.Windows.Forms.CheckBox();
            this.lvSolutions = new System.Windows.Forms.ListView();
            this.chSolutionName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSolutionVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbReference.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.gbOrganizations.SuspendLayout();
            this.gbSolutions.SuspendLayout();
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
            this.gbReference.Size = new System.Drawing.Size(597, 76);
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
            this.lvReference.Size = new System.Drawing.Size(584, 50);
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
            this.chRefServer.Width = 200;
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 113);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(597, 284);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // gbOrganizations
            // 
            this.gbOrganizations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbOrganizations.Controls.Add(this.cbToggleOrganizations);
            this.gbOrganizations.Controls.Add(this.lvOrganizations);
            this.gbOrganizations.Location = new System.Drawing.Point(301, 3);
            this.gbOrganizations.Name = "gbOrganizations";
            this.gbOrganizations.Size = new System.Drawing.Size(293, 278);
            this.gbOrganizations.TabIndex = 14;
            this.gbOrganizations.TabStop = false;
            this.gbOrganizations.Text = "Organizations to compare";
            // 
            // cbToggleOrganizations
            // 
            this.cbToggleOrganizations.AutoSize = true;
            this.cbToggleOrganizations.Location = new System.Drawing.Point(6, 19);
            this.cbToggleOrganizations.Name = "cbToggleOrganizations";
            this.cbToggleOrganizations.Size = new System.Drawing.Size(69, 17);
            this.cbToggleOrganizations.TabIndex = 4;
            this.cbToggleOrganizations.Text = "Select all";
            this.cbToggleOrganizations.UseVisualStyleBackColor = true;
            this.cbToggleOrganizations.CheckedChanged += new System.EventHandler(this.cbToggleOrganizations_CheckedChanged);
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
            this.lvOrganizations.Location = new System.Drawing.Point(6, 42);
            this.lvOrganizations.Name = "lvOrganizations";
            this.lvOrganizations.Size = new System.Drawing.Size(280, 230);
            this.lvOrganizations.TabIndex = 2;
            this.lvOrganizations.UseCompatibleStateImageBehavior = false;
            this.lvOrganizations.View = System.Windows.Forms.View.Details;
            this.lvOrganizations.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvOrganizations_ItemChecked);
            this.lvOrganizations.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvOrganizations_ItemSelectionChanged);
            // 
            // chOrgName
            // 
            this.chOrgName.Text = "Organization";
            this.chOrgName.Width = 200;
            // 
            // chOrgService
            // 
            this.chOrgService.Text = "Server";
            this.chOrgService.Width = 200;
            // 
            // gbSolutions
            // 
            this.gbSolutions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSolutions.Controls.Add(this.cbToggleSolutions);
            this.gbSolutions.Controls.Add(this.lvSolutions);
            this.gbSolutions.Location = new System.Drawing.Point(3, 3);
            this.gbSolutions.Name = "gbSolutions";
            this.gbSolutions.Size = new System.Drawing.Size(292, 278);
            this.gbSolutions.TabIndex = 13;
            this.gbSolutions.TabStop = false;
            this.gbSolutions.Text = "Solutions to compare";
            // 
            // cbToggleSolutions
            // 
            this.cbToggleSolutions.AutoSize = true;
            this.cbToggleSolutions.Location = new System.Drawing.Point(6, 19);
            this.cbToggleSolutions.Name = "cbToggleSolutions";
            this.cbToggleSolutions.Size = new System.Drawing.Size(69, 17);
            this.cbToggleSolutions.TabIndex = 3;
            this.cbToggleSolutions.Text = "Select all";
            this.cbToggleSolutions.UseVisualStyleBackColor = true;
            this.cbToggleSolutions.CheckedChanged += new System.EventHandler(this.cbToggleSolutions_CheckedChanged);
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
            this.lvSolutions.Location = new System.Drawing.Point(6, 42);
            this.lvSolutions.Name = "lvSolutions";
            this.lvSolutions.Size = new System.Drawing.Size(279, 230);
            this.lvSolutions.TabIndex = 2;
            this.lvSolutions.UseCompatibleStateImageBehavior = false;
            this.lvSolutions.View = System.Windows.Forms.View.Details;
            this.lvSolutions.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvSolutions_ItemChecked);
            this.lvSolutions.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvSolutions_ItemSelectionChanged);
            // 
            // chSolutionName
            // 
            this.chSolutionName.Text = "Solution";
            this.chSolutionName.Width = 200;
            // 
            // chSolutionVersion
            // 
            this.chSolutionVersion.Text = "Version";
            this.chSolutionVersion.Width = 200;
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
            this.gbOrganizations.ResumeLayout(false);
            this.gbOrganizations.PerformLayout();
            this.gbSolutions.ResumeLayout(false);
            this.gbSolutions.PerformLayout();
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
        private System.Windows.Forms.CheckBox cbToggleOrganizations;
        private System.Windows.Forms.CheckBox cbToggleSolutions;

    }
}
