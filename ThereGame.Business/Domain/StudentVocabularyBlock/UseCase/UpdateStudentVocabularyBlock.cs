namespace ThereGame.Business.Domain.StudentDialogueStatistic.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;
using ThereGame.Business.Domain.Student;

public class UpdateStudenVocabularyBlockRequest : IRequest
{
    public required StudentVocabularyBlockModel StudentVocabularyBlock { get; set; }
}

public class UpdateStudenVocabularyBlock(IThereGameDataService dataService) : IRequestHandler<UpdateStudenVocabularyBlockRequest>
{
    private readonly IThereGameDataService _dataService = dataService;
    
    public async Task Handle(UpdateStudenVocabularyBlockRequest request, CancellationToken cancellationToken)
    {
        var studentVocabularyBlock = await _dataService.StudentsVocabularyBlocks.FindAsync(request.StudentVocabularyBlock.Id, cancellationToken);
        if (studentVocabularyBlock == null)
        {
            return; //TODO: Return error about the block doesn't exst
        }

        studentVocabularyBlock.Name = request.StudentVocabularyBlock.Name;
        studentVocabularyBlock.WordsId = request.StudentVocabularyBlock.WordsId;
         
        await _dataService.SaveChanges(cancellationToken);
    }
}