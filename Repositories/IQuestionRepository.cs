using Quiz.API.Models;

namespace Quiz.API.Repositories {
  public interface IQuestionRepository {
    Task<IList<Question>> GetAllAsync();
    Task<Question?> GetByIdAsync(int id);
    Task<Question> AddAsync(Question question);
    void UpdateAsync(Question question);
    Task<bool> DeleteAsync(int id);
    bool IsExists(int id);
  }
}
