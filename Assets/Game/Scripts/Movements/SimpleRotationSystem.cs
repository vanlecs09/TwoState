using Entitas;
using UnityEngine;

public class SimpleRotationSystem : IExecuteSystem
{
    readonly GameContext _gameContext;
    readonly MetaContext _metaContext;
    readonly Contexts _contexts;
    IGroup<GameEntity> _movers;
    float delaTime;
    public SimpleRotationSystem(Contexts contexts) //: base(contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Rotation)))
    {
        _gameContext = contexts.game;
        _metaContext = contexts.meta;
        _contexts = contexts;
        _movers = _gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.Rotation));
    }

    public  void Execute()
    {
        delaTime = _metaContext.timeService.instance.GetDeltaTime();
        foreach (GameEntity e in _movers)
        {
            var rotation = e.rotation.value;
            rotation.y += delaTime  * 100;
            e.ReplaceRotation(rotation);
        }
    }
}