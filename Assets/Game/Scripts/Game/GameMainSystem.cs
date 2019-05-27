using System.Collections.Generic;
using Entitas;
using Entitas.Unity;

public class GameMainSystem : ReactiveSystem<InputEntity>
{
    private readonly InputContext _inputContext;
    private readonly GameContext _gameContext;
    private readonly IGroup<InputEntity> _gameOvers;

    public GameMainSystem (Contexts contexts): base(contexts.input) {
        _inputContext = contexts.input;
        _gameContext = contexts.game;
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
        _inputContext.CreateShowUiCommandEntity("GameMain");
    }
}