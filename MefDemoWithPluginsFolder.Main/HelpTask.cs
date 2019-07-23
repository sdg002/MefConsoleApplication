using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

namespace MefDemoWithPluginsFolder.Main
{
    [Export(typeof(MefDemoWithPluginsFolder.Contracts.ITaskHandler))]
    [ExportMetadata("name","help")]
    public class HelpTask : Contracts.ITaskHandler
    {
        [Import(typeof(MefDemoWithPluginsFolder.Contracts.IParent))]
        public MefDemoWithPluginsFolder.Contracts.IParent Parent { get; set; }
        public void OnExecute(string[] args)
        {
            if (args.Length == 0)
            {
                DisplayAllTasks();
            }
            else
            {
                string taskname = args[0];
                DisplayTaskSpecificHelp(taskname);
            }
        }
        /// <summary>
        /// Display the help description for the specified Task
        /// </summary>
        /// <param name="taskname"></param>
        private void DisplayTaskSpecificHelp(string taskname)
        {
            Console.WriteLine($"Displaying help on Task:{taskname}");
            var lazy = Parent.Tasks.FirstOrDefault(t => (string)t.Metadata["name"] == taskname.ToLower());
            if (lazy == null)
            {
                throw new ArgumentException($"No task with name={taskname} was found");
            }
            string help = (lazy.Metadata.ContainsKey("help") == false) ? "No help documentation found" : (string)lazy.Metadata["help"];
            Console.WriteLine($"Task:{taskname}");
            Console.WriteLine($"{help}");
        }
        /// <summary>
        /// Display a short list of all Task names.
        /// </summary>
        private void DisplayAllTasks()
        {
            Console.WriteLine("Basic usage information:");
            Console.WriteLine("     <executable>    <taskname>  arg1 arg2 arg3");
            Console.WriteLine("Task specific help");
            Console.WriteLine("     <executable>    help <taskname>");
            Console.WriteLine("List of all Tasks");
            foreach (var lazy in this.Parent.Tasks)
            {
                string task = ((string)lazy.Metadata["name"]).ToLower();
                if (task == "help") continue;
                Console.WriteLine("-----------------------");
                string help = null;
                if (lazy.Metadata.ContainsKey("help"))
                {
                    help = lazy.Metadata["help"] as string;
                }
                else
                {
                    help = "";
                }
                Console.WriteLine($"{task}      {help}");
            }
        }
    }
}
