namespace Cinteros.XTB.ViewDesigner.Controls
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
            this.lvDesign = new System.Windows.Forms.ListView();
            this.tlDesign = new System.Windows.Forms.TableLayoutPanel();
            this.gbDetails = new System.Windows.Forms.GroupBox();
            this.tbId = new System.Windows.Forms.TextBox();
            this.lId = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lName = new System.Windows.Forms.Label();
            this.tlDesign.SuspendLayout();
            this.gbDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvDesign
            // 
            this.lvDesign.AllowColumnReorder = true;
            this.lvDesign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvDesign.FullRowSelect = true;
            this.lvDesign.GridLines = true;
            this.lvDesign.Location = new System.Drawing.Point(3, 53);
            this.lvDesign.Name = "lvDesign";
            this.lvDesign.Size = new System.Drawing.Size(594, 344);
            this.lvDesign.TabIndex = 0;
            this.lvDesign.UseCompatibleStateImageBehavior = false;
            this.lvDesign.View = System.Windows.Forms.View.Details;
            this.lvDesign.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvDesign_ColumnClick);
            this.lvDesign.ColumnReordered += new System.Windows.Forms.ColumnReorderedEventHandler(this.lvDesign_ColumnReordered);
            this.lvDesign.ColumnWidthChanged += new System.Windows.Forms.ColumnWidthChangedEventHandler(this.lvDesign_ColumnWidthChanged);
            // 
            // tlDesign
            // 
            this.tlDesign.ColumnCount = 1;
            this.tlDesign.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlDesign.Controls.Add(this.lvDesign, 0, 1);
            this.tlDesign.Controls.Add(this.gbDetails, 0, 0);
            this.tlDesign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlDesign.Location = new System.Drawing.Point(0, 0);
            this.tlDesign.Name = "tlDesign";
            this.tlDesign.RowCount = 2;
            this.tlDesign.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlDesign.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlDesign.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlDesign.Size = new System.Drawing.Size(600, 400);
            this.tlDesign.TabIndex = 1;
            // 
            // gbDetails
            // 
            this.gbDetails.Controls.Add(this.tbId);
            this.gbDetails.Controls.Add(this.lId);
            this.gbDetails.Controls.Add(this.tbName);
            this.gbDetails.Controls.Add(this.lName);
            this.gbDetails.Location = new System.Drawing.Point(3, 3);
            this.gbDetails.Name = "gbDetails";
            this.gbDetails.Size = new System.Drawing.Size(594, 44);
            this.gbDetails.TabIndex = 1;
            this.gbDetails.TabStop = false;
            this.gbDetails.Text = "CRM View";
            // 
            // tbId
            // 
            this.tbId.Location = new System.Drawing.Point(348, 17);
            this.tbId.Name = "tbId";
            this.tbId.ReadOnly = true;
            this.tbId.Size = new System.Drawing.Size(240, 20);
            this.tbId.TabIndex = 1;
            // 
            // lId
            // 
            this.lId.AutoSize = true;
            this.lId.Location = new System.Drawing.Point(326, 20);
            this.lId.Name = "lId";
            this.lId.Size = new System.Drawing.Size(16, 13);
            this.lId.TabIndex = 0;
            this.lId.Text = "Id";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(48, 17);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(272, 20);
            this.tbName.TabIndex = 1;
            this.tbName.TextChanged += new System.EventHandler(this.ViewDesigner_TextChanged);
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Location = new System.Drawing.Point(7, 20);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(35, 13);
            this.lName.TabIndex = 0;
            this.lName.Text = "Name";
            // 
            // ViewEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlDesign);
            this.Name = "ViewEditor";
            this.Size = new System.Drawing.Size(600, 400);
            this.tlDesign.ResumeLayout(false);
            this.gbDetails.ResumeLayout(false);
            this.gbDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvDesign;
        private System.Windows.Forms.TableLayoutPanel tlDesign;
        private System.Windows.Forms.GroupBox gbDetails;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.Label lId;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lName;
    }
}
