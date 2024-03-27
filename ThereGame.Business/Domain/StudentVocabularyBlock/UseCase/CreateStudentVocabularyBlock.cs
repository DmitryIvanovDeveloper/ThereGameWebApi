namespace ThereGame.Business.Domain.StudentDialogueStatistic.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;
using ThereGame.Business.Domain.Student;

public class CreateStudenVocabularyBlockRequest : IRequest
{
    public required StudentVocabularyBlockModel StudentVocabularyBlock { get; set; }
}

public class CreateStudenVocabularyBlock(IThereGameDataService dataService) : IRequestHandler<CreateStudenVocabularyBlockRequest>
{
    private readonly IThereGameDataService _dataService = dataService;

    public async Task Handle(CreateStudenVocabularyBlockRequest request, CancellationToken cancellationToken)
    {
        var studentVocabularyBlock = await _dataService.StudentsVocabularyBlocks.FindAsync(request.StudentVocabularyBlock.Id, cancellationToken);
        if (studentVocabularyBlock != null)
        {
            return; //TODO: Return error about the block already exist
        }

        await _dataService.StudentsVocabularyBlocks.AddAsync(request.StudentVocabularyBlock);
        await _dataService.SaveChanges(cancellationToken);
    }
}