namespace ThereGame.Business.Domain.Word.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;
using ThereGame.Business.Domain.Word;
using Microsoft.EntityFrameworkCore;

public class GetWordsByIdRequest : IRequest<List<WordModel>>
{
    public List<Guid> Ids { get; set; } = new List<Guid>();
}

public class GetWordsById(IThereGameDataService dataService) : IRequestHandler<GetWordsByIdRequest, List<WordModel>>
{
    private readonly IThereGameDataService _dataService = dataService;
    
    public async Task<List<WordModel>> Handle(GetWordsByIdRequest request, CancellationToken cancellationToken)
    {   
        return await _dataService.Words
            .Include(w => w.Translates)
            .Where(w => request.Ids.Contains(w.Id))
            .ToListAsync(cancellationToken)
        ;
    }
}