using MefSkeletal.Contracts;
using System;
using System.Linq;

namespace MefSkeletal
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Container container = new Container();
                string taskname = args[0];
                container.ExecTask(taskname, args);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
