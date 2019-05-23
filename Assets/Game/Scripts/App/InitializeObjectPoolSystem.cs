
using Entitas;
using UnityEngine;
using UnityEditor;
public class InitializeObjectPoolSystem : IInitializeSystem
{
    private readonly MetaContext _metaContext;
    private readonly IObjectPoolService _objectPoolService;

    public InitializeObjectPoolSystem(Contexts contexts)
    {
        _metaContext = contexts.meta;
        // _objectPoolService = objectPoolService;
    }

    public void Initialize()
    { 
#if UNITY_EDITOR
        var gameObject = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Game/Prefabs/pref_NPC.prefab");
#endif
        _metaContext.objectPool.instance.Prespawn(gameObject,1000);
    }
}