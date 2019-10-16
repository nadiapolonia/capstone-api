using System;

namespace capstone_api.Models
{
    public class Notes
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        public string Title { get; set; }
        public string Description { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}