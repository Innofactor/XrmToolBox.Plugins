using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cinteros.Xrm.DataUpdater.Forms;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;

namespace Cinteros.Xrm.DataUpdater
{
    public partial class DataUpdater : XrmToolBox.PluginBase, XrmToolBox.IGitHubPlugin, XrmToolBox.IPayPalPlugin
    {
        private static string fetchTemplate = "<fetch count=\"50\"><entity name=\"\"/></fetch>";

        private EntityCollection records;

        public DataUpdater()
        {
            InitializeComponent();
        }

        #region interface implementation

        public override Image PluginLogo
        {
            get
            {
                return imageList1.Images[0];
            }
        }

        public string RepositoryName
        {
            get { return "DataUpdater"; }
        }

        public string UserName
        {
            get { return "Cinteros"; }
        }

        public string DonationDescription
        {
            get { return "Donation to DataUpdater for XrmToolBox"; }
        }

        public string EmailAccount
        {
            get { return "jonas@rappen.net"; }
        }

        #endregion interface implementation

        #region Event handlers

        private void DataUpdater_Load(object sender, EventArgs e)
        {

        }

        private void DataUpdater_ConnectionUpdated(object sender, ConnectionUpdatedEventArgs e)
        {
            EnableControls(true);
        }

        private void tsbCloseThisTab_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        private void btnGetRecords_Click(object sender, EventArgs e)
        {
            GetRecords();
        }

        #endregion Event handlers

        #region Methods

        private void EnableControls(bool enabled)
        {
            btnGetRecords.Enabled = enabled && Service != null;
        }

        private void GetRecords()
        {
            var fetchwin = new XmlContentDisplayDialog(fetchTemplate, "Enter FetchXML to retrieve records to update", true, true);
            if (fetchwin.ShowDialog() == DialogResult.OK)
            {
                RetrieveRecords(fetchwin.txtXML.Text, RetrieveRecordsReady);
            }
        }

        private void RetrieveRecords(string fetch, Action AfterRetrieve)
        {
            lblRecords.Text = "Loading records...";
            records = null;
            WorkAsync("Retrieving records...",
                (eventargs) =>
                {
                    eventargs.Result = Service.RetrieveMultiple(new FetchExpression(fetch));
                },
                (completedargs) =>
                {
                    if (completedargs.Error != null)
                    {
                        MessageBox.Show(completedargs.Error.Message, "Retrieve Records", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (completedargs.Result is EntityCollection)
                    {
                        records = (EntityCollection)completedargs.Result;
                    }
                    AfterRetrieve();
                });
        }

        private void RetrieveRecordsReady()
        {
            if (records != null)
            {
                lblRecords.Text = records.Entities.Count.ToString() + " records of entity " + records.EntityName;
            }
        }

        #endregion Methods
    }
}
