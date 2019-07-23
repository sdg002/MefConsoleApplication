using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;

namespace MefDemoWithPluginsFolder.Main
{
    /// <summary>
    /// Responsible for plugin discovery through MEF
    /// We adding all subfolders in the Plugins directory
    /// </summary>
    public class MefHost : MefDemoWithPluginsFolder.Contracts.IParent
    {
        public MefHost(string folderPlugins)
        {
            List<DirectoryCatalog> lstPluginsDirCatalogs = new List<DirectoryCatalog>();
            string[] subFolders = System.IO.Directory.GetDirectories(folderPlugins);
            foreach(var subFolder in subFolders)
            {
                var dirCat = new DirectoryCatalog(subFolder, "*plugin*.dll");
                lstPluginsDirCatalogs.Add(dirCat);
            }
            var assem = System.Reflection.Assembly.GetExecutingAssembly();
            var catThisAssembly = new AssemblyCatalog(assem);

            var catAgg = new AggregateCatalog(lstPluginsDirCatalogs);
            catAgg.Catalogs.Add(catThisAssembly);
            var compose = new CompositionContainer(catAgg);
            this.Parent = this;
            compose.ComposeParts(this);
        }
        /// <summary>
        /// Find task handler whose 'name' metadata matches the specified taskname
        /// </summary>
        /// <param name="taskname"></param>
        /// <param name="args"></param>
        internal void ExecTask(string taskname, string[] args)
        {
            var lazy = this.Tasks.FirstOrDefault(t => (string)t.Metadata["name"] == taskname);
            if (lazy == null)
            {
                throw new ArgumentException($"No task with name={taskname} was found");
            }
            var task = lazy.Value;
            task.OnExecute(args);
        }

        [Export(typeof(MefDemoWithPluginsFolder.Contracts.IParent))]
        public MefDemoWithPluginsFolder.Contracts.IParent Parent { get; set; }

        [ImportMany(typeof(MefDemoWithPluginsFolder.Contracts.ITaskHandler))]
        Lazy<MefDemoWithPluginsFolder.Contracts.ITaskHandler, Dictionary<string, Object>>[] _dummyTasks;


        public Lazy<MefDemoWithPluginsFolder.Contracts.ITaskHandler,Dictionary<string,Object>>[] Tasks
        {
            get
            {
                return _dummyTasks;
            }
        }
    }
}
