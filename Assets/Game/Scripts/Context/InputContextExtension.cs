using Entitas;
using UnityEngine;

public static partial class InputContextExtension
{
    public static void CreateTouchAtTile(this InputContext inputContext, GameEntity touchEntity) 
    {
        InputEntity entity = inputContext.CreateEntity();
        entity.AddTouch(touchEntity);
    }
    
    public static void CreateStartGameEntity (this InputContext inputContext, string difficulty) {
        var entity = inputContext.CreateEntity();
        entity.AddStartGame(difficulty);
    }

    public static void CreateGameOverEntity (this InputContext inputContext) {
        var entity = inputContext.CreateEntity();
        entity.isGameOver = true;
    }

    public static InputEntity CreateBaseScreenEntity (this InputContext inputContext, IScreenData data) {
        var entity = inputContext.CreateEntity();
        entity.AddUiView(data.Id);
        if (data.IsBlockable)
            entity.isBlockable = true;
        
        return entity;
    }

    public static void CreateShowUiCommandEntity (this InputContext imputContext, string sceneId) {
        var entity = imputContext.CreateEntity();
        entity.AddShowUiCommand(sceneId);
    }

    public static void CreateHideUiCommandEntity (this InputContext imputContext, string sceneId) {
        var entity = imputContext.CreateEntity();
        entity.AddHideUiCommand(sceneId);
    }
}