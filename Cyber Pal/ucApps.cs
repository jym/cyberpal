using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CyberPal.App
{
    public partial class ucApps : UserControl
    {
        public StatusBarMessageDelegate SetStatusBarMessage;
        public frmMain ParentForm { get; set; }

        public ucApps()
        {
            InitializeComponent();
        }

        public async Task LoadAppStatus()
        {
            try
            {               
                if (!ParentForm.PolicyItems.ContainsKey("AuditProcessTracking") || ParentForm.PolicyItems["AuditProcessTracking"].Value == "0")
                {
                    rdoAppAuditEnable.Checked = false;
                    rdoAppAuditDisable.Checked = true;
                }
                else
                {
                    rdoAppAuditEnable.Checked = true;
                    rdoAppAuditDisable.Checked = false;
                }
            }
            catch (Exception ex)
            {
                //SetStatusBarMessage("Error while loading app details, make sure you are running as admin");
            }

            tmrRefresh.Enabled = true;
        }

        private void tmrRefresh_Tick(object sender, EventArgs e)
        {
            tmrRefresh.Enabled = false;
            LoadAppStatus();
        }

        private void rdoAppAuditEnable_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdoAppAuditDisable_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
