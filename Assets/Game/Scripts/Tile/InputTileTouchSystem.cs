using Entitas;
using System.Collections.Generic;
using UnityEngine;
public class InputTileTouchSystem : ReactiveSystem<InputEntity>, ICleanupSystem
{
    Contexts _contexts;
    InputContext _inputContexts;
    IGroup<InputEntity> _movers;

    public InputTileTouchSystem(Contexts contexts) : base(contexts.input)
    {
        _contexts = contexts;
        _inputContexts = contexts.input;
        _movers = _inputContexts.GetGroup(InputMatcher.AllOf(InputMatcher.Touch));
    }
    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.Touch);
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasTouch;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        Debug.Log("touch");
        foreach (var e in entities)
        {
            var touchEntity = (GameEntity)e.touch.entity;
            Debug.Log("touch " + touchEntity.tilePosition.value);
            _contexts.game.CreateUpdateBoardEntity(touchEntity.tilePosition.value);
            e.Destroy();
            
        }
    }

    public void Cleanup()
    {
    }
}