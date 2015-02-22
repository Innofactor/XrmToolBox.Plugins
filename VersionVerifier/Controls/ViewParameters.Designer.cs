namespace Cinteros.Xrm.VersionVerifier.Controls
{
    partial class ViewParameters
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gbOrganizations = new System.Windows.Forms.GroupBox();
            this.cbToggleOrganizations = new System.Windows.Forms.CheckBox();
            this.lvOrganizations = new System.Windows.Forms.ListView();
            this.chOrgName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOrgService = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbSnapshot = new System.Windows.Forms.GroupBox();
            this.cbToggleSolutions = new System.Windows.Forms.CheckBox();
            this.lvSnapshot = new System.Windows.Forms.ListView();
            this.chItemName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chItemVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel1.SuspendLayout();
            this.gbOrganizations.SuspendLayout();
            this.gbSnapshot.SuspendLayout();
            this.SuspendLayout();
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
            this.tableLayoutPanel1.Controls.Add(this.gbSnapshot, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 34);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(597, 363);
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
            this.gbOrganizations.Size = new System.Drawing.Size(293, 357);
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
            this.lvOrganizations.GridLines = true;
            this.lvOrganizations.Location = new System.Drawing.Point(6, 42);
            this.lvOrganizations.Name = "lvOrganizations";
            this.lvOrganizations.Size = new System.Drawing.Size(280, 309);
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
            // gbSnapshot
            // 
            this.gbSnapshot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSnapshot.Controls.Add(this.cbToggleSolutions);
            this.gbSnapshot.Controls.Add(this.lvSnapshot);
            this.gbSnapshot.Location = new System.Drawing.Point(3, 3);
            this.gbSnapshot.Name = "gbSnapshot";
            this.gbSnapshot.Size = new System.Drawing.Size(292, 357);
            this.gbSnapshot.TabIndex = 13;
            this.gbSnapshot.TabStop = false;
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
            // lvSnapshot
            // 
            this.lvSnapshot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvSnapshot.CheckBoxes = true;
            this.lvSnapshot.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chItemName,
            this.chItemVersion});
            this.lvSnapshot.FullRowSelect = true;
            this.lvSnapshot.GridLines = true;
            this.lvSnapshot.Location = new System.Drawing.Point(6, 42);
            this.lvSnapshot.Name = "lvSnapshot";
            this.lvSnapshot.Size = new System.Drawing.Size(279, 309);
            this.lvSnapshot.TabIndex = 2;
            this.lvSnapshot.UseCompatibleStateImageBehavior = false;
            this.lvSnapshot.View = System.Windows.Forms.View.Details;
            this.lvSnapshot.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvSnapshot_ItemChecked);
            this.lvSnapshot.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvSnapshot_ItemSelectionChanged);
            // 
            // chItemName
            // 
            this.chItemName.Text = "Name";
            this.chItemName.Width = 200;
            // 
            // chItemVersion
            // 
            this.chItemVersion.Text = "Version";
            this.chItemVersion.Width = 200;
            // 
            // ViewParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Name = "ViewParameters";
            this.Size = new System.Drawing.Size(600, 400);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.gbOrganizations.ResumeLayout(false);
            this.gbOrganizations.PerformLayout();
            this.gbSnapshot.ResumeLayout(false);
            this.gbSnapshot.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox gbOrganizations;
        private System.Windows.Forms.ListView lvOrganizations;
        private System.Windows.Forms.ColumnHeader chOrgName;
        private System.Windows.Forms.ColumnHeader chOrgService;
        private System.Windows.Forms.GroupBox gbSnapshot;
        private System.Windows.Forms.CheckBox cbToggleOrganizations;
        private System.Windows.Forms.CheckBox cbToggleSolutions;
        private System.Windows.Forms.ListView lvSnapshot;
        private System.Windows.Forms.ColumnHeader chItemName;
        private System.Windows.Forms.ColumnHeader chItemVersion;

    }
}
