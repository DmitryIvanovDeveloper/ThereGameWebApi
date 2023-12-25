public static class UserMapping
{
    public static UserModel Request(AuthSignUpQueryApiDto request) 
    {
        return new UserModel()
        {
            Id = request.Id,
            Name = request.Name,
            LastName = request.LastName,
            Email = request.Email,
            Password = request.Password
        };
    }

    public static UserModel Request(AuthSignInQueryApiDto request) 
    {
        return new UserModel()
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
        };
    }
}