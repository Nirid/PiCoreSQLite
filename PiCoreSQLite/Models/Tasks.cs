using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PiCoreSQLite.Models
{
    public class Tasks
    {
        public int Id { get; set; }
        [Display(Name = "Nazwa zadania")]
        public string Name { get; set; }
        [Display(Name = "Opis zadania")]
        public string Description { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Data Zadania")]
        public DateTime CreationDate { get; set; }
        [Display(Name = "Trudność zadania")]
        public double Difficulty { get; set; }
        [DataType(DataType.Time)]
        [Display(Name = "Czas trwania zadania")]
        public TimeSpan Duration { get; set; }
        [Display(Name = "Kategorie zadania")]
        public string Categories { get; set; }
        public int? AssignedId { get; set; }
        public int? CompletedId { get; set; }
    }
}
