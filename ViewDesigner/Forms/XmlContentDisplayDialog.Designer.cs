namespace Cinteros.XTB.ViewDesigner.Forms
{
    partial class XmlContentDisplayDialog
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
            CSRichTextBoxSyntaxHighlighting.XMLViewerSettings xmlViewerSettings1 = new CSRichTextBoxSyntaxHighlighting.XMLViewerSettings();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XmlContentDisplayDialog));
            this.panBottom = new System.Windows.Forms.Panel();
            this.panOk = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.panCancel = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnFormat = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbXml = new System.Windows.Forms.GroupBox();
            this.txtXML = new CSRichTextBoxSyntaxHighlighting.XMLViewer();
            this.panBottom.SuspendLayout();
            this.panOk.SuspendLayout();
            this.panCancel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbXml.SuspendLayout();
            this.SuspendLayout();
            // 
            // panBottom
            // 
            this.panBottom.BackColor = System.Drawing.SystemColors.Control;
            this.panBottom.Controls.Add(this.panOk);
            this.panBottom.Controls.Add(this.panCancel);
            this.panBottom.Controls.Add(this.btnFormat);
            this.panBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panBottom.Location = new System.Drawing.Point(0, 533);
            this.panBottom.Name = "panBottom";
            this.panBottom.Size = new System.Drawing.Size(784, 28);
            this.panBottom.TabIndex = 4;
            // 
            // panOk
            // 
            this.panOk.Controls.Add(this.btnOk);
            this.panOk.Dock = System.Windows.Forms.DockStyle.Right;
            this.panOk.Location = new System.Drawing.Point(602, 0);
            this.panOk.Name = "panOk";
            this.panOk.Size = new System.Drawing.Size(91, 28);
            this.panOk.TabIndex = 4;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(16, 0);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // panCancel
            // 
            this.panCancel.Controls.Add(this.btnCancel);
            this.panCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.panCancel.Location = new System.Drawing.Point(693, 0);
            this.panCancel.Name = "panCancel";
            this.panCancel.Size = new System.Drawing.Size(91, 28);
            this.panCancel.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(13, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnFormat
            // 
            this.btnFormat.Location = new System.Drawing.Point(6, 0);
            this.btnFormat.Name = "btnFormat";
            this.btnFormat.Size = new System.Drawing.Size(75, 23);
            this.btnFormat.TabIndex = 2;
            this.btnFormat.Text = "Format XML";
            this.btnFormat.UseVisualStyleBackColor = true;
            this.btnFormat.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gbXml);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 530);
            this.panel1.TabIndex = 5;
            // 
            // gbXml
            // 
            this.gbXml.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbXml.Controls.Add(this.txtXML);
            this.gbXml.Location = new System.Drawing.Point(3, 3);
            this.gbXml.Name = "gbXml";
            this.gbXml.Size = new System.Drawing.Size(778, 524);
            this.gbXml.TabIndex = 0;
            this.gbXml.TabStop = false;
            this.gbXml.Text = "XML";
            // 
            // txtXML
            // 
            this.txtXML.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtXML.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtXML.Location = new System.Drawing.Point(3, 16);
            this.txtXML.Name = "txtXML";
            xmlViewerSettings1.AttributeKey = System.Drawing.Color.Red;
            xmlViewerSettings1.AttributeValue = System.Drawing.Color.Blue;
            xmlViewerSettings1.Comment = System.Drawing.Color.Empty;
            xmlViewerSettings1.Element = System.Drawing.Color.DarkRed;
            xmlViewerSettings1.Tag = System.Drawing.Color.Blue;
            xmlViewerSettings1.Value = System.Drawing.Color.Black;
            this.txtXML.Settings = xmlViewerSettings1;
            this.txtXML.Size = new System.Drawing.Size(772, 505);
            this.txtXML.TabIndex = 2;
            this.txtXML.Text = "";
            // 
            // XmlContentDisplayDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panBottom);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "XmlContentDisplayDialog";
            this.ShowIcon = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.XmlContentDisplayDialog_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.XmlContentDisplayDialog_KeyDown);
            this.panBottom.ResumeLayout(false);
            this.panOk.ResumeLayout(false);
            this.panCancel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.gbXml.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panBottom;
        private System.Windows.Forms.Panel panOk;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Panel panCancel;
        private System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnFormat;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbXml;
        internal CSRichTextBoxSyntaxHighlighting.XMLViewer txtXML;
    }
}