using ThereGame.Buisness.Communication.Dialogue;

namespace ThereGame.Buisness.Interactor
{
    public interface IAnswerDto
    {
        string Text { get; }
        Translate[] Translates { get; }
        Explanation[] MistakeExplanations { get; }
        int Points { get; }
        DialogueSettingsDto? DialogueSettingsDto { get; }
    }
}

