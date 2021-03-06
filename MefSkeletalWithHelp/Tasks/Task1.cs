﻿using MefSkeletalWithHelp.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;

namespace MefSkeletalWithHelp.Tasks
{
    [Export(typeof(ITaskHandler))]
    [ExportMetadata("name", "task1")]
    [ExportMetadata("help", "This is Task1. Usage: --arg0 value0 --arg1 value1 --arg2 value2")]
    public class Task1 : ITaskHandler
    {
        public void OnExecute(string[] args)
        {
            Console.WriteLine("This is Task 1");
        }
    }
}
