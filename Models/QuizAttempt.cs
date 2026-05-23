namespace Quiz.API.Models {
  public class QuizAttempt {
    public int QuizAttemptId { get; set; }
    public int UserId { get; set; }
    public required User User { get; set; }
    public int QuizId { get; set; }
    public required Quiz Quiz  { get; set; }
    public DateTime StartedAt { get; set; }
    public DateTime? CompletedAt { get; set; } = DateTime.MinValue;
    public int Score { get; set; }

    public ICollection<Answer> Answers { get; set; } = [];
  }
}
