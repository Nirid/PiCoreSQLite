﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PiCoreSQLite.Models
{
    public class CompletedTasks
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
    }
}
