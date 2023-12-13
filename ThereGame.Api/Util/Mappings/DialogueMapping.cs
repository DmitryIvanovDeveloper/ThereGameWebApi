using ThereGame.Business.Domain.Answer;
using ThereGame.Business.Domain.Dialogue;
using ThereGame.Business.Domain.Phrase;

public static class DialogueMapping 
{
    public static DialogueModel MapDtoToModel(DialogueDto dialogueDto) {
        return new DialogueModel(){
            Id = dialogueDto.Id,
            Name = dialogueDto.Name,
            PhraseId = dialogueDto.Phrase.Id,
        };
    }

    public static PhraseModel MapDtoToModel(PhraseDto phraseDto) {
        return new PhraseModel() {
            ParentAnswerId = phraseDto.ParentAnswerId,
            Id =  phraseDto.Id,
            Text = phraseDto.Text,
            Tenses = phraseDto.TensesList,
        };
    }

    public static AnswerModel MapDtoToModel(AnswerDto answerDto) {
        var answerModel = new AnswerModel() {
            ParentPhraseId = answerDto.ParentPhraseId,
            Id = answerDto.Id,
            Tenses = answerDto.TensesList,
            WordsToUse = answerDto.WordsToUse,
        };

        foreach(var translate in answerDto.Translates) {
            var translateModel = new TranslateModel() {
                Text = translate.Text,
                Language = translate.Language,
            };
            answerModel.Translates.Add(translateModel);
        }

        return answerModel;
    }
}