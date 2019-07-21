using MefSkeletal.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;

namespace MefSkeletal.Tasks
{
    [Export(typeof(ITaskHandler))]
    [ExportMetadata("name","task3")]
    public class Task3 : ITaskHandler
    {
        public void OnExecute(string[] args)
        {
            Console.WriteLine("This is Task 3");
        }
    }
}
