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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainControl));
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.gbSteps = new System.Windows.Forms.GroupBox();
            this.lvSteps = new System.Windows.Forms.ListView();
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pAssembly1 = new System.Windows.Forms.Panel();
            this.lAssembly = new System.Windows.Forms.Label();
            this.pAssembly2 = new System.Windows.Forms.Panel();
            this.cbAssembly = new System.Windows.Forms.ComboBox();
            this.tsMenu.SuspendLayout();
            this.gbSteps.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pAssembly1.SuspendLayout();
            this.pAssembly2.SuspendLayout();
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
            this.tableLayoutPanel1.SetColumnSpan(this.gbSteps, 2);
            this.gbSteps.Controls.Add(this.lvSteps);
            this.gbSteps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSteps.Location = new System.Drawing.Point(3, 43);
            this.gbSteps.Name = "gbSteps";
            this.gbSteps.Size = new System.Drawing.Size(594, 329);
            this.gbSteps.TabIndex = 1;
            this.gbSteps.TabStop = false;
            this.gbSteps.Text = "SDK Message Processing Steps";
            // 
            // lvSteps
            // 
            this.lvSteps.CheckBoxes = true;
            this.lvSteps.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName});
            this.lvSteps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSteps.FullRowSelect = true;
            this.lvSteps.GridLines = true;
            this.lvSteps.Location = new System.Drawing.Point(3, 16);
            this.lvSteps.Name = "lvSteps";
            this.lvSteps.Size = new System.Drawing.Size(588, 310);
            this.lvSteps.TabIndex = 0;
            this.lvSteps.UseCompatibleStateImageBehavior = false;
            this.lvSteps.View = System.Windows.Forms.View.Details;
            // 
            // chName
            // 
            this.chName.Text = "Name";
            this.chName.Width = 450;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.gbSteps, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pAssembly1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pAssembly2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(600, 375);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // pAssembly1
            // 
            this.pAssembly1.Controls.Add(this.lAssembly);
            this.pAssembly1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pAssembly1.Location = new System.Drawing.Point(3, 3);
            this.pAssembly1.Name = "pAssembly1";
            this.pAssembly1.Size = new System.Drawing.Size(94, 34);
            this.pAssembly1.TabIndex = 2;
            // 
            // lAssembly
            // 
            this.lAssembly.AutoSize = true;
            this.lAssembly.Location = new System.Drawing.Point(3, 10);
            this.lAssembly.Name = "lAssembly";
            this.lAssembly.Size = new System.Drawing.Size(87, 13);
            this.lAssembly.TabIndex = 0;
            this.lAssembly.Text = "Select Assembly:";
            // 
            // pAssembly2
            // 
            this.pAssembly2.Controls.Add(this.cbAssembly);
            this.pAssembly2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pAssembly2.Location = new System.Drawing.Point(103, 3);
            this.pAssembly2.Name = "pAssembly2";
            this.pAssembly2.Size = new System.Drawing.Size(494, 34);
            this.pAssembly2.TabIndex = 3;
            // 
            // cbAssembly
            // 
            this.cbAssembly.FormattingEnabled = true;
            this.cbAssembly.Location = new System.Drawing.Point(3, 7);
            this.cbAssembly.Name = "cbAssembly";
            this.cbAssembly.Size = new System.Drawing.Size(488, 21);
            this.cbAssembly.TabIndex = 0;
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
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pAssembly1.ResumeLayout(false);
            this.pAssembly1.PerformLayout();
            this.pAssembly2.ResumeLayout(false);
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
        private System.Windows.Forms.Panel pAssembly1;
        private System.Windows.Forms.Label lAssembly;
        private System.Windows.Forms.Panel pAssembly2;
        private System.Windows.Forms.ComboBox cbAssembly;
    }
}
