namespace Cinteros.XTB.ViewDesigner.Forms
{
    using System;
    using System.Windows.Forms;

    public partial class SetSizeDialog : Form
    {
        #region Private Fields

        private int initialWidth;

        #endregion Private Fields

        #region Public Constructors

        public SetSizeDialog(string name, int width)
            : this()
        {
            Text = name;

            initialWidth = width;
            cbColumnSize.Text = width.ToString();
        }

        public SetSizeDialog()
        {
            InitializeComponent();
        }

        #endregion Public Constructors

        #region Public Events

        public event EventHandler<int> OnSet;

        #endregion Public Events

        #region Private Methods

        private void bSetSize_Click(object sender, EventArgs e)
        {
            int width = 0;

            int.TryParse(cbColumnSize.Text, out width);

            if (width != initialWidth)
            {
                if (width != 0)
                {
                    OnSet(this, width);
                }
            }
            Close();
        }

        #endregion Private Methods
    }
}