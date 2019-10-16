using capstone_api.Models;

namespace capstone_api.ViewModels
{
    public class DeleteAssignmentResponse
    {
        public string Message { get; set; } = "Successfully deleted assignment";
        public Assign Assign { get; set; }
    }
}