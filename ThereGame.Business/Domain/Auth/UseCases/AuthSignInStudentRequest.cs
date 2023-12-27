namespace ThereGame.Business.Domain.User.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class AuthSignInStudentRequest : IRequest<Guid?>
{
    public required AuthModel Student { get; set; }
}

public class GetStudent(IThereGameDataService dataService) : IRequestHandler<AuthSignInStudentRequest, Guid?>
{
    private readonly IThereGameDataService _dataService = dataService;
    
    public async Task<Guid?> Handle(AuthSignInStudentRequest request, CancellationToken cancellationToken)
    {   
        var student = await _dataService.Students.FirstOrDefaultAsync(
            s => s.Email == request.Student.Email
        );
        if (student?.Password != request.Student.Password)
        {
            return null;
        }

        return student.Id;
    }
}