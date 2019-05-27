using UnityEngine;
using UnityEditor;
using Entitas;
using System.Collections.Generic;
using Entitas.Unity;

public class UnityViewService : IViewService
{
    private Dictionary<string, GameObject> _prefabSearchList = new Dictionary<string, GameObject>();

    public void LoadAsset(Contexts contexts, IEntity entity, string assetName, Transform parent)
    {
        var viewGo = GameObject.Instantiate(Resources.Load<GameObject>(assetName));
        if (viewGo != null)
        {
            var eventListeners = viewGo.GetComponents<IEventListener>();
            foreach (var listener in eventListeners)
            {
                listener.RegisterListeners(entity);
            }
            viewGo.transform.parent = parent.transform;
            viewGo.Link(entity);
        } else {
            Debug.LogError("can not load game object " + assetName);
        }
    }
}