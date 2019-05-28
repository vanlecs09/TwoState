using System;
using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public class ShowHideUiSystem : ReactiveSystem<InputEntity>, IInitializeSystem
{
    private readonly MetaContext _metaContext;
    private readonly InputContext _inputContext;
    private readonly IGroup<InputEntity> _uiScreens;
    private InputEntity _blockSceneRayCastEntity;

    public ShowHideUiSystem (Contexts contexts): base(contexts.input) {
        _metaContext = contexts.meta;
        _inputContext = contexts.input;
        _uiScreens = _inputContext.GetGroup(InputMatcher.UiView);
    }

    public void Initialize()
    {
        _inputContext.ReplaceBlockSceneRayCast(false, false);
        _blockSceneRayCastEntity = _inputContext.blockSceneRayCastEntity;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        var uiManagement = _metaContext.uiManagementService.instance;
        foreach (var e in entities)
        {
            var blockRayCastThisFrame = _blockSceneRayCastEntity.blockSceneRayCast.isInThisFrame;
            if (e.isShowUi) {
                uiManagement.ShowScreen(e.uiView.id);

                // if (e.isBlockable) {
                //     // set block screen raycast
                //     _blockSceneRayCastEntity.blockSceneRayCast.isPermanent = true;
                //     _blockSceneRayCastEntity.ReplaceBlockSceneRayCast(true, blockRayCastThisFrame);
                // }
            } else {
                uiManagement.HideScreen(e.uiView.id);

                // if (e.isBlockable) {
                //     // set block screen raycast
                //     var shouldBlock = false;
                //     foreach (var screen in _uiScreens.GetEntities()) {
                //         if (screen.isShowUi && screen.isBlockable) {
                //             shouldBlock = true;
                //             break;
                //         }
                //     }
                //     _blockSceneRayCastEntity.ReplaceBlockSceneRayCast(shouldBlock, blockRayCastThisFrame);
                // }
            }
        }
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasUiView;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.ShowUi.AddedOrRemoved());
    }
}