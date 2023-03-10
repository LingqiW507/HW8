using System;
using System.Collections.Generic;

namespace ZooManager
{
    public interface IPrey
    {
        List<string> Predators { get; }
        bool Flee();
    }
}
