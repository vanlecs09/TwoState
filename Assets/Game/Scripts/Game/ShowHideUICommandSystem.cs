using System;
using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public class ShowHideUICommandSystem : ReactiveSystem<InputEntity>, ICleanupSystem
{
    private readonly MetaContext _metaContext;
    private readonly InputContext _inputContext;
    private readonly IGroup<InputEntity> _uiScreens;

    private InputEntity[] _cleanupEntities = null;

    public ShowHideUICommandSystem (Contexts contexts): base(contexts.input) {
        _metaContext = contexts.meta;
        _inputContext = contexts.input;
        _uiScreens = _inputContext.GetGroup(InputMatcher.UiView);
    }

    protected override void Execute(List<InputEntity> entities)
    {
        _cleanupEntities = new InputEntity[entities.Count];
        entities.CopyTo(_cleanupEntities);

        var screens = _uiScreens.GetEntities();

        foreach (var e in entities)
        {
            InputEntity screen = null;

            if (e.hasShowUiCommand) {
                screen = GetUiScreen(screens, e.showUiCommand.screenId);
                if (screen != null) {
                    screen.isShowUi = true;
                } else {
                    var uiManagement = _metaContext.uiManagementService.instance;
                    var data = uiManagement.GetScreenData(e.showUiCommand.screenId);
                    
                    if (data != null) {
                        var entity = _inputContext.CreateBaseScreenEntity(data);
                        entity.isShowUi = true;
                    } else {
                        Debug.LogError("Cannot find data for screen " + e.showUiCommand.screenId);
                    }
                }
            }

            if (e.hasHideUiCommand) {
                screen = GetUiScreen(screens, e.hideUiCommand.screenId);
                if (screen != null) {
                    screen.isShowUi = false;
                }
            }
        }
    }

    private InputEntity GetUiScreen(InputEntity[] screens, string screenId)
    {
        for (var i = 0; i < screens.Length; i++) {
            if (screens[i].hasUiView && screens[i].uiView.id == screenId)
                return screens[i];
        }
        return null;
    }

    protected override bool Filter(InputEntity entity)
    {
        return true;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.AnyOf(InputMatcher.ShowUiCommand, InputMatcher.HideUiCommand));
    }

    public void Cleanup()
    {
        if (_cleanupEntities == null) return;
        
        foreach (var e in _cleanupEntities) {
            e.Destroy();
        }

        _cleanupEntities = null;
    }
}