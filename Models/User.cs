using System.ComponentModel.DataAnnotations.Schema;

namespace Quiz.API.Models {
  public class User {
    public int UserId { get; set; }
    [Column(TypeName = "nvarchar(100)")]
    public required string Identifier { get; set; }
    [Column(TypeName = "nvarchar(100)")]
    public required string Name { get; set; }
    [Column(TypeName = "nvarchar(100)")]
    public required string Email { get; set; }
    [Column(TypeName = "nvarchar(100)")]
    public required string Role { get; set; }


    public ICollection<Quiz> Quizzes { get; set; } = [];
    public ICollection<QuizAttempt> QuizAttempts { get; set; } = [];
  }
}
