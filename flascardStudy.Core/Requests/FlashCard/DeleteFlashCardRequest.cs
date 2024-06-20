using System.ComponentModel.DataAnnotations;

namespace flascardStudy.Core.Requests.FlashCard
{
    public class DeleteFlashCardRequest : Request
    {
        [Required]
        public int Id { get; set; }
    }
}
