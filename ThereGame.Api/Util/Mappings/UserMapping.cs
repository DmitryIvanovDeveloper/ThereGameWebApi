using ThereGame.Api.Util.Mappings;

public static class UserMapping
{
    public static AuthModel Request(AuthSignUpQueryApiDto request) 
    {
        return new AuthModel()
        {
            Id = request.Id,
            Name = request.Name,
            LastName = request.LastName,
            Email = request.Email,
            Password = request.Password
        };
    }

    public static AuthModel Request(AuthSignInQueryApiDto request) 
    {
        return new AuthModel()
        {
            Email = request.Email,
            Password = request.Password
        };
    }

    public static UserGetResponseApiDto Response(UserModel request) 
    {
        return new UserGetResponseApiDto()
        {
            Id = request.Id,
            Name = request.Name,
            LastName = request.LastName,
            Email = request.Email,
            Dialogues = DialogueMapping.Response(request.Dialogues.ToArray())
        };
    }
}