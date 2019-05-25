using System;
using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public class ShowHideUiSystem : ReactiveSystem<InputEntity>
{
    private readonly MetaContext _metaContext;
    private readonly InputContext _inputContext;
    private readonly IGroup<InputEntity> _uiScreens;

    public ShowHideUiSystem (Contexts contexts): base(contexts.input) {
        _metaContext = contexts.meta;
        _inputContext = contexts.input;
        _uiScreens = _inputContext.GetGroup(InputMatcher.UiView);
    }

    protected override void Execute(List<InputEntity> entities)
    {
        var uiManagement = _metaContext.uiManagementService.instance;
        foreach (var e in entities)
        {
            if (e.isShowUi) {
                uiManagement.ShowScreen(e.uiView.id);
                var go = (GameObject)uiManagement.GetUiScreen(e.uiView.id);
                if (go != null)
                    go.Link(e);
                
                if (e.isBlockable) {
                    // set block screen raycast
                    _inputContext.blockSceneRayCastEntity.isBlockSceneRayCast = true;
                }
            } else {
                uiManagement.HideScreen(e.uiView.id);
                var go = (GameObject)uiManagement.GetUiScreen(e.uiView.id);
                if (go != null)
                    go.Link(e);

                if (e.isBlockable) {
                    // set block screen raycast
                    var shouldBlock = false;
                    foreach (var screen in _uiScreens.GetEntities()) {
                        if (screen.isShowUi && screen.isBlockable) {
                            shouldBlock = true;
                            break;
                        }
                    }
                    _inputContext.blockSceneRayCastEntity.isBlockSceneRayCast = shouldBlock;
                }
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