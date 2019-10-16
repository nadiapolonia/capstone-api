using System.Collections.Generic;

namespace capstone_api.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Schedule { get; set; }
        public string Diagnoses { get; set; }
        public List<Assign> Assignments { get; set; } = new List<Assign>();
        public List<Notes> Note { get; set; } = new List<Notes>();
        public List<PatientLog> PatientLogs { get; set; } = new List<PatientLog>();
        public List<PatientEmergencyLog> PatientEmergencyLogs { get; set; } = new List<PatientEmergencyLog>();


    }
}