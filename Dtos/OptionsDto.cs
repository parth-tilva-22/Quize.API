using Quiz.API.Models;

namespace Quiz.API.Dtos {
  public class OptionsDto {
    public required string Text { get; set; }
    public bool IsCorrect { get; set; }
    public int? QuestionId { get; set; } = 0;
  }
}
