namespace ThereGame.Business.Domain.User.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;

public class CreateUserRequest : IRequest
{
    public UserModel User { get; set; }
}

public class CreateUser(IThereGameDataService dataService) : IRequestHandler<CreateUserRequest>
{
    private readonly IThereGameDataService _dataService = dataService;
    
    public async Task Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        await _dataService.Users.AddAsync(request.User);

        await _dataService.SaveChanges(cancellationToken);
    }
}