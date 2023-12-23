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
            LevelId = dialogueDto.LevelId,
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
            LevelId = dialogueDto.LevelId,
            IsPublished = dialogueDto.IsPublished,
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
            answerModel.Translates.Add(Request(translate));
        }

        foreach (var mistakeExplanations in answerDto.MistakeExplanations)
        {
            answerModel.MistakeExplanations.Add(Request(mistakeExplanations));
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

        foreach (var mistakeExplanation in answerDto.MistakeExplanations)
        {
            var mistakeExplanationModel = new MistakeExplanationModel()
            {
                AnswerParentId = mistakeExplanation.AnswerParentId,
                Id = mistakeExplanation.Id,
                Word = mistakeExplanation.Word,
                Explanation = mistakeExplanation.Explanation,
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

        foreach (var mistakeExplanation in answerDto.MistakeExplanations)
        {
            var mistakeExplanationModel = new MistakeExplanationModel()
            {
                AnswerParentId = mistakeExplanation.AnswerParentId,
                Id = mistakeExplanation.Id,
                Word = mistakeExplanation.Word,
                Explanation = mistakeExplanation.Explanation,
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
            Tenseses = phraseDto.Tenses,
        };
    }

    public static List<DialogueGetResponseApiDto> Response(DialogueModel[] dialogues)
    {
        var response = new List<DialogueGetResponseApiDto>();

        foreach(var dialogue in dialogues)
        {
            response.Add(Response(dialogue));
            foreach (var answer in dialogue.Phrase.Answers)
            {
                Console.WriteLine($"++++++++{answer.Id} = {answer.Phrases.Count()}++++++++");
            }
        }

        foreach (var dialogue in response)
        {
            foreach (var answer in dialogue.Phrase.Answers)
            {
                Console.WriteLine($"========={answer.Id} = {answer.Phrases.Count()}=========");
            }
        }

        return response;
    }

    public static DialogueGetResponseApiDto Response(DialogueModel dialogue)
    {
        return new DialogueGetResponseApiDto()
        {
            Id = dialogue.Id,
            LevelId = dialogue.LevelId,
            PhraseId = dialogue.PhraseId,
            IsPublished = dialogue.IsPublished,
            Name = dialogue.Name,
            Phrase = Response(dialogue.Phrase)
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
            responseDto.Translates.Add(Response(translate));
        }

        foreach (var mistakeExplanations in answerDto.MistakeExplanations)
        {
            responseDto.MistakeExplanations.Add(Response(mistakeExplanations));
        }

        return responseDto;
    }

    public static MistakeExplanationDto Response(MistakeExplanationModel mistakeExplanation)
    {
        return new MistakeExplanationDto()
        {
            AnswerParentId = mistakeExplanation.AnswerParentId,
            Id = mistakeExplanation.Id,
            Word = mistakeExplanation.Word,
            Explanation = mistakeExplanation.Explanation,
        };
    }

    public static MistakeExplanationModel Request(MistakeExplanationDto mistakeExplanation)
    {
        return new MistakeExplanationModel()
        {
            AnswerParentId = mistakeExplanation.AnswerParentId,
            Id = mistakeExplanation.Id,
            Word = mistakeExplanation.Word,
            Explanation = mistakeExplanation.Explanation,
        };
    }

     public static TranslateModel Request(TranslateDto translate)
    {
        return new TranslateModel()
        {
            Id = translate.Id,
            AnswerParentId = translate.AnswerParentId,
            Text = translate.Text,
            Language = translate.Language,
        };
    }

    public static TranslateDto Response(TranslateModel translate)
    {
        return new TranslateDto()
        {
            Id = translate.Id,
            AnswerParentId = translate.AnswerParentId,
            Text = translate.Text,
            Language = translate.Language,
        };
    }

    public static PhraseGetResponseApiDto Response(PhraseModel phraseDto)
    {
        var resposne = new PhraseGetResponseApiDto()
        {
            ParentAnswerId = phraseDto.ParentAnswerId,
            Id = phraseDto.Id,
            Text = phraseDto.Text,
            TensesList = phraseDto.Tenseses,
            Comments = phraseDto.Comments,
        };

        foreach (var answer in phraseDto.Answers)
        {
            resposne.Answers.Add(Response(answer));
        }

        return resposne;
    }
}