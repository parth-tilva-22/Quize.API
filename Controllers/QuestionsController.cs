using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quiz.API.Dtos;
using Quiz.API.Models;
using Quiz.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.API.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class QuestionsController : ControllerBase {
    private readonly QuizDBContext _context;
    private readonly IQuestionRepository _repository;
    private readonly IMapper _mapper;

    public QuestionsController(QuizDBContext context, IQuestionRepository questionRepository, IMapper mapper) {
      _context = context;
      _repository = questionRepository;
      _mapper = mapper;
    }

    // GET: api/Questions
    [HttpGet]
    public async Task<ActionResult<IList<QuestionCreateDto>>> GetQuestions() {
      var questions = await _repository.GetAllAsync();
      return Ok(_mapper.Map<IList<QuestionCreateDto>>(questions));
    }

    // GET: api/Questions/5
    [HttpGet("{id}")]
    public async Task<ActionResult<QuestionCreateDto>> GetQuestion(int id) {
      var question = await _repository.GetByIdAsync(id);

      if (question == null) {
        return NotFound();
      }

      return Ok(_mapper.Map<QuestionCreateDto>(question));
    }

    // PUT: api/Questions/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutQuestion(int id, QuestionCreateDto questionDto) {
      if (id != questionDto.QuestionId) {
        return BadRequest();
      }
      var question = await _repository.GetByIdAsync(id);
      _mapper.Map(questionDto, question);

      _context.Entry(question).State = EntityState.Modified;

      try {
        await _context.SaveChangesAsync();
      } catch (DbUpdateConcurrencyException) {
        if (!_repository.IsExists(id)) {
          return NotFound();
        } else {
          throw;
        }
      }

      return NoContent();
    }

    // POST: api/Questions
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<QuestionCreateDto>> PostQuestion(QuestionCreateDto questionDto) {
      var question = _mapper.Map<Question>(questionDto);
      await _repository.AddAsync(question);

      return CreatedAtAction("GetQuestion", new { id = question.QuestionId }, _mapper.Map<QuestionCreateDto>(question));
    }

    // DELETE: api/Questions/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteQuestion(int id) {
      var result = await _repository.DeleteAsync(id);
      if (!result) {
        return NotFound();
      }

      return NoContent();
    }
  }
}
