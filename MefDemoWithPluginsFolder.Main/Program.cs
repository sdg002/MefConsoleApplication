using System;
using System.Linq;

namespace MefDemoWithPluginsFolder.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Demo of cmd line utility executable built using MEF!");
            try
            {
                string exeFile = System.Reflection.Assembly.GetExecutingAssembly().Location;
                string exeFolder = System.IO.Path.GetDirectoryName(exeFile);
                string folderPlugins = System.IO.Path.Combine(exeFolder, "Plugins");
                MefHost host = new MefHost(folderPlugins);
                string taskname = null;
                if ((args.Length == 0) || (args[0].ToLower() == "help") || (args[0].ToLower() == "/?"))
                {
                    taskname = "help";
                }
                else
                {
                    taskname = args[0];
                }
                host.ExecTask(taskname, args.Skip(1).ToArray());

                    //3 Add metadata to display detailed help using resource files

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
