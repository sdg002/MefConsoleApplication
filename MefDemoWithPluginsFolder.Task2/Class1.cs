using System;

namespace MefDemoWithPluginsFolder.Task2
{
    public class Class1 : Contracts.ITaskHandler
    {
        public void OnExecute(string[] args)
        {
            Console.WriteLine("This is Task 2");
        }
    }
}
