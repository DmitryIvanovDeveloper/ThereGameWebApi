namespace ThereGame.Business.Domain.Student.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetStudenVocabularyBlockByIdRequest : IRequest<List<StudentVocabularyBlockModel>>
{
    public Guid Id { get; set; }
}

public class GetStudenVocabularyBlockById(IThereGameDataService dataService) : IRequestHandler<GetStudenVocabularyBlockByIdRequest, List<StudentVocabularyBlockModel>>
{
    private readonly IThereGameDataService _dataService = dataService;
    
    public async Task<List<StudentVocabularyBlockModel>> Handle(GetStudenVocabularyBlockByIdRequest request, CancellationToken cancellationToken)
    {   
        var student = await _dataService.Students.FindAsync(request.Id);
        if (student == null) {
            return [];
        }

        return _dataService.StudentsVocabularyBlocks
            .Include(sv => sv.QuizlGameStatistics)
            .Include(sv => sv.TranslateWordsGameStatistics)
            .Where(vb => vb.StudentId == request.Id)
            .ToList()
        ;
    }
}