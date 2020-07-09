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
            this.exportSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.importSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
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
            this.cbSourceAssembly = new System.Windows.Forms.ComboBox();
            this.lSourceAssembly = new System.Windows.Forms.Label();
            this.cbSourcePlugin = new System.Windows.Forms.ComboBox();
            this.lSourcePlugin = new System.Windows.Forms.Label();
            this.gbDestination = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lTargetPlugin = new System.Windows.Forms.Label();
            this.lTargetAssembly = new System.Windows.Forms.Label();
            this.cbTargetPlugin = new System.Windows.Forms.ComboBox();
            this.cbTargetAssembly = new System.Windows.Forms.ComboBox();
            this.gbActions = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.bMove = new System.Windows.Forms.Button();
            this.bCopy = new System.Windows.Forms.Button();
            this.lSourceEntity = new System.Windows.Forms.Label();
            this.lSourceMessage = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.tsMenu.SuspendLayout();
            this.gbSteps.SuspendLayout();
            this.cmStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.gbDestination.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.gbActions.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
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
            this.gbSteps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.gbSteps, 4);
            this.gbSteps.Controls.Add(this.lvSteps);
            this.gbSteps.Location = new System.Drawing.Point(3, 55);
            this.gbSteps.Name = "gbSteps";
            this.gbSteps.Size = new System.Drawing.Size(594, 417);
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
            this.lvSteps.HideSelection = false;
            this.lvSteps.Location = new System.Drawing.Point(3, 16);
            this.lvSteps.Name = "lvSteps";
            this.lvSteps.Size = new System.Drawing.Size(588, 398);
            this.lvSteps.TabIndex = 0;
            this.lvSteps.UseCompatibleStateImageBehavior = false;
            this.lvSteps.View = System.Windows.Forms.View.Details;
            this.lvSteps.SelectedIndexChanged += new System.EventHandler(this.lvSteps_SelectedIndexChanged);
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
            this.exportSelected,
            this.importSelected,
            this.toolStripSeparator6,
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
            this.cmStrip.Size = new System.Drawing.Size(311, 336);
            this.cmStrip.Opening += new System.ComponentModel.CancelEventHandler(this.cmStrip_Opening);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(310, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // dropSelectionToolStripMenuItem
            // 
            this.dropSelectionToolStripMenuItem.Name = "dropSelectionToolStripMenuItem";
            this.dropSelectionToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.dropSelectionToolStripMenuItem.Size = new System.Drawing.Size(310, 22);
            this.dropSelectionToolStripMenuItem.Text = "Drop Selection";
            this.dropSelectionToolStripMenuItem.Click += new System.EventHandler(this.dropSelectionToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(307, 6);
            // 
            // exportSelected
            // 
            this.exportSelected.Name = "exportSelected";
            this.exportSelected.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.exportSelected.Size = new System.Drawing.Size(310, 22);
            this.exportSelected.Text = "Export Selected";
            this.exportSelected.Click += new System.EventHandler(this.exportSelected_Click);
            // 
            // importSelected
            // 
            this.importSelected.Name = "importSelected";
            this.importSelected.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.importSelected.Size = new System.Drawing.Size(310, 22);
            this.importSelected.Text = "Import Selected";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(307, 6);
            // 
            // matchPluginNameMoveToAssemblyToolStripMenuItem
            // 
            this.matchPluginNameMoveToAssemblyToolStripMenuItem.Enabled = false;
            this.matchPluginNameMoveToAssemblyToolStripMenuItem.Name = "matchPluginNameMoveToAssemblyToolStripMenuItem";
            this.matchPluginNameMoveToAssemblyToolStripMenuItem.Size = new System.Drawing.Size(310, 22);
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
            this.toolStripSeparator2.Size = new System.Drawing.Size(307, 6);
            // 
            // moveToAnotherPluginInSameAssemblyToolStripMenuItem
            // 
            this.moveToAnotherPluginInSameAssemblyToolStripMenuItem.Enabled = false;
            this.moveToAnotherPluginInSameAssemblyToolStripMenuItem.Name = "moveToAnotherPluginInSameAssemblyToolStripMenuItem";
            this.moveToAnotherPluginInSameAssemblyToolStripMenuItem.Size = new System.Drawing.Size(310, 22);
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
            this.toolStripSeparator3.Size = new System.Drawing.Size(307, 6);
            // 
            // activateSelectedToolStripMenuItem
            // 
            this.activateSelectedToolStripMenuItem.Name = "activateSelectedToolStripMenuItem";
            this.activateSelectedToolStripMenuItem.Size = new System.Drawing.Size(310, 22);
            this.activateSelectedToolStripMenuItem.Text = "Activate Selected";
            // 
            // deactivateSelectedToolStripMenuItem
            // 
            this.deactivateSelectedToolStripMenuItem.Name = "deactivateSelectedToolStripMenuItem";
            this.deactivateSelectedToolStripMenuItem.Size = new System.Drawing.Size(310, 22);
            this.deactivateSelectedToolStripMenuItem.Text = "Deactivate Selected";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(307, 6);
            // 
            // activateAllToolStripMenuItem
            // 
            this.activateAllToolStripMenuItem.Name = "activateAllToolStripMenuItem";
            this.activateAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.A)));
            this.activateAllToolStripMenuItem.Size = new System.Drawing.Size(310, 22);
            this.activateAllToolStripMenuItem.Text = "Activate All";
            // 
            // deactivateAllToolStripMenuItem
            // 
            this.deactivateAllToolStripMenuItem.Name = "deactivateAllToolStripMenuItem";
            this.deactivateAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.D)));
            this.deactivateAllToolStripMenuItem.Size = new System.Drawing.Size(310, 22);
            this.deactivateAllToolStripMenuItem.Text = "Deactivate All";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(307, 6);
            // 
            // removeSelectedToolStripMenuItem
            // 
            this.removeSelectedToolStripMenuItem.Name = "removeSelectedToolStripMenuItem";
            this.removeSelectedToolStripMenuItem.Size = new System.Drawing.Size(310, 22);
            this.removeSelectedToolStripMenuItem.Text = "Remove Selected";
            this.removeSelectedToolStripMenuItem.Click += new System.EventHandler(this.removeSelectedToolStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.gbSteps, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbSourceAssembly, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lSourceAssembly, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbSourcePlugin, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lSourcePlugin, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.gbDestination, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.gbActions, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.lSourceEntity, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lSourceMessage, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBox1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBox2, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(600, 575);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // cbSourceAssembly
            // 
            this.cbSourceAssembly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbSourceAssembly.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSourceAssembly.FormattingEnabled = true;
            this.cbSourceAssembly.Location = new System.Drawing.Point(113, 3);
            this.cbSourceAssembly.Name = "cbSourceAssembly";
            this.cbSourceAssembly.Size = new System.Drawing.Size(184, 21);
            this.cbSourceAssembly.Sorted = true;
            this.cbSourceAssembly.TabIndex = 3;
            this.cbSourceAssembly.SelectedIndexChanged += new System.EventHandler(this.cbSourceAssembly_SelectedIndexChanged);
            // 
            // lSourceAssembly
            // 
            this.lSourceAssembly.AutoSize = true;
            this.lSourceAssembly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lSourceAssembly.Location = new System.Drawing.Point(9, 6);
            this.lSourceAssembly.Margin = new System.Windows.Forms.Padding(9, 6, 0, 0);
            this.lSourceAssembly.Name = "lSourceAssembly";
            this.lSourceAssembly.Size = new System.Drawing.Size(101, 20);
            this.lSourceAssembly.TabIndex = 2;
            this.lSourceAssembly.Text = "Source Assembly:";
            // 
            // cbSourcePlugin
            // 
            this.cbSourcePlugin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbSourcePlugin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSourcePlugin.FormattingEnabled = true;
            this.cbSourcePlugin.Location = new System.Drawing.Point(413, 3);
            this.cbSourcePlugin.Name = "cbSourcePlugin";
            this.cbSourcePlugin.Size = new System.Drawing.Size(184, 21);
            this.cbSourcePlugin.Sorted = true;
            this.cbSourcePlugin.TabIndex = 4;
            this.cbSourcePlugin.SelectedIndexChanged += new System.EventHandler(this.cbSourcePlugin_SelectedIndexChanged);
            // 
            // lSourcePlugin
            // 
            this.lSourcePlugin.AutoSize = true;
            this.lSourcePlugin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lSourcePlugin.Location = new System.Drawing.Point(309, 6);
            this.lSourcePlugin.Margin = new System.Windows.Forms.Padding(9, 6, 0, 0);
            this.lSourcePlugin.Name = "lSourcePlugin";
            this.lSourcePlugin.Size = new System.Drawing.Size(101, 20);
            this.lSourcePlugin.TabIndex = 5;
            this.lSourcePlugin.Text = "Source Plugin:";
            // 
            // gbDestination
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.gbDestination, 3);
            this.gbDestination.Controls.Add(this.tableLayoutPanel2);
            this.gbDestination.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDestination.Enabled = false;
            this.gbDestination.Location = new System.Drawing.Point(3, 478);
            this.gbDestination.Name = "gbDestination";
            this.gbDestination.Size = new System.Drawing.Size(404, 94);
            this.gbDestination.TabIndex = 6;
            this.gbDestination.TabStop = false;
            this.gbDestination.Text = "Destination";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.lTargetPlugin, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lTargetAssembly, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cbTargetPlugin, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.cbTargetAssembly, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(398, 75);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lTargetPlugin
            // 
            this.lTargetPlugin.AutoSize = true;
            this.lTargetPlugin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lTargetPlugin.Location = new System.Drawing.Point(9, 48);
            this.lTargetPlugin.Margin = new System.Windows.Forms.Padding(9, 6, 0, 0);
            this.lTargetPlugin.Name = "lTargetPlugin";
            this.lTargetPlugin.Size = new System.Drawing.Size(96, 27);
            this.lTargetPlugin.TabIndex = 6;
            this.lTargetPlugin.Text = "Target Pluign:";
            // 
            // lTargetAssembly
            // 
            this.lTargetAssembly.AutoSize = true;
            this.lTargetAssembly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lTargetAssembly.Location = new System.Drawing.Point(9, 6);
            this.lTargetAssembly.Margin = new System.Windows.Forms.Padding(9, 6, 0, 0);
            this.lTargetAssembly.Name = "lTargetAssembly";
            this.lTargetAssembly.Size = new System.Drawing.Size(96, 26);
            this.lTargetAssembly.TabIndex = 3;
            this.lTargetAssembly.Text = "Target Assembly:";
            // 
            // cbTargetPlugin
            // 
            this.cbTargetPlugin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbTargetPlugin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTargetPlugin.FormattingEnabled = true;
            this.cbTargetPlugin.Location = new System.Drawing.Point(128, 45);
            this.cbTargetPlugin.Name = "cbTargetPlugin";
            this.cbTargetPlugin.Size = new System.Drawing.Size(267, 21);
            this.cbTargetPlugin.Sorted = true;
            this.cbTargetPlugin.TabIndex = 7;
            this.cbTargetPlugin.SelectedIndexChanged += new System.EventHandler(this.cbTargetPlugin_SelectedIndexChanged);
            // 
            // cbTargetAssembly
            // 
            this.cbTargetAssembly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbTargetAssembly.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTargetAssembly.FormattingEnabled = true;
            this.cbTargetAssembly.Location = new System.Drawing.Point(128, 3);
            this.cbTargetAssembly.Name = "cbTargetAssembly";
            this.cbTargetAssembly.Size = new System.Drawing.Size(267, 21);
            this.cbTargetAssembly.Sorted = true;
            this.cbTargetAssembly.TabIndex = 8;
            this.cbTargetAssembly.SelectedIndexChanged += new System.EventHandler(this.cbTargetAssembly_SelectedIndexChanged);
            // 
            // gbActions
            // 
            this.gbActions.Controls.Add(this.tableLayoutPanel3);
            this.gbActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbActions.Location = new System.Drawing.Point(413, 478);
            this.gbActions.Name = "gbActions";
            this.gbActions.Size = new System.Drawing.Size(184, 94);
            this.gbActions.TabIndex = 7;
            this.gbActions.TabStop = false;
            this.gbActions.Text = "Actions";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.bMove, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.bCopy, 0, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(178, 75);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // bMove
            // 
            this.bMove.Dock = System.Windows.Forms.DockStyle.Top;
            this.bMove.Enabled = false;
            this.bMove.Location = new System.Drawing.Point(3, 3);
            this.bMove.Name = "bMove";
            this.bMove.Size = new System.Drawing.Size(172, 23);
            this.bMove.TabIndex = 9;
            this.bMove.Text = "Move Selected Steps";
            this.bMove.UseVisualStyleBackColor = true;
            this.bMove.Click += new System.EventHandler(this.bMove_Click);
            // 
            // bCopy
            // 
            this.bCopy.Dock = System.Windows.Forms.DockStyle.Top;
            this.bCopy.Enabled = false;
            this.bCopy.Location = new System.Drawing.Point(3, 45);
            this.bCopy.Name = "bCopy";
            this.bCopy.Size = new System.Drawing.Size(172, 23);
            this.bCopy.TabIndex = 10;
            this.bCopy.Text = "Copy Selected Steps";
            this.bCopy.UseVisualStyleBackColor = true;
            // 
            // lSourceEntity
            // 
            this.lSourceEntity.AutoSize = true;
            this.lSourceEntity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lSourceEntity.Location = new System.Drawing.Point(9, 32);
            this.lSourceEntity.Margin = new System.Windows.Forms.Padding(9, 6, 0, 0);
            this.lSourceEntity.Name = "lSourceEntity";
            this.lSourceEntity.Size = new System.Drawing.Size(101, 20);
            this.lSourceEntity.TabIndex = 8;
            this.lSourceEntity.Text = "Source Entity:";
            // 
            // lSourceMessage
            // 
            this.lSourceMessage.AutoSize = true;
            this.lSourceMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lSourceMessage.Location = new System.Drawing.Point(309, 32);
            this.lSourceMessage.Margin = new System.Windows.Forms.Padding(9, 6, 0, 0);
            this.lSourceMessage.Name = "lSourceMessage";
            this.lSourceMessage.Size = new System.Drawing.Size(101, 20);
            this.lSourceMessage.TabIndex = 9;
            this.lSourceMessage.Text = "Source Message:";
            // 
            // comboBox1
            // 
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(113, 29);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(184, 21);
            this.comboBox1.TabIndex = 10;
            // 
            // comboBox2
            // 
            this.comboBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(413, 29);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(184, 21);
            this.comboBox2.TabIndex = 11;
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
            this.gbDestination.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.gbActions.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
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
        private System.Windows.Forms.Label lSourceAssembly;
        private System.Windows.Forms.ComboBox cbSourceAssembly;
        private System.Windows.Forms.ComboBox cbSourcePlugin;
        private System.Windows.Forms.Label lSourcePlugin;
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
        private System.Windows.Forms.GroupBox gbDestination;
        private System.Windows.Forms.Label lTargetAssembly;
        private System.Windows.Forms.ComboBox cbTargetAssembly;
        private System.Windows.Forms.ComboBox cbTargetPlugin;
        private System.Windows.Forms.Label lTargetPlugin;
        private System.Windows.Forms.Button bMove;
        private System.Windows.Forms.Button bCopy;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox gbActions;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ToolStripMenuItem exportSelected;
        private System.Windows.Forms.ToolStripMenuItem importSelected;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.Label lSourceEntity;
        private System.Windows.Forms.Label lSourceMessage;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
    }
}
