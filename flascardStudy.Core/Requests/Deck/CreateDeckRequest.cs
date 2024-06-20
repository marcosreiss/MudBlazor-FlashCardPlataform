using System.ComponentModel.DataAnnotations;

namespace flascardStudy.Core.Requests.Deck
{
    public class CreateDeckRequest : Request
    {
        [Required] public string Title { get; set; } = string.Empty;
    }
}
