using capstone_api.Models;

namespace capstone_api.ViewModels
{
    public class DeletePatientResponse
    {
        public string Message { get; set; } = "Successfully deleted patient";
        public Patient Patient { get; set; }
    }
}