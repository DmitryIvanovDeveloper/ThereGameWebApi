namespace ThereGame.Business.Domain.Dialogue.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ThereGame.Business.Domain.Answer;

public class GetAnswerByIdRequest : IRequest<AnswerModel?>
{
    public Guid Id { get; set; }
}

public class GetAnswer(IThereGameDataService dataService) : IRequestHandler<GetAnswerByIdRequest, AnswerModel?>
{
    private readonly IThereGameDataService _dataService = dataService;

    public async Task<AnswerModel?> Handle(GetAnswerByIdRequest request, CancellationToken cancellationToken)
    {
        return await _dataService.Answers
            .SingleOrDefaultAsync(d => d.Id == request.Id)
        ;
    }
}