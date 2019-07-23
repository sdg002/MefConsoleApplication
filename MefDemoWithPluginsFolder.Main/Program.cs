using System;
using System.Linq;

namespace MefDemoWithPluginsFolder.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            try
            {
                string exeFile = System.Reflection.Assembly.GetExecutingAssembly().Location;
                string exeFolder = System.IO.Path.GetDirectoryName(exeFile);
                string folderPlugins = System.IO.Path.Combine(exeFolder, "Plugins");
                MefHost host = new MefHost(folderPlugins);
                var task = host.Tasks.First().Value;
                task.OnExecute(args.Skip(1).ToArray());
                //this is working
                    //1 Wire up command line arguments to execute tasks
                    //2 Wire up command line arguments to display help (all tasks, task specific help)
                    //3 Add metadata to display detailed help using resource files
                    //4 Change to copy local, 

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
