using ThereGame.Business.Communication.Libraries.Tenses;

namespace ThereGame.Business.Interactor
{
    public class DialogueSettingsDto : IDialogueSettingsDto
    {
        public required string Key { get; set; }
        public required TensesType Tenses { get; set; }
        public required string Text { get; set; }
        public required string Discriptions { get; set; }
        public required string[] WordsToUse { get; set; }
        public  AnswersSettingsDto? AnswersSettingsDto { get; set; }
    }
}