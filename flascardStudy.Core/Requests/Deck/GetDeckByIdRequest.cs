using System.ComponentModel.DataAnnotations;

namespace flascardStudy.Core.Requests.Deck
{
    public class GetDeckByIdRequest : Request
    {
        [Required] public int Id { get; set; }
    }
}
