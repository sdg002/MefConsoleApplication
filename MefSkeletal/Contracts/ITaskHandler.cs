using System;
using System.Collections.Generic;
using System.Text;

namespace MefSkeletal.Contracts
{
    public interface ITaskHandler
    {
        void OnExecute(string[] args);
    }
}
