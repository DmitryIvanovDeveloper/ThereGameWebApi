public static class QuizleGameMapper
{
    public static QuizlGameModel Map(QuizlGameDto dto)
    {
        return new QuizlGameModel()
        {
            Id = dto.Id,
            TeacherId = dto.TeacherId,
            Data = dto.Data,
            HiddenWordId = dto.HiddenWordId,
        };
    }


    public static QuizlGameDto Map(QuizlGameModel quizlGame)
    {
        return new QuizlGameDto()
        {
            Id = quizlGame.Id,
            TeacherId = quizlGame.TeacherId,
            HiddenWordId = quizlGame.HiddenWordId,
            Data = quizlGame.Data
        };

    }
}