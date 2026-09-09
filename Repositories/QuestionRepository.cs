using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Quiz.API.Models;

namespace Quiz.API.Repositories {
  public class QuestionRepository: IQuestionRepository {
    private readonly QuizDBContext _context;
    private readonly IMapper _mapper;

    public QuestionRepository(QuizDBContext quizDBContext, IMapper mapper) {
      _context = quizDBContext;
      _mapper = mapper;
    }

    public async Task<IList<Question>> GetAllAsync() {
      return await _context.Questions
        .Include(q => q.Options)
        .ToListAsync();
    }

    public async Task<Question?> GetByIdAsync(int id) {
      return await _context.Questions
        .Include(q => q.Options)
        .FirstOrDefaultAsync(q => q.QuestionId == id);
    }

    public async Task<Question> AddAsync(Question question) {
      _context.Questions.Add(question);
      await _context.SaveChangesAsync();
      return question;
    }

    //public async Task<Question?> UpdateAsync(Question question) {
    //  var existingQuestion = await _context.Questions.FindAsync(question.QuestionId);
    //  if (existingQuestion == null) {
    //    return null;
    //  }
    //  existingQuestion.Text = question.Text;
    //  existingQuestion.Subject = question.Subject;
    //  existingQuestion.Type = question.Type;
    //  await _context.SaveChangesAsync();
    //  return existingQuestion;
    //}

    public async void UpdateAsync(Question question) {
      _context.Update(question);
      await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(int id) {
      var question = await _context.Questions.FindAsync(id);
      if (question == null) {
        return false;
      }
      _context.Questions.Remove(question);
      await _context.SaveChangesAsync();
      return true;
    }

    public bool IsExists(int id) {
      return _context.Questions.Any(e => e.QuestionId == id);
    }
  }
}
