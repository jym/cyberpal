using System.Collections.Concurrent;
using System.Security.AccessControl;
using System.Windows.Forms;

namespace CyberPal.App
{
    public delegate void StatusBarMessageDelegate(string message);

    public partial class frmMain : Form
    {
        private ucApps _appsFrm;
        private ucAuditing _auditFrm;
        private ucPolicy _policyFrm;
        public ConcurrentDictionary<string, PolicyItem> PolicyItems { get; set; } = new ConcurrentDictionary<string, PolicyItem>();
        public ConcurrentDictionary<string, AuditItem> AuditItems { get; set; } = new ConcurrentDictionary<string, AuditItem>();

        public frmMain()
        {            
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            LoadPolicies();
            LoadAudits();
            LoadMainTreeNav();
            InitializePolicySection();
            InitializeAppsSection();
            InitializeAuditingSection();
        }

        private void InitializePolicySection()
        {
            _policyFrm = new ucPolicy();
            _policyFrm.Dock = DockStyle.Fill;
            _policyFrm.ParentForm = this;
            _policyFrm.SetStatusBarMessage = new StatusBarMessageDelegate(this.SetStatusMessageCallback);
        }

        private void InitializeAppsSection()
        {
            _appsFrm = new ucApps();
            _appsFrm.Dock = DockStyle.Fill;
            _appsFrm.ParentForm = this;
            _appsFrm.SetStatusBarMessage = new StatusBarMessageDelegate(this.SetStatusMessageCallback);
        }

        private void InitializeAuditingSection()
        {
            _auditFrm = new ucAuditing();
            _auditFrm.Dock = DockStyle.Fill;
            _auditFrm.ParentForm = this;
            _auditFrm.SetStatusBarMessage = new StatusBarMessageDelegate(this.SetStatusMessageCallback);
        }

        private void LoadMainTreeNav()
        {
            tvMain.HideSelection = false;
            tvMain.Nodes.Add("tvKeyPolicy", "Policies", 0, 0);
            tvMain.Nodes.Add("tvKeyAudit", "Auditing", 3, 3);
            tvMain.Nodes.Add("tvKeyShare", "Shares", 5, 5);
            tvMain.Nodes.Add("tvKeyServices", "Services", 8, 8);
            tvMain.Nodes.Add("tvKeyApps", "Apps", 13, 13);
            tvMain.Nodes.Add("tvKeyUsers", "Users", 14, 14);
        }

        private void tvMain_AfterSelect(object sender, TreeViewEventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();

            switch(e.Node.Name)
            {
                case "tvKeyPolicy":
                    splitContainer1.Panel2.Controls.Add(_policyFrm);
                    _policyFrm.LoadPolicyStatus();
                    break;
                case "tvKeyApps":
                    splitContainer1.Panel2.Controls.Add(_appsFrm);
                    _appsFrm.LoadAppStatus();
                    break;
                case "tvKeyAudit":
                    splitContainer1.Panel2.Controls.Add(_auditFrm);
                    _auditFrm.LoadAuditStatus();
                    break;
            }
        }

        private void SetStatusMessageCallback(string message)
        {
            toolStripStatusLabel1.Text = message;
        }

        private void tmrPolicyLoad_Tick(object sender, EventArgs e)
        {
            LoadPolicies();
            LoadAudits();
        }

        private void LoadPolicies()
        {
            try
            {
                PolicyAnalyzer pa = new PolicyAnalyzer();
                pa.AnalyzeSecPol();

                //We will modify dictionary to maintain thread safety instead of replacing
                var common = PolicyItems.Keys.Intersect(pa.Results.Keys);
                var adds = pa.Results.Keys.Except(PolicyItems.Keys);


                var removes = PolicyItems.Keys.Except(pa.Results.Keys);
                var updates = pa.Results.Keys.Except(removes);

                //Update items in set
                foreach (var key in updates)
                    PolicyItems.AddOrUpdate(key, pa.Results[key], (k, v) => v = new PolicyItem(pa.Results[key]));


                //Remove items in set
                var p = new PolicyItem();

                foreach (var key in removes)
                    PolicyItems.TryRemove(key, out p);
            }
            catch (Exception ex)
            {
                SetStatusMessageCallback("Error while loading policies, make sure you are running as admin");
            }
        }

        public void LoadAudits()
        {
            try
            {
                AuditPol ap = new AuditPol();
                ap.LoadAudits();

                //We will modify dictionary to maintain thread safety instead of replacing                
                var removes = AuditItems.Keys.Except(ap.AuditCategories.Keys);
                var updates = ap.AuditCategories.Keys.Except(removes);

                //Update items in set
                foreach (var key in updates)
                    AuditItems.AddOrUpdate(key, ap.AuditCategories[key], (k, v) => v = new AuditItem(ap.AuditCategories[key]));


                //Remove items in set
                var a = new AuditItem();

                foreach (var key in removes)
                    AuditItems.TryRemove(key, out a);
            }
            catch (Exception ex)
            {
                SetStatusMessageCallback("Error while loading audits, make sure you are running as admin");
            }
        }
    }
}