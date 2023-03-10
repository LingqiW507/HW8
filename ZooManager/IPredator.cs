using System;
using System.Collections.Generic;
namespace ZooManager
{
    public interface IPredator
    {
        List<string> Preys { get;  }
        void Hunt();
    }
}
