namespace flascardStudy.Core.Models
{
    public class DeckModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public List<FlashCardModel>? Cards { get; set; }
    }
}