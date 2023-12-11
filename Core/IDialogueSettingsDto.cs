using ThereGame.Business.Communication.Libraries.Tenses;
using ThereGame.Business.Interactor;

public interface IDialogueSettingsDto
    {
        string Key { get; }
        TensesType Tenses { get; }
        string Text { get; }
        string Discriptions { get; }
        string[] WordsToUse { get; }
        AnswersSettingsDto? AnswersSettingsDto { get; }
    }