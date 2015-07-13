namespace Cinteros.Xrm.DataUpdateTool
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
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.tsbCloseThisTab = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbAbout = new System.Windows.Forms.ToolStripButton();
            this.tsbOptions = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmiFriendly = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiShowAttributes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAttributesAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiAttributesManaged = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAttributesUnmanaged = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiAttributesCustomizable = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAttributesUncustomizable = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiAttributesStandard = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAttributesCustom = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiAttributesOnlyValidAF = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btnGetRecords = new System.Windows.Forms.Button();
            this.lblRecords = new System.Windows.Forms.Label();
            this.cmbAttribute = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbSetNull = new System.Windows.Forms.RadioButton();
            this.rbSetTouch = new System.Windows.Forms.RadioButton();
            this.rbSetValue = new System.Windows.Forms.RadioButton();
            this.cmbValue = new System.Windows.Forms.ComboBox();
            this.chkOnlyChange = new System.Windows.Forms.CheckBox();
            this.gb1select = new System.Windows.Forms.GroupBox();
            this.cmbSource = new System.Windows.Forms.ComboBox();
            this.gb2attribute = new System.Windows.Forms.GroupBox();
            this.gb3value = new System.Windows.Forms.GroupBox();
            this.gb4update = new System.Windows.Forms.GroupBox();
            this.lblUpdateStatus = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStripMain.SuspendLayout();
            this.gb1select.SuspendLayout();
            this.gb2attribute.SuspendLayout();
            this.gb3value.SuspendLayout();
            this.gb4update.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Cinteros 100 transp.png");
            // 
            // toolStripMain
            // 
            this.toolStripMain.AutoSize = false;
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbCloseThisTab,
            this.toolStripSeparator4,
            this.tsbAbout,
            this.tsbOptions});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(698, 25);
            this.toolStripMain.TabIndex = 23;
            this.toolStripMain.Text = "toolStrip1";
            // 
            // tsbCloseThisTab
            // 
            this.tsbCloseThisTab.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCloseThisTab.Image = ((System.Drawing.Image)(resources.GetObject("tsbCloseThisTab.Image")));
            this.tsbCloseThisTab.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCloseThisTab.Name = "tsbCloseThisTab";
            this.tsbCloseThisTab.Size = new System.Drawing.Size(23, 22);
            this.tsbCloseThisTab.Text = "Close this tab";
            this.tsbCloseThisTab.Click += new System.EventHandler(this.tsbCloseThisTab_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbAbout
            // 
            this.tsbAbout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbAbout.Image = ((System.Drawing.Image)(resources.GetObject("tsbAbout.Image")));
            this.tsbAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAbout.Name = "tsbAbout";
            this.tsbAbout.Size = new System.Drawing.Size(60, 22);
            this.tsbAbout.Text = "About";
            this.tsbAbout.Click += new System.EventHandler(this.tsbAbout_Click);
            // 
            // tsbOptions
            // 
            this.tsbOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFriendly,
            this.toolStripSeparator12,
            this.tsmiShowAttributes,
            this.toolStripSeparator7});
            this.tsbOptions.Image = ((System.Drawing.Image)(resources.GetObject("tsbOptions.Image")));
            this.tsbOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOptions.Name = "tsbOptions";
            this.tsbOptions.Size = new System.Drawing.Size(78, 22);
            this.tsbOptions.Text = "Options";
            // 
            // tsmiFriendly
            // 
            this.tsmiFriendly.CheckOnClick = true;
            this.tsmiFriendly.Name = "tsmiFriendly";
            this.tsmiFriendly.Size = new System.Drawing.Size(156, 22);
            this.tsmiFriendly.Text = "Friendly names";
            this.tsmiFriendly.Click += new System.EventHandler(this.tsmiFriendly_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(153, 6);
            // 
            // tsmiShowAttributes
            // 
            this.tsmiShowAttributes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAttributesAll,
            this.toolStripSeparator13,
            this.tsmiAttributesManaged,
            this.tsmiAttributesUnmanaged,
            this.toolStripSeparator14,
            this.tsmiAttributesCustomizable,
            this.tsmiAttributesUncustomizable,
            this.toolStripSeparator15,
            this.tsmiAttributesStandard,
            this.tsmiAttributesCustom,
            this.toolStripSeparator16,
            this.tsmiAttributesOnlyValidAF});
            this.tsmiShowAttributes.Name = "tsmiShowAttributes";
            this.tsmiShowAttributes.Size = new System.Drawing.Size(156, 22);
            this.tsmiShowAttributes.Text = "Show attributes";
            // 
            // tsmiAttributesAll
            // 
            this.tsmiAttributesAll.Checked = true;
            this.tsmiAttributesAll.CheckOnClick = true;
            this.tsmiAttributesAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiAttributesAll.Name = "tsmiAttributesAll";
            this.tsmiAttributesAll.Size = new System.Drawing.Size(195, 22);
            this.tsmiAttributesAll.Text = "All";
            this.tsmiAttributesAll.Click += new System.EventHandler(this.tsmiAttributes_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(192, 6);
            // 
            // tsmiAttributesManaged
            // 
            this.tsmiAttributesManaged.Checked = true;
            this.tsmiAttributesManaged.CheckOnClick = true;
            this.tsmiAttributesManaged.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiAttributesManaged.Enabled = false;
            this.tsmiAttributesManaged.Name = "tsmiAttributesManaged";
            this.tsmiAttributesManaged.Size = new System.Drawing.Size(195, 22);
            this.tsmiAttributesManaged.Text = "Managed";
            this.tsmiAttributesManaged.Click += new System.EventHandler(this.tsmiAttributes_Click);
            // 
            // tsmiAttributesUnmanaged
            // 
            this.tsmiAttributesUnmanaged.Checked = true;
            this.tsmiAttributesUnmanaged.CheckOnClick = true;
            this.tsmiAttributesUnmanaged.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiAttributesUnmanaged.Enabled = false;
            this.tsmiAttributesUnmanaged.Name = "tsmiAttributesUnmanaged";
            this.tsmiAttributesUnmanaged.Size = new System.Drawing.Size(195, 22);
            this.tsmiAttributesUnmanaged.Text = "Unmanaged";
            this.tsmiAttributesUnmanaged.Click += new System.EventHandler(this.tsmiAttributes_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(192, 6);
            // 
            // tsmiAttributesCustomizable
            // 
            this.tsmiAttributesCustomizable.Checked = true;
            this.tsmiAttributesCustomizable.CheckOnClick = true;
            this.tsmiAttributesCustomizable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiAttributesCustomizable.Enabled = false;
            this.tsmiAttributesCustomizable.Name = "tsmiAttributesCustomizable";
            this.tsmiAttributesCustomizable.Size = new System.Drawing.Size(195, 22);
            this.tsmiAttributesCustomizable.Text = "Customizable";
            this.tsmiAttributesCustomizable.Click += new System.EventHandler(this.tsmiAttributes_Click);
            // 
            // tsmiAttributesUncustomizable
            // 
            this.tsmiAttributesUncustomizable.Checked = true;
            this.tsmiAttributesUncustomizable.CheckOnClick = true;
            this.tsmiAttributesUncustomizable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiAttributesUncustomizable.Enabled = false;
            this.tsmiAttributesUncustomizable.Name = "tsmiAttributesUncustomizable";
            this.tsmiAttributesUncustomizable.Size = new System.Drawing.Size(195, 22);
            this.tsmiAttributesUncustomizable.Text = "Uncustomizable";
            this.tsmiAttributesUncustomizable.Click += new System.EventHandler(this.tsmiAttributes_Click);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(192, 6);
            // 
            // tsmiAttributesStandard
            // 
            this.tsmiAttributesStandard.Checked = true;
            this.tsmiAttributesStandard.CheckOnClick = true;
            this.tsmiAttributesStandard.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiAttributesStandard.Enabled = false;
            this.tsmiAttributesStandard.Name = "tsmiAttributesStandard";
            this.tsmiAttributesStandard.Size = new System.Drawing.Size(195, 22);
            this.tsmiAttributesStandard.Text = "Standard";
            this.tsmiAttributesStandard.Click += new System.EventHandler(this.tsmiAttributes_Click);
            // 
            // tsmiAttributesCustom
            // 
            this.tsmiAttributesCustom.Checked = true;
            this.tsmiAttributesCustom.CheckOnClick = true;
            this.tsmiAttributesCustom.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiAttributesCustom.Enabled = false;
            this.tsmiAttributesCustom.Name = "tsmiAttributesCustom";
            this.tsmiAttributesCustom.Size = new System.Drawing.Size(195, 22);
            this.tsmiAttributesCustom.Text = "Custom";
            this.tsmiAttributesCustom.Click += new System.EventHandler(this.tsmiAttributes_Click);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(192, 6);
            // 
            // tsmiAttributesOnlyValidAF
            // 
            this.tsmiAttributesOnlyValidAF.CheckOnClick = true;
            this.tsmiAttributesOnlyValidAF.Enabled = false;
            this.tsmiAttributesOnlyValidAF.Name = "tsmiAttributesOnlyValidAF";
            this.tsmiAttributesOnlyValidAF.Size = new System.Drawing.Size(195, 22);
            this.tsmiAttributesOnlyValidAF.Text = "Only valid for Adv.Find";
            this.tsmiAttributesOnlyValidAF.Click += new System.EventHandler(this.tsmiAttributes_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(153, 6);
            // 
            // btnGetRecords
            // 
            this.btnGetRecords.Location = new System.Drawing.Point(196, 29);
            this.btnGetRecords.Name = "btnGetRecords";
            this.btnGetRecords.Size = new System.Drawing.Size(95, 23);
            this.btnGetRecords.TabIndex = 24;
            this.btnGetRecords.Text = "Get records";
            this.btnGetRecords.UseVisualStyleBackColor = true;
            this.btnGetRecords.Click += new System.EventHandler(this.btnGetRecords_Click);
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Location = new System.Drawing.Point(18, 61);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(100, 13);
            this.lblRecords.TabIndex = 25;
            this.lblRecords.Text = "Records not loaded";
            // 
            // cmbAttribute
            // 
            this.cmbAttribute.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbAttribute.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbAttribute.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbAttribute.FormattingEnabled = true;
            this.cmbAttribute.Location = new System.Drawing.Point(15, 43);
            this.cmbAttribute.Name = "cmbAttribute";
            this.cmbAttribute.Size = new System.Drawing.Size(276, 21);
            this.cmbAttribute.Sorted = true;
            this.cmbAttribute.TabIndex = 26;
            this.cmbAttribute.Tag = "attribute";
            this.cmbAttribute.SelectedIndexChanged += new System.EventHandler(this.cmbAttribute_SelectedIndexChanged);
            this.cmbAttribute.TextChanged += new System.EventHandler(this.cmbAttribute_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Attribute";
            // 
            // rbSetNull
            // 
            this.rbSetNull.AutoSize = true;
            this.rbSetNull.Location = new System.Drawing.Point(181, 27);
            this.rbSetNull.Name = "rbSetNull";
            this.rbSetNull.Size = new System.Drawing.Size(60, 17);
            this.rbSetNull.TabIndex = 31;
            this.rbSetNull.Text = "Set null";
            this.rbSetNull.UseVisualStyleBackColor = true;
            this.rbSetNull.CheckedChanged += new System.EventHandler(this.rbSet_CheckedChanged);
            // 
            // rbSetTouch
            // 
            this.rbSetTouch.AutoSize = true;
            this.rbSetTouch.Location = new System.Drawing.Point(102, 27);
            this.rbSetTouch.Name = "rbSetTouch";
            this.rbSetTouch.Size = new System.Drawing.Size(56, 17);
            this.rbSetTouch.TabIndex = 30;
            this.rbSetTouch.Text = "Touch";
            this.rbSetTouch.UseVisualStyleBackColor = true;
            this.rbSetTouch.CheckedChanged += new System.EventHandler(this.rbSet_CheckedChanged);
            // 
            // rbSetValue
            // 
            this.rbSetValue.AutoSize = true;
            this.rbSetValue.Checked = true;
            this.rbSetValue.Location = new System.Drawing.Point(18, 27);
            this.rbSetValue.Name = "rbSetValue";
            this.rbSetValue.Size = new System.Drawing.Size(52, 17);
            this.rbSetValue.TabIndex = 29;
            this.rbSetValue.TabStop = true;
            this.rbSetValue.Text = "Value";
            this.rbSetValue.UseVisualStyleBackColor = true;
            this.rbSetValue.CheckedChanged += new System.EventHandler(this.rbSet_CheckedChanged);
            // 
            // cmbValue
            // 
            this.cmbValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbValue.FormattingEnabled = true;
            this.cmbValue.Location = new System.Drawing.Point(15, 50);
            this.cmbValue.Name = "cmbValue";
            this.cmbValue.Size = new System.Drawing.Size(276, 21);
            this.cmbValue.TabIndex = 32;
            this.cmbValue.Tag = "value";
            // 
            // chkOnlyChange
            // 
            this.chkOnlyChange.AutoSize = true;
            this.chkOnlyChange.Location = new System.Drawing.Point(15, 77);
            this.chkOnlyChange.Name = "chkOnlyChange";
            this.chkOnlyChange.Size = new System.Drawing.Size(164, 17);
            this.chkOnlyChange.TabIndex = 33;
            this.chkOnlyChange.Text = "Only when change is needed";
            this.chkOnlyChange.UseVisualStyleBackColor = true;
            // 
            // gb1select
            // 
            this.gb1select.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb1select.Controls.Add(this.cmbSource);
            this.gb1select.Controls.Add(this.btnGetRecords);
            this.gb1select.Controls.Add(this.lblRecords);
            this.gb1select.Location = new System.Drawing.Point(6, 16);
            this.gb1select.Name = "gb1select";
            this.gb1select.Size = new System.Drawing.Size(308, 89);
            this.gb1select.TabIndex = 34;
            this.gb1select.TabStop = false;
            this.gb1select.Text = "1. Select records to update";
            // 
            // cmbSource
            // 
            this.cmbSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSource.FormattingEnabled = true;
            this.cmbSource.Items.AddRange(new object[] {
            "Edit FetchXML",
            "Use FetchXML Builder",
            "Open File",
            "Open View"});
            this.cmbSource.Location = new System.Drawing.Point(21, 30);
            this.cmbSource.Name = "cmbSource";
            this.cmbSource.Size = new System.Drawing.Size(169, 21);
            this.cmbSource.TabIndex = 26;
            // 
            // gb2attribute
            // 
            this.gb2attribute.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb2attribute.Controls.Add(this.label1);
            this.gb2attribute.Controls.Add(this.cmbAttribute);
            this.gb2attribute.Location = new System.Drawing.Point(6, 122);
            this.gb2attribute.Name = "gb2attribute";
            this.gb2attribute.Size = new System.Drawing.Size(308, 82);
            this.gb2attribute.TabIndex = 35;
            this.gb2attribute.TabStop = false;
            this.gb2attribute.Text = "2. Select attribute to update";
            // 
            // gb3value
            // 
            this.gb3value.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb3value.Controls.Add(this.cmbValue);
            this.gb3value.Controls.Add(this.rbSetNull);
            this.gb3value.Controls.Add(this.chkOnlyChange);
            this.gb3value.Controls.Add(this.rbSetTouch);
            this.gb3value.Controls.Add(this.rbSetValue);
            this.gb3value.Location = new System.Drawing.Point(6, 221);
            this.gb3value.Name = "gb3value";
            this.gb3value.Size = new System.Drawing.Size(308, 109);
            this.gb3value.TabIndex = 36;
            this.gb3value.TabStop = false;
            this.gb3value.Text = "3. Choose update method";
            // 
            // gb4update
            // 
            this.gb4update.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb4update.Controls.Add(this.lblUpdateStatus);
            this.gb4update.Controls.Add(this.btnUpdate);
            this.gb4update.Location = new System.Drawing.Point(6, 347);
            this.gb4update.Name = "gb4update";
            this.gb4update.Size = new System.Drawing.Size(308, 89);
            this.gb4update.TabIndex = 37;
            this.gb4update.TabStop = false;
            this.gb4update.Text = "4. Execute update";
            // 
            // lblUpdateStatus
            // 
            this.lblUpdateStatus.AutoSize = true;
            this.lblUpdateStatus.Location = new System.Drawing.Point(18, 61);
            this.lblUpdateStatus.Name = "lblUpdateStatus";
            this.lblUpdateStatus.Size = new System.Drawing.Size(86, 13);
            this.lblUpdateStatus.TabIndex = 1;
            this.lblUpdateStatus.Text = "Nothing updated";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(18, 29);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(118, 23);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "Update records";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.listView1);
            this.groupBox5.Location = new System.Drawing.Point(11, 16);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(341, 455);
            this.groupBox5.TabIndex = 38;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Records";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Window;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label2.Location = new System.Drawing.Point(29, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(234, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hold on. Soon... In a release in the near future...";
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(3, 16);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(335, 436);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gb1select);
            this.splitContainer1.Panel1.Controls.Add(this.gb2attribute);
            this.splitContainer1.Panel1.Controls.Add(this.gb4update);
            this.splitContainer1.Panel1.Controls.Add(this.gb3value);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Panel1MinSize = 100;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox5);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(698, 487);
            this.splitContainer1.SplitterDistance = 328;
            this.splitContainer1.TabIndex = 39;
            // 
            // DataUpdater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStripMain);
            this.Name = "DataUpdater";
            this.Size = new System.Drawing.Size(698, 512);
            this.ConnectionUpdated += new ConnectionUpdatedHandler(this.DataUpdater_ConnectionUpdated);
            this.Load += new System.EventHandler(this.DataUpdater_Load);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.gb1select.ResumeLayout(false);
            this.gb1select.PerformLayout();
            this.gb2attribute.ResumeLayout(false);
            this.gb2attribute.PerformLayout();
            this.gb3value.ResumeLayout(false);
            this.gb3value.PerformLayout();
            this.gb4update.ResumeLayout(false);
            this.gb4update.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        internal System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton tsbCloseThisTab;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbAbout;
        private System.Windows.Forms.ToolStripDropDownButton tsbOptions;
        private System.Windows.Forms.ToolStripMenuItem tsmiFriendly;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowAttributes;
        internal System.Windows.Forms.ToolStripMenuItem tsmiAttributesAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        internal System.Windows.Forms.ToolStripMenuItem tsmiAttributesManaged;
        internal System.Windows.Forms.ToolStripMenuItem tsmiAttributesUnmanaged;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        internal System.Windows.Forms.ToolStripMenuItem tsmiAttributesCustomizable;
        private System.Windows.Forms.ToolStripMenuItem tsmiAttributesUncustomizable;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.ToolStripMenuItem tsmiAttributesStandard;
        internal System.Windows.Forms.ToolStripMenuItem tsmiAttributesCustom;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
        internal System.Windows.Forms.ToolStripMenuItem tsmiAttributesOnlyValidAF;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.Button btnGetRecords;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.ComboBox cmbAttribute;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbSetNull;
        private System.Windows.Forms.RadioButton rbSetTouch;
        private System.Windows.Forms.RadioButton rbSetValue;
        private System.Windows.Forms.ComboBox cmbValue;
        private System.Windows.Forms.CheckBox chkOnlyChange;
        private System.Windows.Forms.GroupBox gb1select;
        private System.Windows.Forms.GroupBox gb2attribute;
        private System.Windows.Forms.GroupBox gb3value;
        private System.Windows.Forms.GroupBox gb4update;
        private System.Windows.Forms.Label lblUpdateStatus;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox cmbSource;
    }
}
