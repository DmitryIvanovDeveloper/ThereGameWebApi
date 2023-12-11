using ThereGame.Business.Communication.Libraries.Tenses;

namespace ThereGame.Business.Interactor
{
    public interface IAnswersSettingsDto
    {
        List<TensesType> PossibleAnswersTenses { get; }
        string[] WordsToUse { get; set; }
        IAnswerDto[] Answers { get; }
    }
}