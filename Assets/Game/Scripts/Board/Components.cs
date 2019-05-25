using Entitas;
using Entitas.CodeGeneration;
using UnityEngine;

[Game]
public class GenerateBoardComponent : IComponent
{

}

[Game]
public class UpdateBoardComponent: IComponent
{
    public Vector2 position;
}
