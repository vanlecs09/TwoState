using UnityEngine;
using Entitas.Unity;
using Entitas;
public class TileTouch : MonoBehaviour
{
    void OnMouseDown()
    {
        var entity = (GameEntity)gameObject.GetEntityLink().entity;
        Contexts.sharedInstance.input.CreateTouchAtTile(entity);
    }
}