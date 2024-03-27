namespace ThereGame.Business.Domain.StudentDialogueStatistic.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;
using ThereGame.Business.Domain.Student;

public class DeleteStudenVocabularyBlockRequest : IRequest
{
    public Guid Id { get; set; }
}

public class DeleteStudenVocabularyBlock(IThereGameDataService dataService) : IRequestHandler<DeleteStudenVocabularyBlockRequest>
{
    private readonly IThereGameDataService _dataService = dataService;
    
    public async Task Handle(DeleteStudenVocabularyBlockRequest request, CancellationToken cancellationToken)
    {
        var studentVocabularyBlock = await _dataService.StudentsVocabularyBlocks.FindAsync(request.Id);
        if (studentVocabularyBlock == null)
        {
            return;
        }

        dataService.StudentsVocabularyBlocks.Remove(studentVocabularyBlock);

        await _dataService.SaveChanges(cancellationToken);
    }
}