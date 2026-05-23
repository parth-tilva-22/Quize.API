namespace Quiz.API.Models {
  public class Option {
    public int OptionId { get; set; }
    public int? QuestionId { get; set; }
    public Question? Question { get; set; }
    public required string Text { get; set; }
    public bool IsCorrect { get; set; }

    public ICollection<Answer> Answers { get; set; } = [];
  }
}
