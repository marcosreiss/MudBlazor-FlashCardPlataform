using System.ComponentModel.DataAnnotations;

namespace flascardStudy.Core.Requests.FlashCard
{
    public class GetFlashCardByIdRequest : Request
    {
        [Required] public int Id { get; set; }
    }
}
