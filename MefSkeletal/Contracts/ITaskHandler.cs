﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MefSkeletal.Contracts
{
    /// <summary>
    /// Should be implemented by every custom Task implementation
    /// </summary>
    public interface ITaskHandler
    {
        void OnExecute(string[] args);
    }
}
