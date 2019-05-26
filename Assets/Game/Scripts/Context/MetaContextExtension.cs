public static partial class InputContextExtension
{
    public static void ChangeGameDifficulty (this MetaContext metaContext, string difficulty) 
    {
        metaContext.gameDifficultyEntity.ReplaceGameDifficulty(difficulty);
    }
}