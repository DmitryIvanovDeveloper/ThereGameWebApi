namespace ThereGame.Business.Domain.Word.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;
using ThereGame.Business.Domain.Word;
using Microsoft.EntityFrameworkCore;

public class GetWordsRequest : IRequest<List<WordModel>>
{
}

public class GetWords(IThereGameDataService dataService) : IRequestHandler<GetWordsRequest, List<WordModel>>
{
    private readonly IThereGameDataService _dataService = dataService;
    
    public async Task<List<WordModel>> Handle(GetWordsRequest request, CancellationToken cancellationToken)
    {   
        return await _dataService.Words.Include(w => w.Translates).ToListAsync(cancellationToken);
    }
}