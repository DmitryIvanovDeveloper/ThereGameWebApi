
using ThereGame.Buisness.Communication.Dialogue;
using ThereGame.Buisness.Communication.Libraries.Tenses;
using ThereGame.Buisness.Interactor;


public class BDService : IBDService
{
    public DialogueSettingsDto GetDialogues()
    {
        var answersSettings = new AnswersSettingsDto()
        {
            PossibleAnswersTenses = new List<TensesType>()
            {
                TensesType.PresentSimple,
                TensesType.PresentCountinious
            },
            WordsToUse = new string[]
            {
                "Hiy",
            },
            Answers = new[]
            {
                new AnswerDto()
                {
                    Text = "Hello",
                    Translates = new[]
                    {
                        new Translate()
                        {
                            Language = Language.Russian,
                            TranslateText = "Здорово",
                        },
                    },
                    MistakeExplanations = new []
                    {
                        new Explanation()
                        {
                            WordExplanition = "Hi",
                            TranslatesExplanation = new []
                            {
                                new Translate()
                                {
                                    TranslateText = "Не ругайся",
                                    Language = Language.Russian,
                                }
                            }

                        }
                    },
                    Points = '4',
                    DialogueSettingsDto = new DialogueSettingsDto()
                    {
                        Key = "1eff",
                        Tenses = TensesType.PresentSimple,
                        Text = "Idi Nahui",
                        Discriptions = "Some Discriptions",
                        WordsToUse = new string[]
                        {
                            "Pidr",
                        },
                    },
                },
            },
        };

        var dialogueSettingsDto = new DialogueSettingsDto()
        {
            Key = "1eff",
            Tenses = TensesType.PresentSimple,
            Text = "Hello John",
            Discriptions = "Some Discriptions",
            WordsToUse = new string[]
            {
                "Hiy",
            },
            AnswersSettingsDto = answersSettings
        };

        return dialogueSettingsDto;
    }
}