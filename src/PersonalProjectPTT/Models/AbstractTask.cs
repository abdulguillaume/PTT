using System;

namespace PersonalProjectPTT.Models
{
    public abstract class AbstractTask
    {
        public int Id { get; set; }       
        public string Description { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? StartReal { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? EndReal { get; set; }
        
    }
}