using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts;

namespace Assets.Scripts
{
    public interface Iterator
    {
        bool hasNext();
        Object next();
    }
}
