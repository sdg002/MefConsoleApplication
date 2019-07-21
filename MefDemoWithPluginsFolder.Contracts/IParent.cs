using System;
using System.Collections.Generic;
using System.Text;

namespace MefDemoWithPluginsFolder.Contracts
{
    public interface IParent
    {
        Lazy<MefDemoWithPluginsFolder.Contracts.ITaskHandler, Dictionary<string, Object>>[] Tasks { get; set; }
    }
}
