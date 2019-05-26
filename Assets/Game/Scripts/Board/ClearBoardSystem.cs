using System.Collections.Generic;
using Entitas;

public class ClearBoardSystem : ReactiveSystem<GameEntity>
{
    Contexts _contexts;
    GameContext _gameContext;
    IGroup<GameEntity> _movers;
    public ClearBoardSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
        _gameContext = contexts.game;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            _movers = _gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.Tile));
            foreach (var tile in _movers)
            {
                tile.isDestroyed = true;
            }
            e.Destroy();
        }
    }

    protected override bool Filter(GameEntity entity)
    {

        return entity.isClearBoard;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.ClearBoard);
    }
}