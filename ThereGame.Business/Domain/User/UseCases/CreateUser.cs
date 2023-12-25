namespace ThereGame.Business.Domain.User.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;

public class CreateUserRequest : IRequest
{
    public AuthModel Auth { get; set; }
}

public class CreateUser(IThereGameDataService dataService) : IRequestHandler<CreateUserRequest>
{
    private readonly IThereGameDataService _dataService = dataService;
    
    public async Task Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var user = _dataService.Users.FirstOrDefault(user => user.Email == request.Auth.Email);
        if (user != null)
        {
            return;
        }

        var newUser = new UserModel()
        {
            Name = request.Auth.Name,
            LastName = request.Auth.LastName,
            Email = request.Auth.Email,
            Password = request.Auth.Password,
            Id = request.Auth.Id,
        };

        await _dataService.Users.AddAsync(newUser);

        await _dataService.SaveChanges(cancellationToken);
    }
}