using MefSkeletalWithHelp.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;

namespace MefSkeletalWithHelp.Tasks
{
    [Export(typeof(ITaskHandler))]
    [ExportMetadata("name", "task2")]
    [ExportMetadata("help", "This is Task2. Usage: --arg0 value0 --arg1 value1 --arg2 value2 --arg3 value3")]
    public class Task3 : ITaskHandler
    {
        public void OnExecute(string[] args)
        {
            Console.WriteLine("This is Task 2");
        }
    }
}
