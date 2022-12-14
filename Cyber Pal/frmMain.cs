using System.Windows.Forms;

namespace CyberPal.App
{
    public partial class frmMain : Form
    {
        private ucPolicy _policyFrm;

        public frmMain()
        {            
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            LoadMainTreeNav();
            InitializePolicySection();
        }

        private void InitializePolicySection()
        {
            _policyFrm = new ucPolicy();
            _policyFrm.Dock = DockStyle.Fill;
        }

        private void LoadMainTreeNav()
        {
            tvMain.Nodes.Add("tvKeyPolicy", "Policies", 0, 0);
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
                    break;
            }            
        }
    }
}