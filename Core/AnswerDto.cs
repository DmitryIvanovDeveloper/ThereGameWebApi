using ThereGame.Business.Communication.Dialogue;


namespace ThereGame.Business.Interactor
{
    public class AnswerDto : IAnswerDto
    {
        public required string Text { get; set; }
        public required Translate[] Translates { get; set; }
        public required Explanation[] MistakeExplanations { get; set; }
        public required int Points { get; set; }
        public DialogueSettingsDto? DialogueSettingsDto { get; set; }
    }
}
