using Entitas;
using UnityEngine;


public static class SceneContextEntension
{
    // public static CreateChangeScene()

}

public static class GameContextEntesion
{
    public static void CreateSimpleMovingEntity(this GameContext gameContext)
    {
        var entity = gameContext.CreateEntity();
        entity.AddAsset("Assets/Game/Prefabs/pref_NPC");
        entity.AddPosition(new Vector3(RandomUtility.Randfloat() * 10, 1, RandomUtility.Randfloat() * 10));
        entity.AddVelocity(new Vector3(-3 + RandomUtility.Randfloat() * 6, 0, -2 + RandomUtility.Randfloat() * 2));
        // entity.AddRotation(Vector3.zero);
    }

    // public static void 
}