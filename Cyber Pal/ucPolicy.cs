using System;
using System.Collections.Concurrent;
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
        public StatusBarMessageDelegate SetStatusBarMessage;
        public frmMain ParentForm { get; set; }

        public ucPolicy()
        {
            InitializeComponent();
            Initialize();
        }        

        private void Initialize()
        {            
            lvPolicies.Columns[3].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvPolicies.DoubleBuffered(true);
            lvPolicies.HideSelection = false;
        }
        
        public async Task LoadPolicyStatus()
        {
            try
            {
                var items = lvPolicies.Items.Cast<ListViewItem>().ToDictionary(i => i.Tag.ToString(), i => i);

                var common = items.Keys.Intersect(ParentForm.PolicyItems.Keys);
                var adds = ParentForm.PolicyItems.Keys.Except(items.Keys);
                var removes = items.Keys.Except(ParentForm.PolicyItems.Keys);

                foreach (var key in common)
                {
                    var pi = ParentForm.PolicyItems[key];
                    items[key].ImageIndex = pi.IsValid ? 1 : 0;
                    items[key].SubItems.Add(pi.Name);
                    items[key].SubItems.Add(pi.Value);
                    items[key].SubItems.Add(pi.Description);
                }
                    
                foreach (var key in adds)
                {
                    var pi = ParentForm.PolicyItems[key];
                    var lvItem = new ListViewItem("");                                        
                    lvItem.ImageIndex = pi.IsValid ? 1 : 0;
                    lvItem.SubItems.Add(pi.Name);
                    lvItem.SubItems.Add(pi.Value);
                    lvItem.SubItems.Add(pi.Description);
                    lvItem.Tag = pi.Key;

                    lvPolicies.Items.Add(lvItem);
                }

                foreach (var key in removes)
                {                    
                    lvPolicies.Items.Remove(items[key]);
                }
            }
            catch (Exception ex)
            {
                //SetStatusBarMessage("Error while loading policies, make sure you are running as admin");
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
