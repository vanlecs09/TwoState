using System.Collections.Generic;
using Entitas;

public class SceneRaycastBlockSystem : ReactiveSystem<InputEntity>
{
    private readonly InputContext _inputContext;
    private InputEntity _sceneRaycastBlocker;

    public SceneRaycastBlockSystem (Contexts contexts): base(contexts.input) {
        _inputContext = contexts.input;
        _sceneRaycastBlocker = _inputContext.sceneRaycastBlockerEntity;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        var oldValue = _sceneRaycastBlocker.sceneRaycastBlocker.value;
        var newValue = oldValue;

        foreach (var e in entities)
        {
            if (
                e.isPointerOverUi 
                || e.isPermanentBlockRaycast
                ) {
                newValue = true;
            } else {
                newValue = false;
            }
        }

        if (newValue != oldValue) {
            _sceneRaycastBlocker.ReplaceSceneRaycastBlocker(newValue);
        }
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasSceneRaycastBlocker;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        // triggers:
        // PointerOverUi.AddedOrRemoved
        return context.CreateCollector(InputMatcher.AnyOf(InputMatcher.PointerOverUi.AddedOrRemoved().matcher));
    }
}