namespace Quiz.API.Models {
  public class QuizAttempt {
    public int QuizAttemptId { get; set; }
    public int UserID { get; set; }
    public int QuizID { get; set; }
    public DateTime StartedAt { get; set; }
    public DateTime? CompletedAt { get; set; } = DateTime.MinValue;
    public int Score { get; set; }
  }
}
