using ThereGame.Buisness.Communication.Libraries.Tenses;

namespace ThereGame.Buisness.Interactor
{
    public interface IAnswersSettingsDto
    {
        List<TensesType> PossibleAnswersTenses { get; }
        string[] WordsToUse { get; set; }
        IAnswerDto[] Answers { get; }
    }
}