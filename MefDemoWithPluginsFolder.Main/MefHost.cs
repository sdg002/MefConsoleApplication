using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Text;

namespace MefDemoWithPluginsFolder.Main
{
    public class MefHost : MefDemoWithPluginsFolder.Contracts.IParent
    {
        public MefHost()
        {
            var assem = System.Reflection.Assembly.GetExecutingAssembly();
            var cat = new AssemblyCatalog(assem);
            var compose = new CompositionContainer(cat);
            this.Parent = this;
            compose.ComposeParts(this);

        }
        [Export(typeof(MefDemoWithPluginsFolder.Contracts.IParent))]
        public MefDemoWithPluginsFolder.Contracts.IParent Parent { get; set; }

        [ImportMany(typeof(MefDemoWithPluginsFolder.Contracts.ITaskHandler))]
        public Lazy<MefDemoWithPluginsFolder.Contracts.ITaskHandler,Dictionary<string,Object>>[] Tasks { get; set; }
    }
}
