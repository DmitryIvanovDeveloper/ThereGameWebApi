public static class StudentDialogueStatisticMapping
{
    public static StudentDialogueStatisticModel Request(StudentDialogueStatisticDto studentDialogueStatisticDto)
    {
        return new StudentDialogueStatisticModel() 
        {
            StudentId = studentDialogueStatisticDto.StudentId,
            DialogueId = studentDialogueStatisticDto.DialogueId,
            DialogueHistories = MapDialogueHistoryRequest(studentDialogueStatisticDto.DialogueHistory),
            StartDate = studentDialogueStatisticDto.StartDate,
            EndDate = studentDialogueStatisticDto.EndDate,
        };
         
    }
    private static List<DialogueHistory> MapDialogueHistoryRequest(List<DialogueHistoryDto> dto)
    {
        var dialogueHistories = new List<DialogueHistory>();

        foreach(var historyDto in dto)
        {
            var dialogueHistory = new DialogueHistory()
            {
                Phrase = historyDto.Phrase,
                PhraseId = historyDto.PhraseId,
                Answers = historyDto.Answers
            };

            dialogueHistories.Add(dialogueHistory);
        }

        return dialogueHistories;
    }

    public static List<StudentDialogueStatisticDto> Response(StudentDialogueStatisticModel[] studentDialogueStatisticDto)
    {
        var studentDialoguesStatisticDto = new List<StudentDialogueStatisticDto>();
        
        foreach (var studentDialogueStatiscticDto in studentDialogueStatisticDto)
        {
            var studentDialogueStatisctic = new StudentDialogueStatisticDto() 
            {
                StudentId = studentDialogueStatiscticDto.StudentId,
                DialogueId = studentDialogueStatiscticDto.DialogueId,
                DialogueHistory = MapDialogueHistoryResponse(studentDialogueStatiscticDto.DialogueHistories),
                StartDate = studentDialogueStatiscticDto.StartDate,
                EndDate = studentDialogueStatiscticDto.EndDate,
            };

            studentDialoguesStatisticDto.Add(studentDialogueStatisctic);
        }
        return studentDialoguesStatisticDto;
    }
       private static List<DialogueHistoryDto> MapDialogueHistoryResponse(List<DialogueHistory> dto)
    {
        var dialogueHistories = new List<DialogueHistoryDto>();

        foreach(var historyDto in dto)
        {
            var dialogueHistory = new DialogueHistoryDto()
            {
                Phrase = historyDto.Phrase,
                PhraseId = historyDto.PhraseId,
                Answers = historyDto.Answers
            };

            dialogueHistories.Add(dialogueHistory);
        }

        return dialogueHistories;
    }
}