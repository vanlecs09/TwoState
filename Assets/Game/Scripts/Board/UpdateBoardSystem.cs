using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class UpdateBoardSystem : ReactiveSystem<GameEntity>
{
    GameContext _gameContext;
    MetaContext _metaContext;
    IGroup<GameEntity> _movers;
    public UpdateBoardSystem(Contexts contexts) : base(contexts.game)
    {
        _gameContext = contexts.game;
        _metaContext = contexts.meta;
        IGroup<GameEntity> _movers = _gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.Tile));
        Debug.Log("asldjsadk");
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.UpdateBoard);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasUpdateBoard;
    }
    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            _metaContext.generateBoardService.instance.UpdateBoard(e.updateBoard.position);
            int[,] boards = _metaContext.generateBoardService.instance.GetBoard();
            for (int i = 0; i < 5; i++)
            {
                for(int j = 0; j < 5; j ++) 
                {

                    // _movers.HandleEntity()
                    _movers = _gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.Tile));
                    foreach(var tile in _movers)
                    {
                        if(tile.tilePosition.value.x == i && tile.tilePosition.value.y == j)
                        {
                            Debug.Log("here");  
                            tile.ReplaceTileActive(boards[i,j] == 1);
                        }
                    }
                }
            }
        }
    }
}