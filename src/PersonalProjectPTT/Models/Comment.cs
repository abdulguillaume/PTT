using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalProjectPTT.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string  Author { get; set; }
        //link to Task
        public ATask LinkedTask { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
