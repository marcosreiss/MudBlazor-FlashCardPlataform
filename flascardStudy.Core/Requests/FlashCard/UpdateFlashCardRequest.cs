using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace flascardStudy.Core.Requests.FlashCard
{
    public class UpdateFlashCardRequest : Request
    {
        [Required] public int Id { get; set; }

        [Required]
        [MaxLength(255, ErrorMessage = "Máximo de 255 caracteres")]
        public string Front { get; set; } = string.Empty;

        [Required]
        [MaxLength(500, ErrorMessage = "Máximo de 500 caracteres")]
        public string Back { get; set; } = string.Empty;

    }
}
