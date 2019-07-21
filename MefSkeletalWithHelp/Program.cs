using MefSkeletalWithHelp.Contracts;
using System;
using System.Linq;

namespace MefSkeletalWithHelp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            try
            {
                Container container = new Container();
                string taskname = null;
                if ((args.Length == 0) || (args[0].ToLower() == "help" ) || (args[0].ToLower() =="/?"))
                {
                    taskname = "help";
                }
                else
                {
                    taskname = args[0];
                }
                container.ExecTask(taskname, args.Skip(1).ToArray());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
