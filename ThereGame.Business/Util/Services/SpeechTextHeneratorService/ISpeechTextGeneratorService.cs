public interface ISpeechTextGeneratorService
{
    Task<string> Generate(string text);
}