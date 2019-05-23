using Entitas;
using UnityEngine;
using System;
using System.Threading;

public class SimpleMovementSystem : IExecuteSystem {
    readonly GameContext _gameContext;
    readonly MetaContext _metaContext;
    readonly Contexts _contexts;
    IGroup<GameEntity> _movers;
    float delaTime;
    public SimpleMovementSystem(Contexts contexts)//,  int threads) : base(contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Position, GameMatcher.Velocity)), threads)
    {
        _gameContext = contexts.game;
        _metaContext = contexts.meta;
        _contexts = contexts;
        _movers = _gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.Position, GameMatcher.Velocity));
    }

    public void Execute()
    {
        delaTime = _metaContext.timeService.instance.GetDeltaTime();
        foreach (GameEntity e in _movers)
        {
            // var speed = e.speed.value;
            // var rotation = e.rotation.value;
            var position = e.position.value;
            var velocity = e.velocity.value;
            position += velocity * delaTime;
            // _contexts.log.CreateDebugMessage("" + velocity);
            // _contexts.log.CreateDebugMessage("" + position);
            e.ReplacePosition(position);
        }
    }
}

// public sealed class SimpleMovementSystem : JobSystem<GameEntity>
// {
//     readonly GameContext _gameContext;
//     readonly MetaContext _metaContext;
//     readonly Contexts _contexts;
//     IGroup<GameEntity> _movers;
//     float delaTime;
//     public SimpleMovementSystem(Contexts contexts, int threads) : base(contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Position, GameMatcher.Velocity)), threads)
//     {
//         _gameContext = contexts.game;
//         _metaContext = contexts.meta;
//         _contexts = contexts;
//         _movers = _gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.Position, GameMatcher.Velocity));
//     }


//     protected override void Execute(GameEntity e)
//     {
        
//         // var delaTime = Time.deltaTime;
//         var position = e.position.value;
//         var velocity = e.velocity.value;
//         e.position.value = position + velocity * 0.02f;
        
//         // e.ReplacePosition(e.position.value);
//         // Debug.Log("delta time " + delaTime);
//         // _contexts.log.CreateDebugMessage("" + velocity);
//         // _contexts.log.CreateDebugMessage("" + position);
//         // e.ReplacePosition(position);
//     }
// }