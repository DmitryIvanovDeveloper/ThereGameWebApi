namespace ThereGame.Business.Domain.User.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class AuthSignUpTeacherRequest : IRequest<Guid?>
{
    public required AuthModel Auth { get; set; }
}

public class CreateUser(IThereGameDataService dataService) : IRequestHandler<AuthSignUpTeacherRequest, Guid?>
{
    private readonly IThereGameDataService _dataService = dataService;
    
    public async Task<Guid?> Handle(AuthSignUpTeacherRequest request, CancellationToken cancellationToken)
    {
        var user = await _dataService.Users.FirstOrDefaultAsync(
            u => u.Email == request.Auth.Email,
            cancellationToken
        );

        if (user != null)
        {
            return null;
        }

        var newUser = new UserModel
        {
            Id = request.Auth.Id,
            Name = request.Auth.Name,
            LastName = request.Auth.LastName,
            Email = request.Auth.Email,
            Password = request.Auth.Password,
        };

        await _dataService.Users.AddAsync(newUser, cancellationToken);

        await _dataService.SaveChanges(cancellationToken);

        return newUser.Id;
    }
}