using MefSkeletal.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;

namespace MefSkeletal.Tasks
{
    [Export(typeof(ITaskHandler))]
    [ExportMetadata("name","task1")]
    public class Task1 : ITaskHandler
    {
        public void OnExecute(string[] args)
        {
            Console.WriteLine("This is Task 1");
        }
    }
}
