namespace ThereGame.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;
using ThereGame.Business.Domain.Dialogue;

public static class DbSetExtensions
{
    public static async Task<DialogueModel?> GetFullDialogueById(
        this DbSet<DialogueModel> dialogues,
        Guid id,
        CancellationToken cancellationToken
    ) {
        return await dialogues
            .Include(d => d.Phrase)
            .ThenInclude(p => p == null ? null : p.ParentAnswer)
            .ThenInclude(a => a == null ? null : a.ParentPhrase)
            .SingleOrDefaultAsync(d => d.Id == id, cancellationToken)
        ;
    }
}