﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalProjectPTT.Models
{
    public class ATask : AbstractTask
    {
        public string Title { get; set; }
        public decimal Budget { get; set; }
        public string AssignedEmployee { get; set; }

        public DateTime CreateDate { get; set; }

        public ICollection<Comment> Comments { get; set; }

    }
}