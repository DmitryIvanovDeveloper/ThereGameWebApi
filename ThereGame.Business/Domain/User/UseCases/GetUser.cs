namespace ThereGame.Business.Domain.User.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetUserRequest : IRequest<UserModel?>
{
    public required AuthModel User { get; set; }
}

public class GetUser(IThereGameDataService dataService) : IRequestHandler<GetUserRequest, UserModel?>
{
    private readonly IThereGameDataService _dataService = dataService;
    
    public async Task<UserModel?> Handle(GetUserRequest request, CancellationToken cancellationToken)
    {   
        var user = await _dataService.Users.FirstOrDefaultAsync(
            u => u.Email == request.User.Email,
            cancellationToken
        );
        if (user?.Password != request.User.Password)
        {
            return null;
        }

        return user;
    }
}