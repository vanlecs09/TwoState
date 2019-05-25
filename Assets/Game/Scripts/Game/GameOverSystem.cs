using System.Collections.Generic;
using Entitas;
using Entitas.Unity;

public class GameOverSystem : ReactiveSystem<InputEntity>
{
    private readonly IGroup<InputEntity> _gameOvers;
    public GameOverSystem (Contexts contexts): base(contexts.input) {
        _gameOvers = contexts.input.GetGroup(InputMatcher.GameOver);
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            ProcessGameOver(e);
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
        foreach (var e in _gameOvers.GetEntities())
        {
            e.Destroy();
        }
    }

    void ProcessGameOver (InputEntity entity) {
        string difficulty = entity.startGame.diffculty;

        // Generate board

        // Show GameOver Scene
    }
}