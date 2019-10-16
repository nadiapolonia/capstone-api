using capstone_api.Models;

namespace capstone_api.ViewModels
{
    public class DeleteNoteResponse
    {
        public string Message { get; set; } = "Successfully deleted note";
        public Notes Notes { get; set; }
    }
}