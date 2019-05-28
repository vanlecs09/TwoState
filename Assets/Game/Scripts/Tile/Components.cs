using Entitas;
using UnityEngine;
using Entitas.CodeGeneration.Attributes;

[Game] 
public class TilePositionComponent: IComponent
{
    public Vector2 value;
}

[Game]
public class TileComponent: IComponent
{

}

[Game, Event(EventTarget.Self)]
public class TileActiveComponent: IComponent
{
    public bool value;
}
