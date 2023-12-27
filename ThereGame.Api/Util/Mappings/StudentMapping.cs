using ThereGame.Business.Domain.Student;

public static class StudentMapping
{
    public static StudentGetResponseDto Response(StudentModel student)
    {
        return new StudentGetResponseDto() {
            Id = student.Id,
            Name = student.Name,
            LastName = student.LastName,
            Email = student.Email,
        };
    }
}