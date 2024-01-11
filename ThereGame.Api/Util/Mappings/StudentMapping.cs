using ThereGame.Api.Util.Mappings;
using ThereGame.Business.Domain.Student;

public static class StudentMapping
{
    public static StudentGetResponseDto Response(StudentModel student)
    {
        return new StudentGetResponseDto() {
            Id = student.Id,
            Avatar = student.Avatar,
            Name = student.Name,
            LastName = student.LastName,
            Email = student.Email,
            CreatedAt = student.CreatedAt
        };
    }
}