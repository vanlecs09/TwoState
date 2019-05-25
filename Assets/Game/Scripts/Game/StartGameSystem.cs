using System.Collections.Generic;
using Entitas;
using Entitas.Unity;

public class StartGameSystem : ReactiveSystem<InputEntity>
{
    private readonly IGroup<InputEntity> _startGames;
    public StartGameSystem (Contexts contexts): base(contexts.input) {
        _startGames = contexts.input.GetGroup(InputMatcher.StartGame);
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

        // Generate board
    }
}