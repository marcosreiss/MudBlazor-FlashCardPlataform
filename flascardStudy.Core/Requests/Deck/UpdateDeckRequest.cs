using System.ComponentModel.DataAnnotations;

namespace flascardStudy.Core.Requests.Deck
{
    public class UpdateDeckRequest : Request
    {
        [Required] public int Id { get; set; }
        [Required] public string Title { get; set; } = string.Empty;
    }
}
