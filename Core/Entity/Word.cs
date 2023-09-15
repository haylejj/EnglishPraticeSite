namespace Core.Entity
{
    public class Word
    {
        public int Id { get; set; }
        public string? EnglishWord { get; set; }
        public string? TurkishWord { get; set; }
        public DateTime CreatedTime { get; set; }
        public Favorite? Favorite { get; set; }
        public Unknows? Unknows { get; set; }
    }
}
