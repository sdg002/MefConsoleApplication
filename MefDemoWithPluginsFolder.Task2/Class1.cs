using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;

namespace MefDemoWithPluginsFolder.Task2
{
    [Export(typeof(MefDemoWithPluginsFolder.Contracts.ITaskHandler))]
    [ExportMetadata("name", "task2")]
    public class Class1 : Contracts.ITaskHandler
    {
        public void OnExecute(string[] args)
        {
            Console.WriteLine("This is Task 2");
        }
    }
}
