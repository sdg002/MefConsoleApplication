﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;

namespace MefSkeletalWithHelp.Contracts
{
    public class Container
    {
        public Container()
        {
            var assem = System.Reflection.Assembly.GetExecutingAssembly();
            var cat = new AssemblyCatalog(assem);
            var compose = new CompositionContainer(cat);
            compose.ComposeParts(this);
            this.Parent = this;
        }
        /// <summary>
        /// Use MEF metadata to find instances and then fire ExecTask method
        /// </summary>
        /// <param name="taskname">Short name of the Task </param>
        /// <param name="args">Command line arguments that were passed to the EXE</param>
        internal void ExecTask(string taskname, string[] args)
        {
            var lazy = this.Tasks.FirstOrDefault(t => (string)t.Metadata["name"] == taskname);
            if (lazy == null)
            {
                throw new ArgumentException($"No task with name={taskname} was found");
            }
            ITaskHandler task = lazy.Value;
            task.OnExecute(args);
        }
        /// <summary>
        /// Used for dependency injection. E.g. HelpTask.cs would need this to discover all other Task objects
        /// </summary>
        [Export("parent")]
        public Container Parent { get; set; }

        [ImportMany(typeof(ITaskHandler))]
        public Lazy<ITaskHandler, Dictionary<string, object>>[] Tasks { get; set; }
    }
}
