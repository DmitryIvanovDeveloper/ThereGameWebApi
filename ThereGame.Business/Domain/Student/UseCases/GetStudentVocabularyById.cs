namespace ThereGame.Business.Domain.Student.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;
using ThereGame.Business.Domain.Word;
using Microsoft.EntityFrameworkCore;

public class GetStudentVocabularyByIdRequest : IRequest<List<WordModel>>
{
    public Guid Id { get; set; }
}

public class GetStudentVocabularyById(IThereGameDataService dataService) : IRequestHandler<GetStudentVocabularyByIdRequest, List<WordModel>>
{
    private readonly IThereGameDataService _dataService = dataService;
    
    public async Task<List<WordModel>> Handle(GetStudentVocabularyByIdRequest request, CancellationToken cancellationToken)
    {   
        var student = await _dataService.Students.FindAsync(request.Id);
        if (student == null) {
            return [];
        }

        var words = _dataService.Words
            .Include(w => w.Translates)
            .ToArray();

        var vocalbulary = words.Where(word =>  student.VocabularyIdList.Contains(word.Id)).ToList();
        return vocalbulary;
    }
}