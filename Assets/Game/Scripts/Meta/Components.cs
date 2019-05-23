using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;
[Meta, Unique]
public class TimeServiceComponent: IComponent
{
    public ITimeService instance;
}

[Meta, Unique]
public class ViewServiceComponent: IComponent
{
    public IViewService instance;
}

[Meta, Unique]
public class ObjectPoolComponent: IComponent
{
    public IObjectPoolService instance;
}


[Game, Event(EventTarget.Self)]
public class PositionComponent: IComponent
{
    public Vector3 value;
}

[Game, Event(EventTarget.Self)]
public class RotationComponent: IComponent
{
    public Vector3 value;
}

[Input]
public class CollisionComponent: IComponent
{
    public Entity self;
    public Entity other;
}

[Game]
public class AssetComponent: IComponent
{
    public string value;
}

[Game]
public class SpeedComponent: IComponent
{
    public float value;
}

[Game]
public class VelocityComponent: IComponent
{
    public Vector3 value;
}

[Game]
public class DirectionComponent: IComponent
{
    public Vector3 direction;
}
