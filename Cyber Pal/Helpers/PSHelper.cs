using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation.Runspaces;
using System.Management.Automation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.PowerShell;

namespace CyberPal.App.Helpers
{
    public class PSHelper
    {
        public static bool ExecutePS(string file, List<Tuple<string, string>> args)
        {
            bool retval = false;

            InitialSessionState iss = InitialSessionState.CreateDefault();
            iss.ExecutionPolicy = ExecutionPolicy.Unrestricted;

            using (Runspace runspace = RunspaceFactory.CreateRunspace(iss))
            {
                runspace.Open();

                using (Pipeline pipeline = runspace.CreatePipeline())
                {
                    Command cmd = new Command(file);

                    foreach (var arg in args)
                    {
                        CommandParameter cp = new CommandParameter(arg.Item1, arg.Item2);
                        cmd.Parameters.Add(cp);
                    }

                    pipeline.Commands.Add(cmd);

                    Collection<PSObject> results = pipeline.Invoke();

                    retval = !pipeline.HadErrors;                    

                    runspace.Close();
                    
                }
            }

            return retval;
        }
    }
}
