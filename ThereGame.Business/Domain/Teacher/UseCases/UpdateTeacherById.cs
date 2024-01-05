namespace ThereGame.Business.Domain.Teacher.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;
using ThereGame.Business.Domain.Teacher;

public class UpdateTeacherByIdRequest : IRequest
{
    public required string Avatar { get; set; }
    public required string LastName { get; set; }
    public required string Name { get; set; }
    public required Guid Id { get; set; }
}

public class UpdateTeacherById(IThereGameDataService dataService) : IRequestHandler<UpdateTeacherByIdRequest>
{
    private readonly IThereGameDataService _dataService = dataService;
    
    public async Task Handle(UpdateTeacherByIdRequest request, CancellationToken cancellationToken)
    {   
        var teacher = _dataService.Teachers.FirstOrDefault(teacher => teacher.Id ==request.Id);
        if (teacher == null) {
            return;
        }
        
        teacher.Id = teacher.Id;
        teacher.Avatar  = request.Avatar;
        teacher.Name = request.Name;
        teacher.LastName = request.LastName;
        teacher.Email = teacher.Email;
        teacher.Password = teacher.Password;

        await _dataService.SaveChanges(cancellationToken);
    }
}