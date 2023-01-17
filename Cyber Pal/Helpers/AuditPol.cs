using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Collections.ObjectModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CyberPal.App
{
    internal class AuditPol
    {
        internal ConcurrentDictionary<string, AuditItem> AuditCategories { get; set; } = new ConcurrentDictionary<string, AuditItem>();

        internal AuditPol()
        {
            
        }

        public void LoadAudits()
        {
            AuditCategories.Clear();

            using (Runspace runspace = RunspaceFactory.CreateRunspace())
            {
                runspace.Open();

                using (Pipeline pipeline = runspace.CreatePipeline())
                {
                    pipeline.Commands.AddScript(File.ReadAllText(@"Scripts\GetAuditPolAudits.ps1"));

                    Collection<PSObject> results = pipeline.Invoke();

                    runspace.Close();

                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (PSObject obj in results)
                    {
                        stringBuilder.AppendLine(obj.ToString());
                    }                    

                    Regex r = new Regex("(.*),(.*),(.*),(.*),(.*),(.*)");
                    var matches = r.Matches(stringBuilder.ToString());

                    AuditCategories = new ConcurrentDictionary<string, AuditItem>(matches.Where(m => m.Groups[4].Value.Trim().IsGuid()).ToDictionary(
                            m => m.Groups[3].Value.Trim(),
                            m => new AuditItem()
                            {
                                MachineName = m.Groups[1].Value.Trim(),
                                Policy = m.Groups[2].Value.Trim(),
                                SubCategory = m.Groups[3].Value.Trim(),
                                Guid = Guid.Parse(m.Groups[4].Value.Trim()),
                                Setting = m.Groups[5].Value.Trim(),         
                                Value = m.Groups[6].Value.Trim()
                            }));
                }
            }
        }        
    }
}
