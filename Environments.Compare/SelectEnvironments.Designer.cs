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
            this.gbOrganizations = new System.Windows.Forms.GroupBox();
            this.lvOrganizations = new System.Windows.Forms.ListView();
            this.chOrgName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOrgUrl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOrgVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbReference = new System.Windows.Forms.GroupBox();
            this.lvReference = new System.Windows.Forms.ListView();
            this.chRefOrgName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chRefOrgUrl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chRefVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbOrganizations.SuspendLayout();
            this.gbReference.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbOrganizations
            // 
            this.gbOrganizations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbOrganizations.Controls.Add(this.lvOrganizations);
            this.gbOrganizations.Location = new System.Drawing.Point(0, 129);
            this.gbOrganizations.Name = "gbOrganizations";
            this.gbOrganizations.Size = new System.Drawing.Size(597, 268);
            this.gbOrganizations.TabIndex = 11;
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
            this.lvOrganizations.Size = new System.Drawing.Size(584, 243);
            this.lvOrganizations.TabIndex = 2;
            this.lvOrganizations.UseCompatibleStateImageBehavior = false;
            this.lvOrganizations.View = System.Windows.Forms.View.Details;
            this.lvOrganizations.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvOrganizations_ItemSelectionChanged);
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
            this.chRefOrgUrl,
            this.chRefVersion});
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
            // SelectEnvironments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbOrganizations);
            this.Controls.Add(this.gbReference);
            this.Name = "SelectEnvironments";
            this.Size = new System.Drawing.Size(600, 400);
            this.gbOrganizations.ResumeLayout(false);
            this.gbReference.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbOrganizations;
        private System.Windows.Forms.ListView lvOrganizations;
        private System.Windows.Forms.ColumnHeader chOrgName;
        private System.Windows.Forms.ColumnHeader chOrgUrl;
        private System.Windows.Forms.ColumnHeader chOrgVersion;
        private System.Windows.Forms.GroupBox gbReference;
        private System.Windows.Forms.ListView lvReference;
        private System.Windows.Forms.ColumnHeader chRefOrgName;
        private System.Windows.Forms.ColumnHeader chRefOrgUrl;
        private System.Windows.Forms.ColumnHeader chRefVersion;

    }
}
