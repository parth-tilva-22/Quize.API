namespace Quiz.API.Models {
  public class Answer {
    public int AnswerID { get; set; }
    public int QuizAttemptId { get; set; }
    public int QuestionId { get; set; }
    public int OptionId { get; set; }
  }
}
