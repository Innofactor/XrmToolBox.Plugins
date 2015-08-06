namespace Cinteros.Xrm.ViewDesignerTool.Controls
{
    partial class ViewEditor
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
            this.gbDesign = new System.Windows.Forms.GroupBox();
            this.cbEntity = new System.Windows.Forms.ComboBox();
            this.cbView = new System.Windows.Forms.ComboBox();
            this.lEntity = new System.Windows.Forms.Label();
            this.lView = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.gbDesign, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbEntity, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbView, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lEntity, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lView, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 37);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(600, 363);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // gbDesign
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.gbDesign, 4);
            this.gbDesign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDesign.Location = new System.Drawing.Point(3, 28);
            this.gbDesign.Name = "gbDesign";
            this.gbDesign.Size = new System.Drawing.Size(594, 332);
            this.gbDesign.TabIndex = 0;
            this.gbDesign.TabStop = false;
            this.gbDesign.Text = "Design";
            // 
            // cbEntity
            // 
            this.cbEntity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbEntity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbEntity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbEntity.FormattingEnabled = true;
            this.cbEntity.Location = new System.Drawing.Point(53, 3);
            this.cbEntity.Name = "cbEntity";
            this.cbEntity.Size = new System.Drawing.Size(244, 21);
            this.cbEntity.TabIndex = 1;
            this.cbEntity.SelectedIndexChanged += new System.EventHandler(this.cbEntity_SelectedIndexChanged);
            // 
            // cbView
            // 
            this.cbView.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbView.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbView.FormattingEnabled = true;
            this.cbView.Location = new System.Drawing.Point(353, 3);
            this.cbView.Name = "cbView";
            this.cbView.Size = new System.Drawing.Size(244, 21);
            this.cbView.TabIndex = 2;
            this.cbView.SelectedIndexChanged += new System.EventHandler(this.cbView_SelectedIndexChanged);
            // 
            // lEntity
            // 
            this.lEntity.AutoSize = true;
            this.lEntity.Location = new System.Drawing.Point(3, 0);
            this.lEntity.Name = "lEntity";
            this.lEntity.Size = new System.Drawing.Size(36, 13);
            this.lEntity.TabIndex = 3;
            this.lEntity.Text = "Entity:";
            // 
            // lView
            // 
            this.lView.AutoSize = true;
            this.lView.Location = new System.Drawing.Point(303, 0);
            this.lView.Name = "lView";
            this.lView.Size = new System.Drawing.Size(33, 13);
            this.lView.TabIndex = 4;
            this.lView.Text = "View:";
            // 
            // ViewEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ViewEditor";
            this.Size = new System.Drawing.Size(600, 400);
            this.Load += new System.EventHandler(this.ViewEditor_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox gbDesign;
        private System.Windows.Forms.Label lView;
        private System.Windows.Forms.ComboBox cbEntity;
        private System.Windows.Forms.ComboBox cbView;
        private System.Windows.Forms.Label lEntity;


    }
}
