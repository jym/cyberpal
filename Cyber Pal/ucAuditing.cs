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
    public partial class ucAuditing : UserControl
    {
        public StatusBarMessageDelegate SetStatusBarMessage;
        public frmMain ParentForm { get; set; }

        public ucAuditing()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            lvAudits.Columns[3].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvAudits.DoubleBuffered(true);
            lvAudits.HideSelection = false;
        }

        public async Task LoadAuditStatus()
        {
            try
            {
                var items = lvAudits.Items.Cast<ListViewItem>().ToDictionary(i => i.Tag.ToString(), i => i);

                var common = items.Keys.Intersect(ParentForm.AuditItems.Keys);
                var adds = ParentForm.AuditItems.Keys.Except(items.Keys);
                var removes = items.Keys.Except(ParentForm.AuditItems.Keys);

                foreach (var key in common)
                {
                    var ai = ParentForm.AuditItems[key];
                    items[key].ImageIndex = ai.Value == "0" ? 0 : 1;
                    items[key].SubItems.Add(ai.Policy);
                    items[key].SubItems.Add(ai.SubCategory);
                    items[key].SubItems.Add(ai.Setting);                    
                }

                foreach (var key in adds)
                {
                    var ai = ParentForm.AuditItems[key];
                    var lvItem = new ListViewItem("");
                    lvItem.ImageIndex = ai.Value == "0" ? 0 : 1;
                    lvItem.SubItems.Add(ai.Policy);
                    lvItem.SubItems.Add(ai.SubCategory);
                    lvItem.SubItems.Add(ai.Setting);                    
                    lvItem.Tag = ai.Policy;

                    lvAudits.Items.Add(lvItem);
                }

                foreach (var key in removes)
                {
                    lvAudits.Items.Remove(items[key]);
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
            LoadAuditStatus();
        }
        
    }
}
