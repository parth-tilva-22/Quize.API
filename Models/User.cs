namespace Quiz.API.Models {
  public class User {
    public int UserId { get; set; }
    public required string Identifer { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Role { get; set; }
  }
}
