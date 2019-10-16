using System;

namespace capstone_api.Models
{
    public class Assign
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        public string Title { get; set; }
        public string Task { get; set; }
        public string Resources { get; set; }
        public bool Read { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }


    }
}