using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

    public class Report
    {
        public IEnumerable<Tasks> Assigned { get; set; }
        public IEnumerable<Tasks> Completed { get; set; }
        public Tasks Task { get; set; }
        [DataType(DataType.Date)]
        [Required]
        [Display(Name = "Wybierz date do wyswietlenia")]
        public DateTime Data { get; set; }
        
    }
   
}
