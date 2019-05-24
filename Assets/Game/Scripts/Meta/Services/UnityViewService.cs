using UnityEngine;
using UnityEditor;
using Entitas;
using System.Collections.Generic;

public class UnityViewService : IViewService
{
    private Dictionary<string, GameObject> _prefabSearchList = new Dictionary<string, GameObject>();

    public void LoadAsset(Contexts contexts, IEntity entity, string assetName, Transform parent)
    {

        GameObject gameObjet = null;
        if (_prefabSearchList.ContainsKey(assetName))
        {
            _prefabSearchList.TryGetValue(assetName, out gameObjet);
        }
        else
        {
#if UNITY_EDITOR
            gameObjet = GameObject.Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>(assetName + ".prefab"));
#else 
#endif
            _prefabSearchList.Add(assetName, gameObjet);
        }

        var viewGo = contexts.meta.objectPool.instance.Spawn(gameObjet);

        if (viewGo != null)
        {
            var eventListeners = viewGo.GetComponents<IEventListener>();
            foreach (var listener in eventListeners)
            {
                listener.RegisterListeners(entity);
            }
            viewGo.transform.parent = parent.transform;
        }
    }
}