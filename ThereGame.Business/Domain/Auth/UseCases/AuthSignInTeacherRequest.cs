namespace ThereGame.Business.Domain.Teacher.UseCases;

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
        var teacher = await _dataService.Teachers.FirstOrDefaultAsync(
            u => u.Email == request.Auth.Email,
            cancellationToken
        );
        if (teacher?.Password != request.Auth.Password)
        {
            return null;
        }

        return teacher.Id;
    }
}