namespace ThereGame.Business.Domain.Dialogue.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ThereGame.Business.Domain.Phrase;
using ThereGame.Business.Domain.Answer;

public class GetPhraseByIdRequest : IRequest<AnswerModel?>
{
    public Guid Id { get; set; }
}

public class GetPhraseById(IThereGameDataService dataService) : IRequestHandler<GetPhraseByIdRequest, AnswerModel?>
{
    private readonly IThereGameDataService _dataService = dataService;

    public async Task<AnswerModel?> Handle(GetPhraseByIdRequest request, CancellationToken cancellationToken)
    {
        return await _dataService.Answers
            .Include(d => d.Phrases)
            .ThenInclude(p => p == null ? null : p.ParentAnswer)
            .ThenInclude(a => a == null ? null : a.ParentPhrase)
            .SingleOrDefaultAsync(d => d.Id == request.Id)
        ;
    }
}