using Microsoft.EntityFrameworkCore;

namespace Quiz.API.Models {
  public class QuizDBContext(DbContextOptions options) : DbContext(options){
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Option> Options { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<QuizAttempt> QuizAttempts { get; set; }
    public DbSet<Answer> Answers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      // Configure User
      modelBuilder.Entity<User>()
        .HasKey(u => u.UserId);

      // Configure Quiz
      modelBuilder.Entity<Quiz>()
        .HasKey(q => q.QuizId);
      modelBuilder.Entity<Quiz>()
        .HasOne(q => q.User)
        .WithMany(u => u.Quizzes)
        .HasForeignKey(q => q.UserId);


      // Configure Options
      modelBuilder.Entity<Option>()
        .HasKey(o => o.OptionId);
      modelBuilder.Entity<Option>()
        .HasOne(o => o.Question)
        .WithMany(q => q.Options)
        .HasForeignKey(o => o.QuestionId);

      // Configure Questions
      modelBuilder.Entity<Question>()
        .HasKey(q => q.QuestionId);
      modelBuilder.Entity<Question>()
        .HasOne(q => q.Quiz)
        .WithMany(qz => qz.Questions)
        .HasForeignKey(q => q.QuizId);

      // Configure QuizAttempt
      modelBuilder.Entity<QuizAttempt>()
        .HasKey(q => q.QuizAttemptId);
      modelBuilder.Entity<QuizAttempt>()
        .HasOne(q => q.User)
        .WithMany(u => u.QuizAttempts)
        .HasForeignKey(q => q.UserId);
      modelBuilder.Entity<QuizAttempt>()
        .HasOne(q => q.Quiz)
        .WithMany(qz => qz.QuizAttempts)
        .HasForeignKey(q => q.QuizId);

      // Configure Answer
      modelBuilder.Entity<Answer>()
        .HasKey(a => a.AnswerId);
      modelBuilder.Entity<Answer>()
        .HasOne(a => a.QuizAttempt)
        .WithMany(q => q.Answers)
        .HasForeignKey(a => a.QuizAttemptId);
      modelBuilder.Entity<Answer>()
        .HasOne(a => a.Option)
        .WithMany(o => o.Answers)
        .HasForeignKey(a => a.OptionId);
      modelBuilder.Entity<Answer>()
        .HasOne(a => a.Question)
        .WithMany(q => q.Answers)
        .HasForeignKey(a => a.QuestionId);
    }
  }
}
