namespace ThereGame.Business.Domain.Teacher.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;
using ThereGame.Business.Domain.Teacher;

public class GetTeacherByIdRequest : IRequest<TeacherModel?>
{
    public Guid Id { get; set; }
}

public class GetTeacherById(IThereGameDataService dataService) : IRequestHandler<GetTeacherByIdRequest, TeacherModel?>
{
    private readonly IThereGameDataService _dataService = dataService;
    
    public async Task<TeacherModel?> Handle(GetTeacherByIdRequest request, CancellationToken cancellationToken)
    {   
        var teacher = _dataService.Teachers.Find(request.Id);
        if (teacher == null) {
            return null;
        }

        return await _dataService.GetFullTeacherById(request.Id, cancellationToken);
    }
}