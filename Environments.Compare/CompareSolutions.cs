namespace Environments.Compare
{
    using Microsoft.Xrm.Sdk;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public partial class CompareSolutions : UserControl
    {
        #region Public Constructors

        public CompareSolutions()
        {
            InitializeComponent();
        }

        #endregion Public Constructors

        #region Public Methods

        public void FillWithData(Dictionary<string, List<Entity>> matrix)
        {
        }

        #endregion Public Methods
    }
}