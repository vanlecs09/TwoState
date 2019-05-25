using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class AddViewSystem : ReactiveSystem<GameEntity>, IInitializeSystem
{
    readonly Transform _parent;
    IViewService _viewService;
    readonly Contexts _contexts;

    public AddViewSystem(Contexts contexts) : base(contexts.game)
    {
        var obj = new GameObject("Views");
        // obj.AddComponent<Canvas>();
        // obj.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
        _parent =obj.transform;
        // _parent.gameObject.AddComponent<Canvas>();
        // _parent.gameObject.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
        _contexts = contexts;
    }

    public void Initialize()
    {
        _viewService = _contexts.meta.viewService.instance;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Asset);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasAsset;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            _viewService.LoadAsset(_contexts, e, e.asset.value, _parent);
        }
    }
}
