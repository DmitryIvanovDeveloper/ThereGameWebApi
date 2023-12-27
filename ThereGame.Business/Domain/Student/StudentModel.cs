namespace ThereGame.Business.Domain.Student;

using ThereGame.Business.Domain.User;


public class StudentModel 
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";

    public Guid? TeacherId { get; set; } = null;
    public UserModel? Teacher { get; set; } = null;
}