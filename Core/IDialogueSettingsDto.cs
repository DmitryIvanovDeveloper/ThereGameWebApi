using ThereGame.Buisness.Communication.Libraries.Tenses;
using ThereGame.Buisness.Interactor;

public interface IDialogueSettingsDto
    {
        string Key { get; }
        TensesType Tenses { get; }
        string Text { get; }
        string Discriptions { get; }
        string[] WordsToUse { get; }
        AnswersSettingsDto? AnswersSettingsDto { get; }
    }