namespace ThereGame.Business.Domain.User.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;

public class GetUserByIdRequest : IRequest<UserModel?>
{
    public Guid Id { get; set; }
}

public class GetUserById(IThereGameDataService dataService) : IRequestHandler<GetUserByIdRequest, UserModel?>
{
    private readonly IThereGameDataService _dataService = dataService;
    
    public async Task<UserModel?> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
    {   
        var teacher = _dataService.Users.Find(request.Id);
        if (teacher == null) {
            return null;
        }

        return await _dataService.GetFullUserById(request.Id, cancellationToken);
    }
}