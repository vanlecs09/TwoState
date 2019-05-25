using Entitas;
using Entitas.Unity;
using UnityEngine;
public class DestroyListener : MonoBehaviour, IEventListener, IDestroyedListener
{
    GameEntity _entity;
    public void OnDestroyed(GameEntity entity)
    {
        gameObject.Unlink();
        GameObject.Destroy(gameObject);
        entity.Destroy();
    }

    public void RegisterListeners(IEntity entity)
    {
         _entity = (GameEntity)entity;
        _entity.AddDestroyedListener(this);
    }
}