using Entitas;
using UnityEngine;
public class TileActiveListener : MonoBehaviour, ITileActiveListener, IEventListener
{
    GameEntity _entity;
    public void OnTileActive(GameEntity entity)
    {
        if (entity.isTileActive)
        {

        }
        else
        {

        }
    }

    public void RegisterListeners(IEntity entity)
    {
        _entity = (GameEntity)entity;
        _entity.AddTileActiveListener(this);
    }
}