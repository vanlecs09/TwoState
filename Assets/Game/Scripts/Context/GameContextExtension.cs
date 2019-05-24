using Entitas;
using UnityEngine;

public static class GameContextEntesion
{
    public static void CreateGenerateBoardEntity(this GameContext gameContext) 
    {
        var entity = gameContext.CreateEntity();
        entity.isGenerateBoard = true;
    }
    public static void CreateSimpleMovingEntity(this GameContext gameContext)
    {
        var entity = gameContext.CreateEntity();
        entity.AddAsset("Assets/Game/Prefabs/pref_NPC");
        entity.AddPosition(new Vector3(RandomUtility.Randfloat() * 10, 1, RandomUtility.Randfloat() * 10));
        entity.AddVelocity(new Vector3(-3 + RandomUtility.Randfloat() * 6, 0, -2 + RandomUtility.Randfloat() * 2));
    }

    public static void CreateTileEntity(this GameContext gameContext, Vector2 tilePosition, bool isTileActive_)
    {
        var entity = gameContext.CreateEntity();
        entity.AddAsset("Prefabs/pref_Tile");
        entity.isTileActive = isTileActive_;
        entity.AddTileCoponent(Vector2.zero);
        entity.AddPosition(new Vector3(-2.5f + tilePosition.x * 1.0f, -2.5f + tilePosition.y * 1.0f ));
    }

}