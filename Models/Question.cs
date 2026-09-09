namespace Quiz.API.Models {
  public class Question {
    public int QuestionId { get; set; }
    public int? QuizId { get; set; }
    public required Quiz Quiz { get; set; }
    public required string Text { get; set; }
    public string? Subject { get; set; } = string.Empty;
    public string? Type { get; set; } = string.Empty;

    public ICollection<Option> Options { get; set; } = [];
    public ICollection<Answer> Answers { get; set; } = [];
  }
}
