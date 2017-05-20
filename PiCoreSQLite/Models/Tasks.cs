using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PiCoreSQLite.Models
{
    public class Tasks
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public double Difficulty { get; set; }
        public double Duration { get; set; }
        public string Categories { get; set; }
        public int? AssignedId { get; set; }
        public int? CompletedId { get; set; }
        
    }
}
