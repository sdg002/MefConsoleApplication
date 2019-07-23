using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;

namespace MefDemoWithPluginsFolder.Task2
{
    [Export(typeof(MefDemoWithPluginsFolder.Contracts.ITaskHandler))]
    [ExportMetadata("name", "task2")]
    [ExportMetadata("help", "This is Task1. Usage: --arg0 value0 --arg1 value1 --arg2 value2")]
    public class Class1 : Contracts.ITaskHandler
    {
        public void OnExecute(string[] args)
        {
            string sArgs = string.Join("|", args);
            Console.WriteLine($"This is Task 2. Arguments:{sArgs}");
        }
    }
}
