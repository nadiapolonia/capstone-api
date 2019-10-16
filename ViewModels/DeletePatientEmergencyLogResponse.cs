using capstone_api.Models;

namespace capstone_api.ViewModels
{
    public class DeletePatientEmergencyLogResponse
    {

        public string Message { get; set; } = "Successfully deleted emergency patient log";
        public PatientEmergencyLog PatientEmergencyLog { get; set; }
    }
}