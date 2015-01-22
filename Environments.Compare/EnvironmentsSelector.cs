using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XrmToolBox;

namespace Environments.Compare
{
    public partial class EnvironmentsSelector : PluginBase  
    {
        public EnvironmentsSelector()
        {
            InitializeComponent();
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            base.CloseToolPrompt();
        }

        private void tsbCompare_Click(object sender, EventArgs e)
        {

        }
    }
}
