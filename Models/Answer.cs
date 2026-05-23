namespace Quiz.API.Models {
  public class Answer {
    public int AnswerId { get; set; }
    public int QuizAttemptId { get; set; }
    public required QuizAttempt QuizAttempt { get; set; }
    public int QuestionId { get; set; }
    public required Question Question { get; set; }
    public int OptionId { get; set; }
    public required Option Option { get; set; }
  }
}
