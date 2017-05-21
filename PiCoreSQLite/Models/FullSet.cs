using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiCoreSQLite.Models
{
    public class FullSet
    {
        public IEnumerable<Tasks> Tasks { get; set; }
        public IEnumerable<AssignedTasks> AssignedTasks { get; set; }
        public IEnumerable<CompletedTasks> CompletedTasks { get; set; }
    }

    public class TaskAndTime
    {
        public Tasks Task { get; set; }
        public IEnumerable<DateTime> Time { get; set; }
    }
}
