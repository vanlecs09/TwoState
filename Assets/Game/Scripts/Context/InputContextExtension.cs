using Entitas;
using UnityEngine;

public static class InputContextExtension
{
    public static void CreateTouchAtTile(this InputContext inputContext, GameEntity touchEntity) 
    {
        InputEntity entity = inputContext.CreateEntity();
        entity.AddTouch(touchEntity);
    }

}