namespace Core.Entity
{
    public class Unknows
    {
        public int Id { get; set; }
        public string? EnglishWord { get; set; }
        public string? TurkishWord { get; set; }
        public DateTime CreatedTime { get; set; }
        public int WordId { get; set; }
        public Word? Word { get; set; }
    }
}
