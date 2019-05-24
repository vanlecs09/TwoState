using Entitas;
using UnityEngine;
using Entitas.CodeGeneration.Attributes;

[Game]
public class TileCoponent: IComponent
{
    public Vector2 position;
}

[Game, Event(EventTarget.Self)]
public class TileActiveComponent: IComponent
{
}
