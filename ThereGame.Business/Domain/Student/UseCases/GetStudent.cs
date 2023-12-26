namespace ThereGame.Business.Domain.User.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;
using ThereGame.Business.Domain.Student;
using Microsoft.EntityFrameworkCore;

public class GetStudentRequest : IRequest<StudentModel?>
{
    public required AuthModel Student { get; set; }
}

public class GetStudent(IThereGameDataService dataService) : IRequestHandler<GetStudentRequest, StudentModel?>
{
    private readonly IThereGameDataService _dataService = dataService;
    
    public async Task<StudentModel?> Handle(GetStudentRequest request, CancellationToken cancellationToken)
    {   
        var student = await _dataService.Students.FirstOrDefaultAsync(
            s => s.Email == request.Student.Email
        );
        if (student?.Password != request.Student.Password)
        {
            return null;
        }

        return student;
    }
}