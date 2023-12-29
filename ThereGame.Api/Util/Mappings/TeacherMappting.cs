namespace ThereGame.Api.Util.Mappings;

using ThereGame.Business.Domain.User;

public static class UserMapping
{
    public static UserGetResponseApiDto Response(UserModel user) 
    {
        var response = new UserGetResponseApiDto
        {
            Id = user.Id,
            Name = user.Name,
            LastName = user.LastName,
            Email = user.Email,
            Dialogues = DialogueMapping.Response(user.Dialogues.ToArray()),
        };

        foreach(var student in user.Students)
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