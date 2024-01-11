namespace ThereGame.Business.Domain.Teacher.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class AuthSignInGetTokenRequest : IRequest<Guid?>
{
    public required AuthModel Auth { get; set; }
}

public class AuthSignIn(IThereGameDataService dataService) : IRequestHandler<AuthSignInGetTokenRequest, Guid?>
{
    private readonly IThereGameDataService _dataService = dataService;
    
    public async Task<Guid?> Handle(AuthSignInGetTokenRequest request, CancellationToken cancellationToken)
    {   
        var teacher = await _dataService.Teachers.FirstOrDefaultAsync(
            u => u.Email == request.Auth.Email,
            cancellationToken
        );
        
        if (teacher != null && teacher?.Password == request.Auth.Password)
        {
            return teacher?.Id;
        }

        var student = await _dataService.Students.FirstOrDefaultAsync(
            u => u.Email == request.Auth.Email,
            cancellationToken
        );

        if (student != null && student?.Password == request.Auth.Password)
        {
            return student?.Id;
        }
        
        return null;
    }
}