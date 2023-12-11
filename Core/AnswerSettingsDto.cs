using ThereGame.Business.Communication.Libraries.Tenses;

namespace ThereGame.Business.Interactor
{
    public class AnswersSettingsDto : IAnswersSettingsDto
    {
        public required List<TensesType> PossibleAnswersTenses { get; set; }
        public required string[] WordsToUse { get; set; }
        public required IAnswerDto[] Answers { get; set; }
    }
}
