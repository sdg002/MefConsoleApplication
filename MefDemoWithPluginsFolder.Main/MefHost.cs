using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
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
