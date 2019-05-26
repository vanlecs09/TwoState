using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class UpdateBoardSystem : ReactiveSystem<GameEntity>
{
    GameContext _gameContext;
    MetaContext _metaContext;
    InputContext _inputContext;
    IGroup<GameEntity> _movers;
    public UpdateBoardSystem(Contexts contexts) : base(contexts.game)
    {
        _gameContext = contexts.game;
        _metaContext = contexts.meta;
        _inputContext = contexts.input;
        IGroup<GameEntity> _movers = _gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.Tile));
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
            var dimension = _metaContext.generateBoardService.instance.GetDimension();

            // else
            {
                int[,] boards = _metaContext.generateBoardService.instance.GetBoard();

                for (int i = 0; i < dimension.x; i++)
                {
                    for (int j = 0; j < dimension.y; j++)
                    {
                        _movers = _gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.Tile));
                        foreach (var tile in _movers)
                        {
                            if (tile.tilePosition.value.x == i && tile.tilePosition.value.y == j)
                            {
                                Debug.Log("here");
                                tile.ReplaceTileActive(boards[i, j] % 2 != 0);
                            }
                        }
                    }
                }
            }

            if (_metaContext.generateBoardService.instance.IsBoardClean())
            {
                // _gameContext.CreateClearBoardEntity();
                // _gameContext.CreateGenerateBoardEntity();
                _inputContext.CreateGameOverEntity();
            }
        }
    }
}