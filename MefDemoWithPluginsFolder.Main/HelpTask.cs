using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;

namespace MefDemoWithPluginsFolder.Main
{
    [Export(typeof(MefDemoWithPluginsFolder.Contracts.ITaskHandler))]
    [ExportMetadata("name","help")]
    public class HelpTask : Contracts.ITaskHandler
    {
        public void OnExecute(string[] args)
        {
            throw new NotImplementedException();
        }
        [Import(typeof(MefDemoWithPluginsFolder.Contracts.IParent))]
        public MefDemoWithPluginsFolder.Contracts.IParent Parent { get; set; }
    }
}
