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
        public string NameProcess { get; set; }
        public int IdProcess { get; set; }
        public List<ProcessThread> Threads { get; set; }
        public int ThreadsCount { get; set; }
        public long Memory { get; set; }
    }
}
