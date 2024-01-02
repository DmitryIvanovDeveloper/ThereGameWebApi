namespace ThereGame.Business.Domain.Teacher.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ThereGame.Business.Domain.Teacher;

public class AuthSignUpTeacherRequest : IRequest<Guid?>
{
    public required AuthModel Auth { get; set; }
}

public class CreateTeacher(IThereGameDataService dataService) : IRequestHandler<AuthSignUpTeacherRequest, Guid?>
{
    private readonly IThereGameDataService _dataService = dataService;
    
    public async Task<Guid?> Handle(AuthSignUpTeacherRequest request, CancellationToken cancellationToken)
    {
        var teacher = await _dataService.Teachers.FirstOrDefaultAsync(
            u => u.Email == request.Auth.Email,
            cancellationToken
        );

        if (teacher != null)
        {
            return null;
        }

        var newTeacher = new TeacherModel
        {
            Id = request.Auth.Id,
            Name = request.Auth.Name,
            LastName = request.Auth.LastName,
            Email = request.Auth.Email,
            Password = request.Auth.Password,
        };

        await _dataService.Teachers.AddAsync(newTeacher, cancellationToken);

        await _dataService.SaveChanges(cancellationToken);

        return newTeacher.Id;
    }
}