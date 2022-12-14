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
    public partial class ucPolicy : UserControl
    {
        public ucPolicy()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            lvPolicies.Columns[3].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            LoadPolicyStatus();
        }
        
        private async Task LoadPolicyStatus()
        {
            try
            {
                PolicyAnalyzer pa = new PolicyAnalyzer();
                pa.AnalyzeAsync();

                lvPolicies.Items.Clear();
                foreach (var result in pa.Results)
                {
                    var lvItem = new ListViewItem("");
                    lvItem.ImageIndex = result.Item1 ? 1 : 0;
                    lvItem.SubItems.Add(result.Item2);
                    lvItem.SubItems.Add(result.Item3);
                    lvItem.SubItems.Add(result.Item4);

                    lvPolicies.Items.Add(lvItem);
                }
            }
            catch (Exception ex)
            {

            }

            tmrRefresh.Enabled = true;
        }

        private void tmrRefresh_Tick(object sender, EventArgs e)
        {
            tmrRefresh.Enabled = false;
            LoadPolicyStatus();
        }
    }
}
