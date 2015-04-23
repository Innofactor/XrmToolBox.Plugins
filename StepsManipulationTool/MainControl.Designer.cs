namespace Cinteros.Xrm.StepsManipulationTool
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
            this.chState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dropSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.matchPluginNameMoveToAssemblyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tscAssemblies = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.moveToAnotherPluginInSameAssemblyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tscTypes = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.activateSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deactivateSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.activateAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deactivateAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.removeSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbAssemblies = new System.Windows.Forms.ComboBox();
            this.lAssemblies = new System.Windows.Forms.Label();
            this.cbTypes = new System.Windows.Forms.ComboBox();
            this.lTypes = new System.Windows.Forms.Label();
            this.gbActions = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.tsMenu.SuspendLayout();
            this.gbSteps.SuspendLayout();
            this.cmStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.gbActions.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
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
            this.gbSteps.Size = new System.Drawing.Size(594, 443);
            this.gbSteps.TabIndex = 1;
            this.gbSteps.TabStop = false;
            this.gbSteps.Text = "SDK Message Processing Steps";
            // 
            // lvSteps
            // 
            this.lvSteps.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chState});
            this.lvSteps.ContextMenuStrip = this.cmStrip;
            this.lvSteps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSteps.FullRowSelect = true;
            this.lvSteps.GridLines = true;
            this.lvSteps.Location = new System.Drawing.Point(3, 16);
            this.lvSteps.Name = "lvSteps";
            this.lvSteps.Size = new System.Drawing.Size(588, 424);
            this.lvSteps.TabIndex = 0;
            this.lvSteps.UseCompatibleStateImageBehavior = false;
            this.lvSteps.View = System.Windows.Forms.View.Details;
            // 
            // chName
            // 
            this.chName.Text = "Name";
            this.chName.Width = 450;
            // 
            // chState
            // 
            this.chState.Text = "State";
            this.chState.Width = 100;
            // 
            // cmStrip
            // 
            this.cmStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllToolStripMenuItem,
            this.dropSelectionToolStripMenuItem,
            this.toolStripSeparator1,
            this.matchPluginNameMoveToAssemblyToolStripMenuItem,
            this.tscAssemblies,
            this.toolStripSeparator2,
            this.moveToAnotherPluginInSameAssemblyToolStripMenuItem,
            this.tscTypes,
            this.toolStripSeparator3,
            this.activateSelectedToolStripMenuItem,
            this.deactivateSelectedToolStripMenuItem,
            this.toolStripSeparator4,
            this.activateAllToolStripMenuItem,
            this.deactivateAllToolStripMenuItem,
            this.toolStripSeparator5,
            this.removeSelectedToolStripMenuItem});
            this.cmStrip.Name = "cmStrip";
            this.cmStrip.Size = new System.Drawing.Size(313, 286);
            this.cmStrip.Opening += new System.ComponentModel.CancelEventHandler(this.cmStrip_Opening);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(312, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // dropSelectionToolStripMenuItem
            // 
            this.dropSelectionToolStripMenuItem.Name = "dropSelectionToolStripMenuItem";
            this.dropSelectionToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.dropSelectionToolStripMenuItem.Size = new System.Drawing.Size(312, 22);
            this.dropSelectionToolStripMenuItem.Text = "Drop Selection";
            this.dropSelectionToolStripMenuItem.Click += new System.EventHandler(this.dropSelectionToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(309, 6);
            // 
            // matchPluginNameMoveToAssemblyToolStripMenuItem
            // 
            this.matchPluginNameMoveToAssemblyToolStripMenuItem.Enabled = false;
            this.matchPluginNameMoveToAssemblyToolStripMenuItem.Name = "matchPluginNameMoveToAssemblyToolStripMenuItem";
            this.matchPluginNameMoveToAssemblyToolStripMenuItem.Size = new System.Drawing.Size(312, 22);
            this.matchPluginNameMoveToAssemblyToolStripMenuItem.Text = "Match Plugin Name && Move To Assembly...";
            // 
            // tscAssemblies
            // 
            this.tscAssemblies.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscAssemblies.Name = "tscAssemblies";
            this.tscAssemblies.Size = new System.Drawing.Size(250, 23);
            this.tscAssemblies.SelectedIndexChanged += new System.EventHandler(this.tscAssemblies_SelectedIndexChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(309, 6);
            // 
            // moveToAnotherPluginInSameAssemblyToolStripMenuItem
            // 
            this.moveToAnotherPluginInSameAssemblyToolStripMenuItem.Enabled = false;
            this.moveToAnotherPluginInSameAssemblyToolStripMenuItem.Name = "moveToAnotherPluginInSameAssemblyToolStripMenuItem";
            this.moveToAnotherPluginInSameAssemblyToolStripMenuItem.Size = new System.Drawing.Size(312, 22);
            this.moveToAnotherPluginInSameAssemblyToolStripMenuItem.Text = "Move To Another Plugin In Same Assembly...";
            // 
            // tscTypes
            // 
            this.tscTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscTypes.Name = "tscTypes";
            this.tscTypes.Size = new System.Drawing.Size(250, 23);
            this.tscTypes.SelectedIndexChanged += new System.EventHandler(this.tscTypes_SelectedIndexChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(309, 6);
            // 
            // activateSelectedToolStripMenuItem
            // 
            this.activateSelectedToolStripMenuItem.Name = "activateSelectedToolStripMenuItem";
            this.activateSelectedToolStripMenuItem.Size = new System.Drawing.Size(312, 22);
            this.activateSelectedToolStripMenuItem.Text = "Activate Selected";
            // 
            // deactivateSelectedToolStripMenuItem
            // 
            this.deactivateSelectedToolStripMenuItem.Name = "deactivateSelectedToolStripMenuItem";
            this.deactivateSelectedToolStripMenuItem.Size = new System.Drawing.Size(312, 22);
            this.deactivateSelectedToolStripMenuItem.Text = "Deactivate Selected";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(309, 6);
            // 
            // activateAllToolStripMenuItem
            // 
            this.activateAllToolStripMenuItem.Name = "activateAllToolStripMenuItem";
            this.activateAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.A)));
            this.activateAllToolStripMenuItem.Size = new System.Drawing.Size(312, 22);
            this.activateAllToolStripMenuItem.Text = "Activate All";
            // 
            // deactivateAllToolStripMenuItem
            // 
            this.deactivateAllToolStripMenuItem.Name = "deactivateAllToolStripMenuItem";
            this.deactivateAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.D)));
            this.deactivateAllToolStripMenuItem.Size = new System.Drawing.Size(312, 22);
            this.deactivateAllToolStripMenuItem.Text = "Deactivate All";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(309, 6);
            // 
            // removeSelectedToolStripMenuItem
            // 
            this.removeSelectedToolStripMenuItem.Name = "removeSelectedToolStripMenuItem";
            this.removeSelectedToolStripMenuItem.Size = new System.Drawing.Size(312, 22);
            this.removeSelectedToolStripMenuItem.Text = "Remove Selected";
            this.removeSelectedToolStripMenuItem.Click += new System.EventHandler(this.removeSelectedToolStripMenuItem_Click);
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
            this.tableLayoutPanel1.Controls.Add(this.gbActions, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(600, 575);
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
            // gbActions
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.gbActions, 4);
            this.gbActions.Controls.Add(this.tableLayoutPanel2);
            this.gbActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbActions.Location = new System.Drawing.Point(3, 478);
            this.gbActions.Name = "gbActions";
            this.gbActions.Size = new System.Drawing.Size(594, 94);
            this.gbActions.TabIndex = 6;
            this.gbActions.TabStop = false;
            this.gbActions.Text = "Actions";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.comboBox2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.comboBox1, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(588, 75);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(9, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(9, 6, 0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select Assembly:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(303, 6);
            this.label2.Margin = new System.Windows.Forms.Padding(9, 6, 0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "Select Type:";
            // 
            // comboBox1
            // 
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(397, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(188, 21);
            this.comboBox1.Sorted = true;
            this.comboBox1.TabIndex = 7;
            // 
            // comboBox2
            // 
            this.comboBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(103, 3);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(188, 21);
            this.comboBox2.TabIndex = 8;
            // 
            // MainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tsMenu);
            this.Name = "MainControl";
            this.Size = new System.Drawing.Size(600, 600);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.gbSteps.ResumeLayout(false);
            this.cmStrip.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.gbActions.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripComboBox tscAssemblies;
        private System.Windows.Forms.ToolStripComboBox tscTypes;
        private System.Windows.Forms.ToolStripMenuItem matchPluginNameMoveToAssemblyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToAnotherPluginInSameAssemblyToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem removeSelectedToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbActions;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
    }
}
