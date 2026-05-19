namespace Quiz.API.Models {
  public class Quiz {
    public int QuizId { get; set; }
    public int UserId { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
  }
}
