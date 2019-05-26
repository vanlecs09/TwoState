using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class GeneratteBoardSystem : ReactiveSystem<GameEntity>, ICleanupSystem
{
    GameContext _gameContext;
    IGroup<GameEntity> _movers;
    MetaContext _metaContext;
    public GeneratteBoardSystem(Contexts contexts) : base(contexts.game)
    {
        _gameContext = contexts.game;
        _metaContext = contexts.meta;
        _movers = _gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.Rotation));
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.GenerateBoard);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isGenerateBoard;
    }
    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            _metaContext.generateBoardService.instance.GenerateBoard(new Vector2(5, 5));
            var dimension = _metaContext.generateBoardService.instance.GetDimension();

            int[,] baords = _metaContext.generateBoardService.instance.GetBoard();
            for (int i = 0; i < dimension.x; i++)
            {
                for(int j = 0; j < dimension.y; j ++) 
                {
                    // Debug.Log(baords[i,j]);
                    _gameContext.CreateTileEntity(new Vector2(i, j), baords[i,j] %2  != 0, dimension);
                }
            }
        }
    }

    public void Cleanup()
    {
        foreach (var e in _movers)
        {
            e.Destroy();
        }
    }
}