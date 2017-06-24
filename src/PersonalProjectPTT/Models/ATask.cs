using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalProjectPTT.Models
{
    public class ATask
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

        //task information
        public string Title { get; set; }
        public decimal Budget { get; set; }
        public string AssignedEmployee { get; set; }
        public Project LinkedProject { get; set; }


        //comments
        public ICollection<Comment> Comments { get; set; }

    }
}
