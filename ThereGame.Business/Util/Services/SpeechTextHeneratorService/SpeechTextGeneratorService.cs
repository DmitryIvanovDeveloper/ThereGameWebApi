using System.Text;
public class SpeechTextGeneratorService : ISpeechTextGeneratorService
{
    private string url = "http://50.19.203.25:5000/invoice";

    public async Task<string> Generate(string audioGenerationSettings)
    {
        if (audioGenerationSettings == null)
        {
            return "";
        }

        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(url);
            var content = new StringContent(audioGenerationSettings, Encoding.UTF8, "application/json");
            var result = await client.PostAsync(url, content);
            var status = result.EnsureSuccessStatusCode();

            return await status.Content.ReadAsStringAsync();
        }
    }
}