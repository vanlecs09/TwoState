using UnityEngine;
using Entitas.Unity;
using Entitas;
using UnityEngine.EventSystems;

public class TileTouch : MonoBehaviour
{
    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        
        var entity = (GameEntity)gameObject.GetEntityLink().entity;
        Contexts.sharedInstance.input.CreateTouchAtTile(entity);
    }
}