using System.ComponentModel.DataAnnotations;

namespace flascardStudy.Core.Requests.Deck
{
    public class DeleteDeckRequest : Request
    {
        [Required] public int Id { get; set; }
    }
}