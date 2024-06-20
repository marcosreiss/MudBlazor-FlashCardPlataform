using System.Text.Json.Serialization;

namespace flascardStudy.Core.Models
{
    public class FlashCardModel
    {
        public int Id { get; set; }
        public string Front { get; set; } = null!;
        public string Back { get; set; } = null!;
        public int DeckId { get; set; }

        [JsonIgnore]
        public DeckModel Deck { get; set; }
    }
}