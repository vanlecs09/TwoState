using Entitas;
using UnityEngine;
public class TileActiveListener : MonoBehaviour, ITileActiveListener, IEventListener
{
    GameEntity _entity;

    public void OnTileActive(GameEntity entity, bool value)
    {
        Color spriteColor = value == true ? Color.white : Color.green;
        gameObject.GetComponent<SpriteRenderer>().color = spriteColor;
    }

    public void RegisterListeners(IEntity entity)
    {
        _entity = (GameEntity)entity;
        _entity.AddTileActiveListener(this);
    }
}