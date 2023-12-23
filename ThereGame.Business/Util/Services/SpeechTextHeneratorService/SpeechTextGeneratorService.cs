using System.Text;
using System.Text.RegularExpressions;

public class SpeechTextGeneratorService : ISpeechTextGeneratorService
{
    private string url = "http://50.19.203.25:5000/invoice";
    private float variability = 0.0f;
    private float clarity = 0.0f;

    public async Task<string> Generate(string text)
    {
        if (text == null)
        {
            return "";
        }

        text = Regex.Replace(text, @"\\(?!n|"")", "");
        text = Regex.Replace(text, "(?<!n)\n", "\\n");
        text = Regex.Replace(text, "(?<!\\\\)\"", "\\\"");

        var body1 = "{\"text\":\"" + $"{text}" + "\",\"model\":\"" + "DeepVoice_Neural" + "\",\"name\":\"" + $"{VoiceOptionsNeuralModel.Amy}" + "\",\"variability\":\"" + "0.0" + "\",\"invoice\":\"" + "IN010102296709" + "\",\"clarity\":\"" + "0.0" + "\"}";
        var body2 = "{\"text\":\"" + $"{text}" + "\",\"model\":\"" + "DeepVoice_Mono" + "\",\"name\":\"" + $"{VoiceOptionsMonoAndMultiModel.Andrew}" + "\",\"invoice\":\"" + "IN010102296709" + "\",\"variability\":\"" + $"{variability}" + "\",\"clarity\":\"" + $"{clarity}" + "\"}";
        var body3 = "{\"text\":\"" + $"{text}" + "\",\"model\":\"" + "DeepVoice_Multi" + "\",\"name\":\"" + $"{VoiceOptionsMonoAndMultiModel.Andrew}" + "\",\"invoice\":\"" + "IN010102296709" + "\",\"variability\":\"" + $"{variability}" + "\",\"clarity\":\"" + $"{clarity}" + "\"}";
        var body4 =  "{\"text\":\"" + $"{text}" + "\",\"model\":\"" + "DeepVoice_Standard" + "\",\"name\":\"" + $"{VoiceOptionsStandartModel.Aditi}" + "\",\"invoice\":\"" + "IN010102296709" + "\",\"variability\":\"" + "0.0" + "\",\"clarity\":\"" + "0.0" + "\"}";
           
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(url);
            var content = new StringContent(body4, Encoding.UTF8, "application/json");
            var result = await client.PostAsync(url, content);
            var status = result.EnsureSuccessStatusCode();

            return await status.Content.ReadAsStringAsync();
        }
    }
}