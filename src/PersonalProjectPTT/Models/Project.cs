using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalProjectPTT.Models
{

    public class Project
    {
        //base information
        public int Id { get; set; }

        public string Description { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }


        //project information
        public string Name { get; set; }
        public string Manager { get; set; }      
        public Client Customer { get; set; }
        public decimal Budget { get; set; }
        public string Note { get; set; }

        
        //tasks
        public ICollection<ATask> Tasks { get; set; }

    }
}
