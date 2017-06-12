using System;

namespace PersonalProjectPTT.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
    }
}