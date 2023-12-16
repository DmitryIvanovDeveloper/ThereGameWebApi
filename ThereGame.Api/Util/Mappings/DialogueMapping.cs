namespace ThereGame.Api.Util.Mappings;

using ThereGame.Api.Domain.Dialogue;
using ThereGame.Business.Domain.Answer;
using ThereGame.Business.Domain.Dialogue;
using ThereGame.Business.Domain.Phrase;

public static class DialogueMapping
{
    public static DialogueModel Request(DialogueCreateRequestApiDto dialogueDto)
    {
        return new DialogueModel()
        {
            Id = dialogueDto.Id,
            Name = dialogueDto.Name,
            PhraseId = dialogueDto.Phrase?.Id,
            Phrase = Request(dialogueDto.Phrase)
        };
    }
    
  public static PhraseModel Request(PhraseGetRequestApiDto phraseDto)
    {
        return new PhraseModel()
        {
            Id = phraseDto.Id,
            ParentAnswerId = phraseDto.ParentAnswerId,
            Text = phraseDto.Text,
            Comments = phraseDto.Comments,
            Tenseses = phraseDto.TensesList,
        };
    }
    public static DialogueModel Request(DialogueGetResponseApiDto dialogueDto)
    {
        return new DialogueModel()
        {
            Id = dialogueDto.Id,
            Name = dialogueDto.Name,
            PhraseId = dialogueDto.PhraseId,
        };
    }

    public static PhraseModel Request(PhraseUpdateRequestApiDto phraseDto)
    {
        return new PhraseModel()
        {
            ParentAnswerId = phraseDto.ParentAnswerId,
            Id = phraseDto.Id,
            Text = phraseDto.Text,
            Tenseses = phraseDto.TensesList,
            Comments = phraseDto.Comments
        };
    }

    public static AnswerModel Request(AnswerUpdateRequestApiDto answerDto)
    {
        var answerModel = new AnswerModel()
        {
            ParentPhraseId = answerDto.ParentPhraseId,
            Id = answerDto.Id,
            Text = answerDto.Text,
            Tenseses = answerDto.TensesList,
            WordsToUse = answerDto.WordsToUse,
        };

        foreach (var translate in answerDto.Translates)
        {
            var translateModel = new TranslateModel()
            {
                Text = translate.Text,
                Language = translate.Language,
            };
            answerModel.Translates.Add(translateModel);
        }

        foreach (var mistakeExplanations in answerDto.MistakeExplanations)
        {
            var mistakeExplanationModel = new MistakeExplanationModel()
            {
                Text = mistakeExplanations.Word,
                Explanation = mistakeExplanations.Explanation,
            };
            answerModel.MistakeExplanations.Add(mistakeExplanationModel);
        }

        return answerModel;
    }

    public static AnswerModel Request(AnswerGetResponseApiDto answerDto)
    {
        var answerModel = new AnswerModel()
        {
            ParentPhraseId = answerDto.ParentPhraseId,
            Id = answerDto.Id,
            Text = answerDto.Text,
            Tenseses = answerDto.TensesList,
            WordsToUse = answerDto.WordsToUse,
        };

        foreach (var translate in answerDto.Translates)
        {
            var translateModel = new TranslateModel()
            {
                Text = translate.Text,
                Language = translate.Language,
            };
            answerModel.Translates.Add(translateModel);
        }

        foreach (var mistakeExplanations in answerDto.MistakeExplanations)
        {
            var mistakeExplanationModel = new MistakeExplanationModel()
            {
                Text = mistakeExplanations.Word,
                Explanation = mistakeExplanations.Explanation,
            };
            answerModel.MistakeExplanations.Add(mistakeExplanationModel);
        }

        return answerModel;
    }

    public static AnswerModel Request(AnswerCreateRequestApiDto answerDto)
    {
        var answerModel = new AnswerModel()
        {
            ParentPhraseId = answerDto.ParentPhraseId,
            Id = answerDto.Id,
            Text = answerDto.Text,
            Tenseses = answerDto.TensesList,
            WordsToUse = answerDto.WordsToUse,
        };

        foreach (var translate in answerDto.Translates)
        {
            var translateModel = new TranslateModel()
            {
                Id =  translate.Id,
                Text = translate.Text,
                Language = translate.Language,
            };
            answerModel.Translates.Add(translateModel);
        }

        foreach (var mistakeExplanations in answerDto.MistakeExplanations)
        {
            var mistakeExplanationModel = new MistakeExplanationModel()
            {
                Id = mistakeExplanations.Id,
                Text = mistakeExplanations.Word,
                Explanation = mistakeExplanations.Explanation,
            };
            answerModel.MistakeExplanations.Add(mistakeExplanationModel);
        }

        return answerModel;
    }

    public static PhraseModel Request(PhraseCreateRequestApiDto phraseDto)
    {
        return new PhraseModel()
        {
            Id = phraseDto.Id,
            ParentAnswerId = phraseDto.ParentAnswerId,
            Text = phraseDto.Text,
            Comments = phraseDto.Comments,
            Tenseses = phraseDto.Tenses
        };
    }

    public static AnswerGetResponseApiDto Response(AnswerModel answerDto)
    {
        var responseDto = new AnswerGetResponseApiDto()
        {
            ParentPhraseId = answerDto.ParentPhraseId,
            Id = answerDto.Id,
            Text = answerDto.Text,
            TensesList = answerDto.Tenseses,
            WordsToUse = answerDto.WordsToUse,
        };

        foreach (var translate in answerDto.Translates)
        {
            var translateModel = new TranslateDto()
            {
                Text = translate.Text,
                Language = translate.Language,
            };
            responseDto.Translates.Add(translateModel);
        }

        return responseDto;
    }

    public static PhraseGetResponseApiDto Response(PhraseModel phraseDto)
    {
        return new PhraseGetResponseApiDto()
        {
            ParentAnswerId = phraseDto.ParentAnswerId,
            Id = phraseDto.Id,
            Text = phraseDto.Text,
            TensesList = phraseDto.Tenseses,
            Comments = phraseDto.Comments
        };
    }
}