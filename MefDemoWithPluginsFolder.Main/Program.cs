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
                MefHost host = new MefHost();
                var task = host.Tasks.First().Value;
                task.OnExecute(args.Skip(1).ToArray());

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
