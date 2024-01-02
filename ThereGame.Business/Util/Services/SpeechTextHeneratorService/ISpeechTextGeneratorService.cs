public interface ISpeechTextGeneratorService
{
    Task<string> Generate(string audioGenerationSettings, int tryilLimit);
}