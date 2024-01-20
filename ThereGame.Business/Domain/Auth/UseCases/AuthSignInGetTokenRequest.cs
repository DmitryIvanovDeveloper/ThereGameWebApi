namespace ThereGame.Business.Domain.Teacher.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Inspirer.Business.Domain.Common;

public class AuthSignInGetTokenRequest : IRequest<BaseMediatorResponse<ResponsData<Guid>>>
{
    public required AuthModel Auth { get; set; }
}

public class AuthSignIn(IThereGameDataService dataService) : IRequestHandler<AuthSignInGetTokenRequest, BaseMediatorResponse<ResponsData<Guid>>>
{
    private readonly IThereGameDataService _dataService = dataService;
    
    public async Task<BaseMediatorResponse<ResponsData<Guid>>> Handle(AuthSignInGetTokenRequest request, CancellationToken cancellationToken)
    {   
        var teacher = await _dataService.Teachers.FirstOrDefaultAsync(
            u => u.Email == request.Auth.Email,
            cancellationToken
        );

        var student = await _dataService.Students.FirstOrDefaultAsync(
            u => u.Email == request.Auth.Email,
            cancellationToken
        );
        
        if (teacher != null && teacher?.Password != request.Auth.Password ||
            student != null && student?.Password != request.Auth.Password
        )
        {
            return new BaseMediatorResponse<ResponsData<Guid>>(new ResponsData<Guid>(Guid.Empty), MediatorResponseStatuses.SIGN_IN__INVALID_PASSWORD);
        }
        
        if (teacher != null && teacher?.Password == request.Auth.Password)
        {
            return BaseMediatorResponse<ResponsData<Guid>>.Ok(new ResponsData<Guid>(teacher.Id));
        }
        if (student != null && student?.Password == request.Auth.Password)
        {
            return BaseMediatorResponse<ResponsData<Guid>>.Ok(new ResponsData<Guid>(student.Id));
        }
        
        return new BaseMediatorResponse<ResponsData<Guid>>(new ResponsData<Guid>(Guid.Empty), MediatorResponseStatuses.PROFILE__NOT_FOUND);
    }

    
}