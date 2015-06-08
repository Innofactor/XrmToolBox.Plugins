namespace AutoDeployTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainControl));
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.bPlugin = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gbPlugin = new System.Windows.Forms.GroupBox();
            this.lPlugin = new System.Windows.Forms.Label();
            this.ofdPlugin = new System.Windows.Forms.OpenFileDialog();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tsMenu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.gbPlugin.SuspendLayout();
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
            // bPlugin
            // 
            this.bPlugin.Location = new System.Drawing.Point(6, 15);
            this.bPlugin.Name = "bPlugin";
            this.bPlugin.Size = new System.Drawing.Size(75, 23);
            this.bPlugin.TabIndex = 1;
            this.bPlugin.Text = "Select";
            this.bPlugin.UseVisualStyleBackColor = true;
            this.bPlugin.Click += new System.EventHandler(this.button1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.gbPlugin, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbLog, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(600, 375);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // gbPlugin
            // 
            this.gbPlugin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbPlugin.Controls.Add(this.lPlugin);
            this.gbPlugin.Controls.Add(this.bPlugin);
            this.gbPlugin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbPlugin.Location = new System.Drawing.Point(3, 3);
            this.gbPlugin.Name = "gbPlugin";
            this.gbPlugin.Size = new System.Drawing.Size(594, 44);
            this.gbPlugin.TabIndex = 2;
            this.gbPlugin.TabStop = false;
            this.gbPlugin.Text = "Plugin to watch";
            // 
            // lPlugin
            // 
            this.lPlugin.AutoSize = true;
            this.lPlugin.Location = new System.Drawing.Point(87, 20);
            this.lPlugin.Name = "lPlugin";
            this.lPlugin.Size = new System.Drawing.Size(0, 13);
            this.lPlugin.TabIndex = 2;
            // 
            // ofdPlugin
            // 
            this.ofdPlugin.FileName = "openFileDialog1";
            // 
            // tbLog
            // 
            this.tbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLog.Enabled = false;
            this.tbLog.Location = new System.Drawing.Point(3, 53);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.Size = new System.Drawing.Size(594, 319);
            this.tbLog.TabIndex = 3;
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
            // MainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tsMenu);
            this.Name = "MainControl";
            this.Size = new System.Drawing.Size(600, 400);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.gbPlugin.ResumeLayout(false);
            this.gbPlugin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.Button bPlugin;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox gbPlugin;
        private System.Windows.Forms.OpenFileDialog ofdPlugin;
        private System.Windows.Forms.Label lPlugin;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.ToolStripButton tsbClose;
    }
}
