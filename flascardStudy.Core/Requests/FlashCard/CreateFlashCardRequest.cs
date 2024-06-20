using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace flascardStudy.Core.Requests.FlashCard
{
    public class CreateFlashCardRequest : Request
    {
        [Required]
        [MaxLength(255, ErrorMessage = "Máximo de 255 caracteres")]
        public string Front { get; set; } = string.Empty;

        [Required]
        [MaxLength(500, ErrorMessage = "Máximo de 500 caracteres")]
        public string Back { get; set; } = string.Empty;

        [Required]
        [ForeignKey(nameof(Deck))]
        public int DeckId { get; set; }
    }
}
