public class Meme
{
    public int Id { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public string TopText { get; set; } = string.Empty;
    public string BottomText { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}