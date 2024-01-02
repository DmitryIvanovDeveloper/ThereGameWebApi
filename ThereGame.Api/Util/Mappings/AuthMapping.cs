namespace ThereGame.Api.Util.Mappings;

using ThereGame.Business.Domain.Teacher;

public static class AuthMapping
{
    public static AuthModel Request(AuthSignUpQueryApiDto request) 
    {
        return new AuthModel
        {
            Id = request.Id,
            TeacherId = request.TeacherId,
            Name = request.Name,
            LastName = request.LastName,
            Email = request.Email,
            Password = request.Password,
        };
    }

    public static AuthModel Request(AuthSignInQueryApiDto request) 
    {
        return new AuthModel
        {
            Email = request.Email,
            Password = request.Password
        };
    }

    public static TeacherGetResponseApiDto Response(TeacherModel request) 
    {
        return new TeacherGetResponseApiDto
        {
            Id = request.Id,
            Name = request.Name,
            LastName = request.LastName,
            Email = request.Email,
            Dialogues = DialogueMapping.Response(request.Dialogues.ToArray())
        };
    }
}