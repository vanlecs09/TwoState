using UnityEngine;
using Entitas;
public class PositionListener : MonoBehaviour, IEventListener, IPositionListener {
    
    GameEntity _entity;
 
    public void RegisterListeners(IEntity entity) 
    {
        _entity = (GameEntity)entity;
        _entity.AddPositionListener(this);
    }

    public void OnPosition(GameEntity e, Vector3 newPosition) 
    {
        transform.position = newPosition;
    }
}