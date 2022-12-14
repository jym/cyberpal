using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CyberPal.App
{
    public class PolicyAnalyzer
    {
        /// <summary>
        /// Bool indicates true if the policy is secure, false otherise
        /// String1 - Name of the policy
        /// String2 - Current Value of the policy
        /// String3 - Description
        /// </summary>
        public List<Tuple<bool, string, string, string>> Results { get; set; }

        public PolicyAnalyzer()
        {
            Results = new List<Tuple<bool, string, string, string>>();
        }

        public void AnalyzeAsync()
        {
            AnalyzeSecPol();                                    
        }   
        
        private void AnalyzeSecPol()
        {
            var file = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "secpol.txt");
            if (File.Exists(file))
                File.Delete(file);

            Process p = new Process();
            p.StartInfo.FileName = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\secedit.exe");
            p.StartInfo.Arguments = String.Format(@"/export /cfg ""{0}"" /quiet", file);
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.Start();
            p.WaitForExit();

            var data = string.Empty;
            using (StreamReader sr = new StreamReader(file))
            {
                data = sr.ReadToEnd();
            }

            Regex r = new Regex("([A-Za-z0-9_\\\\\\s]+)\\s*=\\s*([A-Za-z0-9\\\\\\\"\\s]+)\\s*\r\n");

            var matches = r.Matches(data);
            var state = matches.ToDictionary(m => m.Groups[1].Value.Trim().ToLower(), m => m.Groups[2].Value.Trim());

            CheckValueInt(state, "MinimumPasswordAge", 10, 10, "Minimum password age", "The minimum password age should be set to 10 days.");
            CheckValueInt(state, "MaximumPasswordAge", 45, 60, "Maximum password age", "The maximum password age should be set to at least 45 days and not more than 60 days.");
            CheckValueInt(state, "MinimumPasswordLength", 8, 15, "Minimum password length", "The minimum password length should be set to at least 8 characters and not more than 15.");
            CheckValueInt(state, "PasswordHistorySize", 10, 10, "Password history size", "The password history size should be set to 10.");
            CheckValueNot(state, "PasswordComplexity", "Password complexity required", "0 means that password complexity is not required, 1 means it is.", "0");
            CheckValueInt(state, "cleartextpassword", 0, 0, "Store passwords with reversible encyption", "0 means that password are stored in non-reversible form, 1 means it is reversible");
            CheckValueInt(state, "lockoutbadcount", 10, 10, "Bad password lockout count", "The account should lock when 10 bad passwords have been entered");
            CheckValueNot(state, "lockoutduration", "Bad password lockout duration", "The number of minutes that the account should lockout for exceeding the bad password count should be at least 10 minutes.  Value -1 requires an admin to unlock.", "0");
            CheckValueInt(state, "forcelogoffwhenhourexpire", 1, 1, "Force SMB logoff when logon expires", "");
            CheckValueNot(state, "NewAdministratorName", "Rename administrator account", "The administrator account should be rename regardless if the account is active or not", "\"Administrator\"");
            CheckValueNot(state, "NewGuestName", "Rename guest account", "The guest account should be rename regardless if the account is active or not", "\"Guest\"");
            CheckValueIs(state, "EnableAdminAccount", "Enable administrator account", "The administrator account should be disabled", "0");
            CheckValueIs(state, "EnableGuestAccount", "Enable guest account", "The guest account should be disabled", "0");
            CheckValueNot(state, "AuditSystemEvents", "Audit system events", "The system should be configured to audit system events", "0");

        }

        private void CheckValueInt(Dictionary<string, string> state, string key, int min, int max, string name, string description)
        {
            if (state.ContainsKey(key.ToLower()))
            {
                bool isValid = false;
                int val = 0;

                if (int.TryParse(state[key.ToLower()], out val))
                {
                    if (val >= min && val <= max)
                        isValid = true;
                }

                Results.Add(new Tuple<bool, string, string, string>(isValid, name, state[key.ToLower()], description));
            }
            else
                Results.Add(new Tuple<bool, string, string, string>(false, name, "Not Found", "Value not found"));
        }

        private void CheckValueNot(Dictionary<string, string> state, string key, string name, string description, params string[] notValues)
        {
            if (state.ContainsKey(key.ToLower()))
            {
                bool isValid = false;

                List<string> notList = new List<string>(notValues);

                if (!notList.Contains(state[key.ToLower()], StringComparer.OrdinalIgnoreCase))
                    isValid = true;

                Results.Add(new Tuple<bool, string, string, string>(isValid, name, state[key.ToLower()], description));
            }
            else
                Results.Add(new Tuple<bool, string, string, string>(false, name, "Not Found", "Value not found"));
            
        }

        private void CheckValueIs(Dictionary<string, string> state, string key, string name, string description, params string[] okValues)
        {
            if (state.ContainsKey(key.ToLower()))
            {
                bool isValid = false;

                List<string> okList = new List<string>(okValues);

                if (okList.Contains(state[key.ToLower()], StringComparer.OrdinalIgnoreCase))
                    isValid = true;

                Results.Add(new Tuple<bool, string, string, string>(isValid, name, state[key.ToLower()], description));
            }
            else
                Results.Add(new Tuple<bool, string, string, string>(false, name, "Not Found", "Value not found"));

        }

    }
}
