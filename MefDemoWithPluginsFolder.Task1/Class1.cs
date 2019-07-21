using System;

namespace MefDemoWithPluginsFolder.Task1
{
    public class Class1 : Contracts.ITaskHandler
    {
        public void OnExecute(string[] args)
        {
            Console.WriteLine("This is Task 1");
        }
    }
}
