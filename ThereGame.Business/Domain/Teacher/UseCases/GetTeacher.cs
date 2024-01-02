namespace ThereGame.Business.Domain.Teacher.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ThereGame.Business.Domain.Teacher;

public class GetTeacherRequest : IRequest<TeacherModel?>
{
    public required AuthModel Auth { get; set; }
}

public class GetToken(IThereGameDataService dataService) : IRequestHandler<GetTeacherRequest, TeacherModel?>
{
    private readonly IThereGameDataService _dataService = dataService;
    
    public async Task<TeacherModel?> Handle(GetTeacherRequest request, CancellationToken cancellationToken)
    {   
        var teacher = await _dataService.Teachers.FirstOrDefaultAsync(
            u => u.Email == request.Auth.Email,
            cancellationToken
        );
        if (teacher?.Password != request.Auth.Password)
        {
            return null;
        }

        return teacher;
    }
}