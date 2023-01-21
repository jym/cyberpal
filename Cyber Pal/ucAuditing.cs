using CyberPal.App.Helpers;
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

        private ListViewItem SelectedItem { get; set; } = null;

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

                var common = items.Keys.Intersect(ParentForm.AuditItems.Keys).ToList();
                var adds = ParentForm.AuditItems.Keys.Except(items.Keys).ToList();
                var removes = items.Keys.Except(ParentForm.AuditItems.Keys).ToList();

                foreach (var key in common)
                {
                    var ai = ParentForm.AuditItems[key];                    

                    if (ai == null) continue;

                    items[key].ImageIndex = ai.Value == "0" ? 0 : 1;
                    items[key].SubItems[1].Text = ai.Policy;
                    items[key].SubItems[2].Text = ai.SubCategory;
                    items[key].SubItems[3].Text = ai.Setting;
                }                

                foreach (var key in adds)
                {                    
                    var ai = ParentForm.AuditItems[key];
                    var lvItem = new ListViewItem("");
                    lvItem.ImageIndex = ai.Value == "0" ? 0 : 1;
                    lvItem.SubItems.Add(ai.Policy);
                    lvItem.SubItems.Add(ai.SubCategory);
                    lvItem.SubItems.Add(ai.Setting);                    
                    lvItem.Tag = ai.SubCategory;

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
            tmrRefresh.Enabled = true;
        }

        private void lvAudits_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                
                DisplayContextMenu(e.X, e.Y);
            }
        }       
        
        private void DisplayContextMenu(int x, int y)
        {
            SelectedItem = lvAudits.HitTest(x, y).Item;

            if (SelectedItem != null)
            {
                successToolStripMenuItem.Enabled = SelectedItem.SubItems[3].Text == "Success" ? false : true;
                successFailureToolStripMenuItem.Enabled = SelectedItem.SubItems[3].Text == "Success and Failure" ? false : true;
                failureToolStripMenuItem.Enabled = SelectedItem.SubItems[3].Text == "Failure" ? false : true;
                noAuditingToolStripMenuItem.Enabled = SelectedItem.SubItems[3].Text == "No Auditing" ? false : true;

                ctxMnuOptions.Show(Cursor.Position);

            }
            
        }

        private void successToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExecuteScript(true, false);
        }

        private void failureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExecuteScript(false, true);
        }

        private void successFailureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExecuteScript(true, true);
        }

        private void noAuditingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExecuteScript(false, false);
        }

        private void ExecuteScript(bool success, bool failure)
        {
            try
            {
                if (SelectedItem != null)
                {
                    var t = new Tuple<string, string>("auditSuccess", success ? "enable" : "disable");
                    var t2 = new Tuple<string, string>("auditFailure", failure ? "enable" : "disable");
                    var t3 = new Tuple<string, string>("category", SelectedItem.SubItems[2].Text);

                    if (!PSHelper.ExecutePS(@"Scripts\SetAudit.ps1", new List<Tuple<string, string>>() { t, t2, t3 }))
                    {
                        SetStatusBarMessage("Error while executing PS Script SetAudit.ps1");
                    }

                    ParentForm.LoadAudits();
                    LoadAuditStatus();
                }
            } catch (Exception ex)
            {
                SetStatusBarMessage("Error while executing PS Script SetAudit.ps1");
            }
        }
    }
}
