namespace ThereGame.Business.Domain.Student.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;

public class GetStudentByIdRequest : IRequest<StudentModel?>
{
    public Guid Id { get; set; }
}

public class GetStudentById(IThereGameDataService dataService) : IRequestHandler<GetStudentByIdRequest, StudentModel?>
{
    private readonly IThereGameDataService _dataService = dataService;
    
    public async Task<StudentModel?> Handle(GetStudentByIdRequest request, CancellationToken cancellationToken)
    {   
        var student = _dataService.Students.Find(request.Id);
        if (student == null) {
            return null;
        }

        return student;
    }
}