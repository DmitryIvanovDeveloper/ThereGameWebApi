namespace ThereGame.Business.Domain.AudioSettings.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;

public class GetAudioSettingsRequest : IRequest<byte[]?>
{
    public required Guid Id { get; set; }
}

public class GetAudioSettings(IThereGameDataService dataService) : IRequestHandler<GetAudioSettingsRequest, byte[]?>
{
    private readonly IThereGameDataService _dataService = dataService;
    
  

    public async Task<byte[]?> Handle(GetAudioSettingsRequest request, CancellationToken cancellationToken)
    {
        var audioSettings = await _dataService.AudioSettings.FindAsync(request.Id);
        if (audioSettings == null) 
        {
            return null;
        }


        return Convert.FromBase64String(audioSettings.AudioData);
    }
}