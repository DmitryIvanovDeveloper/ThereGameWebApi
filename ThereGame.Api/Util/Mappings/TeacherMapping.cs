namespace ThereGame.Api.Util.Mappings;

using ThereGame.Business.Domain.Teacher;

public static class TeacherMapping
{
    public static TeacherGetResponseApiDto Response(TeacherModel teacher) 
    {
        var response = new TeacherGetResponseApiDto
        {
            Id = teacher.Id,
            Name = teacher.Name,
            LastName = teacher.LastName,
            Email = teacher.Email,
            Dialogues = DialogueMapping.Response(teacher.Dialogues.ToArray()),
        };

        foreach(var student in teacher.Students)
        {
            var studentGetResponseDto = new StudentGetResponseDto()
            {
                Id = student.Id,
                Name = student.Name,
                LastName = student.LastName,
                Email = student.Email,
            };

            response.Students.Add(studentGetResponseDto);
        }

        return response;
    }
}