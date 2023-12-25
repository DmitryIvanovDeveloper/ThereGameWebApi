namespace ThereGame.Business.Domain.User.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;

public class GetUserRequest : IRequest<UserModel>
{
    public AuthModel User { get; set; }
}

public class GetUser(IThereGameDataService dataService) : IRequestHandler<GetUserRequest, UserModel?>
{
    private readonly IThereGameDataService _dataService = dataService;
    
    public async Task<UserModel> Handle(GetUserRequest request, CancellationToken cancellationToken)
    {   
        var user = _dataService.Users.FirstOrDefault(user => user.Email == request.User.Email);
        if (user.Password != request.User.Password)
        {
            return null;
        }

        return user;
    }
}