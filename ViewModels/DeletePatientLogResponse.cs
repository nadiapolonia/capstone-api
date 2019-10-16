using capstone_api.Models;

namespace capstone_api.ViewModels
{
    public class DeletePatientLogResponse
    {
        public string Message { get; set; } = "Successfully deleted patient log";
        public PatientLog PatientLog { get; set; }
    }
}