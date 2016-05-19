namespace Cinteros.XTB.ViewDesigner.Forms
{
    partial class SetSizeDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetSizeDialog));
            this.cbColumnSize = new System.Windows.Forms.TextBox();
            this.bSetSize = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbColumnSize
            // 
            this.cbColumnSize.Location = new System.Drawing.Point(12, 12);
            this.cbColumnSize.Name = "cbColumnSize";
            this.cbColumnSize.Size = new System.Drawing.Size(100, 20);
            this.cbColumnSize.TabIndex = 3;
            // 
            // bSetSize
            // 
            this.bSetSize.Location = new System.Drawing.Point(118, 10);
            this.bSetSize.Name = "bSetSize";
            this.bSetSize.Size = new System.Drawing.Size(75, 23);
            this.bSetSize.TabIndex = 2;
            this.bSetSize.Text = "Set Size";
            this.bSetSize.UseVisualStyleBackColor = true;
            this.bSetSize.Click += new System.EventHandler(this.bSetSize_Click);
            // 
            // SetSizeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(204, 41);
            this.Controls.Add(this.cbColumnSize);
            this.Controls.Add(this.bSetSize);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SetSizeDialog";
            this.Text = "Set Size";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox cbColumnSize;
        private System.Windows.Forms.Button bSetSize;
    }
}