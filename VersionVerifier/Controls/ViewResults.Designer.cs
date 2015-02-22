namespace Cinteros.Xrm.VersionVerifier.Controls
{
    partial class ViewResults
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
            this.gbCompareSolutions = new System.Windows.Forms.GroupBox();
            this.lvMatrix = new System.Windows.Forms.ListView();
            this.gbCompareSolutions.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCompareSolutions
            // 
            this.gbCompareSolutions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCompareSolutions.Controls.Add(this.lvMatrix);
            this.gbCompareSolutions.Location = new System.Drawing.Point(0, 34);
            this.gbCompareSolutions.Name = "gbCompareSolutions";
            this.gbCompareSolutions.Size = new System.Drawing.Size(597, 363);
            this.gbCompareSolutions.TabIndex = 0;
            this.gbCompareSolutions.TabStop = false;
            this.gbCompareSolutions.Text = "Compare solutions";
            // 
            // lvSolutions
            // 
            this.lvMatrix.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvMatrix.FullRowSelect = true;
            this.lvMatrix.GridLines = true;
            this.lvMatrix.Location = new System.Drawing.Point(7, 20);
            this.lvMatrix.Name = "lvSolutions";
            this.lvMatrix.Size = new System.Drawing.Size(584, 337);
            this.lvMatrix.TabIndex = 0;
            this.lvMatrix.UseCompatibleStateImageBehavior = false;
            this.lvMatrix.View = System.Windows.Forms.View.Details;
            // 
            // ViewResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.gbCompareSolutions);
            this.DoubleBuffered = true;
            this.Name = "ViewResults";
            this.Size = new System.Drawing.Size(600, 400);
            this.gbCompareSolutions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCompareSolutions;
        private System.Windows.Forms.ListView lvMatrix;
    }
}
