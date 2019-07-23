using System;
using System.Collections.Generic;
using System.Text;

namespace MefDemoWithPluginsFolder.Contracts
{
    /// <summary>
    /// Allows a Task implementation to interact with the host
    /// E.g. Task1 can get to know about other Task impelmentations that have been discovered throughMEF
    /// </summary>
    public interface IParent
    {
        Lazy<MefDemoWithPluginsFolder.Contracts.ITaskHandler, Dictionary<string, Object>>[] Tasks { get;  }
    }
}
