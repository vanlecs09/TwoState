using UnityEngine;
using Entitas;
public class RotationListener : MonoBehaviour, IEventListener, IRotationListener {
    
    GameEntity _entity;
 
    public void RegisterListeners(IEntity entity) 
    {
        _entity = (GameEntity)entity;
        _entity.AddRotationListener(this);
    }

    public void OnRotation(GameEntity e, Vector3 newRotation) 
    {
        transform.rotation = Quaternion.Euler(newRotation.x, newRotation.y, newRotation.z);
    }
}