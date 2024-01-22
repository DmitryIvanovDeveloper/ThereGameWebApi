namespace ThereGame.Business.Domain.Teacher.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Inspirer.Business.Domain.Common;
using static ThereGame.Business.Domain.Teacher.UseCases.AuthSignIn;

public class AuthSignInGetTokenRequest : IRequest<BaseMediatorResponse<ResponsData<UserAuthInfo>>>
{
    public required AuthModel Auth { get; set; }
}

public class AuthSignIn(IThereGameDataService dataService) : IRequestHandler<AuthSignInGetTokenRequest, BaseMediatorResponse<ResponsData<UserAuthInfo>>>
{
    private readonly IThereGameDataService _dataService = dataService;
    
    public async Task<BaseMediatorResponse<ResponsData<UserAuthInfo>>> Handle(AuthSignInGetTokenRequest request, CancellationToken cancellationToken)
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
            return new BaseMediatorResponse<ResponsData<UserAuthInfo>>(new ResponsData<UserAuthInfo>(null), MediatorResponseStatuses.SIGN_IN__INVALID_PASSWORD);
        }
        
        if (teacher != null && teacher?.Password == request.Auth.Password)
        {
            var userAuthInfo = new UserAuthInfo()
            {
                Role = Role.Teacher,
                Token = teacher.Id
            };
            return BaseMediatorResponse<ResponsData<UserAuthInfo>>.Ok(new ResponsData<UserAuthInfo>(userAuthInfo));
        }
        if (student != null && student?.Password == request.Auth.Password)
        {
            var userAuthInfo = new UserAuthInfo()
            {
                Role = Role.Student,
                Token = student.Id
            };
            return BaseMediatorResponse<ResponsData<UserAuthInfo>>.Ok(new ResponsData<UserAuthInfo>(userAuthInfo));
        }
        
        return new BaseMediatorResponse<ResponsData<UserAuthInfo>>(new ResponsData<UserAuthInfo>(null), MediatorResponseStatuses.PROFILE__NOT_FOUND);
    }

    public class UserAuthInfo
    {
        public Role Role { get; set; } 
        public Guid Token { get; set; }
    }

    public enum Role
    {
        Teacher = 0,
        Student = 1
    }
}