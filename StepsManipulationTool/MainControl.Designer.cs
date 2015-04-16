namespace Cinteros.Xrm.StepsManipulator
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainControl));
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.gbSteps = new System.Windows.Forms.GroupBox();
            this.lvSteps = new System.Windows.Forms.ListView();
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dropSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.activateAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deactivateAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbAssemblies = new System.Windows.Forms.ComboBox();
            this.lAssemblies = new System.Windows.Forms.Label();
            this.cbTypes = new System.Windows.Forms.ComboBox();
            this.lTypes = new System.Windows.Forms.Label();
            this.chState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.activateSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deactivateSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenu.SuspendLayout();
            this.gbSteps.SuspendLayout();
            this.cmStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(600, 25);
            this.tsMenu.TabIndex = 0;
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
            // gbSteps
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.gbSteps, 4);
            this.gbSteps.Controls.Add(this.lvSteps);
            this.gbSteps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSteps.Location = new System.Drawing.Point(3, 29);
            this.gbSteps.Name = "gbSteps";
            this.gbSteps.Size = new System.Drawing.Size(594, 343);
            this.gbSteps.TabIndex = 1;
            this.gbSteps.TabStop = false;
            this.gbSteps.Text = "SDK Message Processing Steps";
            // 
            // lvSteps
            // 
            this.lvSteps.CheckBoxes = true;
            this.lvSteps.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chState});
            this.lvSteps.ContextMenuStrip = this.cmStrip;
            this.lvSteps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSteps.FullRowSelect = true;
            this.lvSteps.GridLines = true;
            this.lvSteps.Location = new System.Drawing.Point(3, 16);
            this.lvSteps.Name = "lvSteps";
            this.lvSteps.Size = new System.Drawing.Size(588, 324);
            this.lvSteps.TabIndex = 0;
            this.lvSteps.UseCompatibleStateImageBehavior = false;
            this.lvSteps.View = System.Windows.Forms.View.Details;
            // 
            // chName
            // 
            this.chName.Text = "Name";
            this.chName.Width = 450;
            // 
            // cmStrip
            // 
            this.cmStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllToolStripMenuItem,
            this.dropSelectionToolStripMenuItem,
            this.toolStripSeparator1,
            this.activateSelectedToolStripMenuItem,
            this.deactivateSelectedToolStripMenuItem,
            this.toolStripSeparator2,
            this.activateAllToolStripMenuItem,
            this.deactivateAllToolStripMenuItem});
            this.cmStrip.Name = "cmStrip";
            this.cmStrip.Size = new System.Drawing.Size(221, 170);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // dropSelectionToolStripMenuItem
            // 
            this.dropSelectionToolStripMenuItem.Name = "dropSelectionToolStripMenuItem";
            this.dropSelectionToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.dropSelectionToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.dropSelectionToolStripMenuItem.Text = "Drop Selection";
            this.dropSelectionToolStripMenuItem.Click += new System.EventHandler(this.dropSelectionToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(217, 6);
            // 
            // activateAllToolStripMenuItem
            // 
            this.activateAllToolStripMenuItem.Name = "activateAllToolStripMenuItem";
            this.activateAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.A)));
            this.activateAllToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.activateAllToolStripMenuItem.Text = "Activate All";
            // 
            // deactivateAllToolStripMenuItem
            // 
            this.deactivateAllToolStripMenuItem.Name = "deactivateAllToolStripMenuItem";
            this.deactivateAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.D)));
            this.deactivateAllToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.deactivateAllToolStripMenuItem.Text = "Deactivate All";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.gbSteps, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbAssemblies, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lAssemblies, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbTypes, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lTypes, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(600, 375);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // cbAssemblies
            // 
            this.cbAssemblies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbAssemblies.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAssemblies.FormattingEnabled = true;
            this.cbAssemblies.Location = new System.Drawing.Point(103, 3);
            this.cbAssemblies.Name = "cbAssemblies";
            this.cbAssemblies.Size = new System.Drawing.Size(194, 21);
            this.cbAssemblies.Sorted = true;
            this.cbAssemblies.TabIndex = 3;
            this.cbAssemblies.SelectedIndexChanged += new System.EventHandler(this.cbAssemblies_SelectedIndexChanged);
            // 
            // lAssemblies
            // 
            this.lAssemblies.AutoSize = true;
            this.lAssemblies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lAssemblies.Location = new System.Drawing.Point(9, 6);
            this.lAssemblies.Margin = new System.Windows.Forms.Padding(9, 6, 0, 0);
            this.lAssemblies.Name = "lAssemblies";
            this.lAssemblies.Size = new System.Drawing.Size(91, 20);
            this.lAssemblies.TabIndex = 2;
            this.lAssemblies.Text = "Select Assembly:";
            // 
            // cbTypes
            // 
            this.cbTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypes.FormattingEnabled = true;
            this.cbTypes.Location = new System.Drawing.Point(403, 3);
            this.cbTypes.Name = "cbTypes";
            this.cbTypes.Size = new System.Drawing.Size(194, 21);
            this.cbTypes.TabIndex = 4;
            this.cbTypes.SelectedIndexChanged += new System.EventHandler(this.cbTypes_SelectedIndexChanged);
            // 
            // lTypes
            // 
            this.lTypes.AutoSize = true;
            this.lTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lTypes.Location = new System.Drawing.Point(309, 6);
            this.lTypes.Margin = new System.Windows.Forms.Padding(9, 6, 0, 0);
            this.lTypes.Name = "lTypes";
            this.lTypes.Size = new System.Drawing.Size(91, 20);
            this.lTypes.TabIndex = 5;
            this.lTypes.Text = "Select Type:";
            // 
            // chState
            // 
            this.chState.Text = "State";
            this.chState.Width = 100;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(217, 6);
            // 
            // activateSelectedToolStripMenuItem
            // 
            this.activateSelectedToolStripMenuItem.Name = "activateSelectedToolStripMenuItem";
            this.activateSelectedToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.activateSelectedToolStripMenuItem.Text = "Activate Selected";
            // 
            // deactivateSelectedToolStripMenuItem
            // 
            this.deactivateSelectedToolStripMenuItem.Name = "deactivateSelectedToolStripMenuItem";
            this.deactivateSelectedToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.deactivateSelectedToolStripMenuItem.Text = "Deactivate Selected";
            // 
            // MainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tsMenu);
            this.Name = "MainControl";
            this.Size = new System.Drawing.Size(600, 400);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.gbSteps.ResumeLayout(false);
            this.cmStrip.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.GroupBox gbSteps;
        private System.Windows.Forms.ListView lvSteps;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lAssemblies;
        private System.Windows.Forms.ComboBox cbAssemblies;
        private System.Windows.Forms.ComboBox cbTypes;
        private System.Windows.Forms.Label lTypes;
        private System.Windows.Forms.ContextMenuStrip cmStrip;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem dropSelectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activateAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deactivateAllToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader chState;
        private System.Windows.Forms.ToolStripMenuItem activateSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deactivateSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}
