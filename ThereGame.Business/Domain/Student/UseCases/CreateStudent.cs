namespace ThereGame.Business.Domain.Teacher.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;
using ThereGame.Business.Domain.Student;
using Microsoft.EntityFrameworkCore;

public class CreateStudentRequest : IRequest<Guid?>
{
    public required AuthModel Auth { get; set; }
}

public class CreateStudent(IThereGameDataService dataService) : IRequestHandler<CreateStudentRequest, Guid?>
{
    private readonly IThereGameDataService _dataService = dataService;
    
    public async Task<Guid?> Handle(CreateStudentRequest request, CancellationToken cancellationToken)
    {
        var student = await _dataService.Students.FirstOrDefaultAsync(
            u => u.Email == request.Auth.Email,
            cancellationToken
        );
        if (student != null)
        {
            return null;
        }

        var newStudent = new StudentModel
        {
            Id = request.Auth.Id,
            TeacherId = request.Auth.TeacherId,
            Name = request.Auth.Name,
            LastName = request.Auth.LastName,
            Email = request.Auth.Email,
            Password = request.Auth.Password,
            CreatedAt = DateTime.UtcNow
        };

        await _dataService.Students.AddAsync(newStudent, cancellationToken);

        await _dataService.SaveChanges(cancellationToken);

        return request.Auth.Id;
    }
}