using System.Collections.Generic;
using Entitas;
using Entitas.Unity;

public class GameOverSystem : ReactiveSystem<InputEntity>
{
    private readonly InputContext _inputContext;
    private readonly IGroup<InputEntity> _gameOvers;

    public GameOverSystem (Contexts contexts): base(contexts.input) {
        _inputContext = contexts.input;
        _gameOvers = _inputContext.GetGroup(InputMatcher.GameOver);
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
        return entity.isGameOver;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.GameOver);
    }
    
    public void Cleanup()
    {
        foreach (var e in _gameOvers.GetEntities())
        {
            e.Destroy();
        }
    }

    void ProcessGameOver (InputEntity entity) {
        // Show GameOver Scene
        _inputContext.CreateShowUiCommandEntity("GameOver");
    }
}