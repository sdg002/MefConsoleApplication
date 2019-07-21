using MefSkeletalWithHelp.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;

namespace MefSkeletalWithHelp.Tasks
{
    /// <summary>
    /// Responsible for displaying Help information
    /// </summary>
    [Export(typeof(ITaskHandler))]
    [ExportMetadata("name", "help")]
    public class HelpTask : ITaskHandler
    {
        public void OnExecute(string[] args)
        {
            Console.WriteLine("This is Help Task");

        }
        [Import("parent")]
        public Container Parent { get; set; }

    }
}
