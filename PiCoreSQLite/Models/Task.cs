using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PiCoreSQLite.Models
{
    public class Task : DbContext
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public double Difficulty { get; set; }
        public double Duration { get; set; }
        public string Categories { get; set; }
        public int AssignedId { get; set; }
        public int CompletedId { get; set; }
        
    }
}
