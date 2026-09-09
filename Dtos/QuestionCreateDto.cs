namespace Quiz.API.Dtos {
  public class QuestionCreateDto {
    public int QuestionId { get; set; }
    public required string Text { get; set; }
    public required string Subject { get; set; }
    public List<OptionsDto> Options { get; set; } = [];
  }
}
