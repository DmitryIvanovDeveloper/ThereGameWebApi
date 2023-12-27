namespace ThereGame.Business.Domain.User.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class AuthSignInTeacherRequest : IRequest<Guid?>
{
    public required AuthModel Auth { get; set; }
}

public class AuthSignInTeacher(IThereGameDataService dataService) : IRequestHandler<AuthSignInTeacherRequest, Guid?>
{
    private readonly IThereGameDataService _dataService = dataService;
    
    public async Task<Guid?> Handle(AuthSignInTeacherRequest request, CancellationToken cancellationToken)
    {   
        var user = await _dataService.Users.FirstOrDefaultAsync(
            u => u.Email == request.Auth.Email,
            cancellationToken
        );
        if (user?.Password != request.Auth.Password)
        {
            return null;
        }

        return user.Id;
    }
}