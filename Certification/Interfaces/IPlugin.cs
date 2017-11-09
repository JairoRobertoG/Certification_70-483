using Certification.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certification.Interfaces
{
    public interface IPlugin
    {
        string Name { get; }
        string Description { get; }
        //bool Load(MyApplication application);
    }
}
