
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Quiz.API.Mapping;
using Quiz.API.Models;
using Quiz.API.Repositories;

namespace Quiz.API {
  public class Program {
    public static void Main(string[] args) {
      var builder = WebApplication.CreateBuilder(args);

      // Add services to the container.
      builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());
      builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();


      builder.Services.AddControllers();
      builder.Services.AddDbContext<QuizDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
      // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
      builder.Services.AddEndpointsApiExplorer();
      builder.Services.AddSwaggerGen();

      var app = builder.Build();

      // Configure the HTTP request pipeline.
      if (app.Environment.IsDevelopment()) {
        app.UseSwagger();
        app.UseSwaggerUI();
      }

      app.UseHttpsRedirection();

      app.UseAuthorization();


      app.MapControllers();

      app.Run();
    }
  }
}
