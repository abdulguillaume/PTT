using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalProjectPTT.Models
{
    public class Project: AbstractTask
    {

        public string Name { get; set; }
        public string Manager { get; set; }      
        public Client Customer { get; set; }
        public decimal Budget { get; set; }

        public string Note { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public ICollection<ATask> Tasks { get; set; }

    }
}
