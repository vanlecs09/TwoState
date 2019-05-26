using System.Collections.Generic;
using Entitas;
using Entitas.Unity;

public class StartGameSystem : ReactiveSystem<InputEntity>, IInitializeSystem
{
    private readonly GameContext _gameContext;
    private readonly MetaContext _metaContext;
    private readonly IGroup<InputEntity> _startGames;
    
    public StartGameSystem (Contexts contexts): base(contexts.input) {
        _gameContext = contexts.game;
        _metaContext = contexts.meta;
        _startGames = contexts.input.GetGroup(InputMatcher.StartGame);
    }

    public void Initialize()
    {
        // create global difficulty entity
        _metaContext.ReplaceGameDifficulty("easy");
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            ProcessStartGame(e);
            return;
        }
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasStartGame;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.StartGame);
    }
    
    public void Cleanup()
    {
        foreach (var e in _startGames.GetEntities())
        {
            e.Destroy();
        }
    }

    void ProcessStartGame (InputEntity entity) {
        string difficulty = entity.startGame.diffculty;

        _metaContext.ChangeGameDifficulty(difficulty);

        // Generate board
        _gameContext.CreateGenerateBoardEntity();
    }
}