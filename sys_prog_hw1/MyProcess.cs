using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace sys_prog_hw1
{
    public class MyProcess
    {    
        public string NameProcess { get; }
        public int IdProcess { get;}
        public List<ProcessThread> Threads { get; }
    }
}
