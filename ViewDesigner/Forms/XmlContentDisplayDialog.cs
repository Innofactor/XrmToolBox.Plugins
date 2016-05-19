namespace Cinteros.XTB.ViewDesigner.Forms
{
    using System;
    using System.Windows.Forms;
    using System.Xml;
    using Cinteros.Xrm.XmlEditorUtils;

    public partial class XmlContentDisplayDialog : Form
    {
        #region Public Fields

        public XmlNode result;

        #endregion Public Fields

        #region Private Fields

        private string findtext = "";

        #endregion Private Fields

        #region Public Constructors

        public XmlContentDisplayDialog(string xmlString, string header, bool allowEdit, bool allowFormat)
        {
            InitializeComponent();
            //if (FetchXmlBuilder.xmlWinSize != null && FetchXmlBuilder.xmlWinSize.Width > 0 && FetchXmlBuilder.xmlWinSize.Height > 0)
            //{
            //    Width = FetchXmlBuilder.xmlWinSize.Width;
            //    Height = FetchXmlBuilder.xmlWinSize.Height;
            //}
            Text = string.IsNullOrEmpty(header) ? "FetchXML Builder" : header;
            panOk.Visible = allowEdit;
            if (!allowEdit)
            {
                btnCancel.Text = "Close";
            }
            btnFormat.Visible = allowFormat;
            if (xmlString.Length > 100000)
            {
                var dlgresult = MessageBox.Show("Huge result, this may take a while!\n" + xmlString.Length.ToString() + " characters in the XML document.\n\nContinue?", "Huge result",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dlgresult == DialogResult.No)
                {
                    xmlString = "";
                }
            }
            txtXML.Text = xmlString;
            FormatXML(true);
        }

        #endregion Public Constructors

        #region Public Methods

        public void UpdateXML(string xmlString)
        {
            txtXML.Text = xmlString;
            FormatXML(true);
        }

        #endregion Public Methods

        #region Private Methods

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(txtXML.Text);
                result = doc.DocumentElement;
            }
            catch (Exception error)
            {
                DialogResult = DialogResult.None;
                MessageBox.Show(this, "Error while parsing Xml: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormatXML(false);
        }

        private void FormatXML(bool silent)
        {
            try
            {
                txtXML.Process();
            }
            catch (Exception ex)
            {
                if (!silent)
                {
                    MessageBox.Show(ex.Message, "XML Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // MainControl.DownloadFXB();
        }

        private void XmlContentDisplayDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            //FetchXmlBuilder.xmlWinSize = new System.Drawing.Size(Width, Height);
        }

        private void XmlContentDisplayDialog_KeyDown(object sender, KeyEventArgs e)
        {
            RichTextBox textBox = txtXML;
            findtext = FindTextHandler.HandleFindKeyPress(e, textBox, findtext);
        }

        #endregion Private Methods
    }
}