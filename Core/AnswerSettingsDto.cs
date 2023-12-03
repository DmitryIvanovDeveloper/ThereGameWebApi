using ThereGame.Buisness.Communication.Libraries.Tenses;

namespace ThereGame.Buisness.Interactor
{
    public class AnswersSettingsDto : IAnswersSettingsDto
    {
        public required List<TensesType> PossibleAnswersTenses { get; set; }
        public required string[] WordsToUse { get; set; }
        public required IAnswerDto[] Answers { get; set; }
    }
}
