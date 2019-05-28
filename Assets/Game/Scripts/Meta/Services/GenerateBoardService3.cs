using UnityEngine;
using System.Collections.Generic;
using System;

public class GenerateBoardService3 : IGenerateBoardService
{
    private System.Random _systemRandom;
    private Board _currentBoard;

    class Board {
        private int[,] _tiles;
        private int _x;
        private int _y;

        public int x => _x;
        public int y => _y;

        public int this[int x, int y] {
            get { return _tiles[x,y]; }
            set { _tiles[x,y] = value; }
        }

        public int[,] Tiles => _tiles;
        
        public Board (int sizeX, int sizeY) {
            _x = sizeX;
            _y = sizeY;
            _tiles = new int[sizeX, sizeY];

            for (int i = 0; i < sizeX; i++) {
                for (int j = 0; j < sizeY; j++) {
                    _tiles[i,j] = 0;
                }
            }
        }
    }

    public GenerateBoardService3 () {
        _systemRandom = new System.Random();
    }

    public void GenerateBoard(Vector2 dimension, int hardLevel)
    {
        // create random with new seed
        _systemRandom = new System.Random();
        // _systemRandom = new System.Random(1);

        var board = new Board((int)dimension.x, (int)dimension.y);
        var availableMoves = GetAvailableMoves(board, hardLevel);

        _currentBoard = board;

        while (availableMoves.Count > 0) {
            UpdateAvailableMoves(board, availableMoves, hardLevel);
            if (availableMoves.Count == 0)
                break;
            var move = GetRandomMove(availableMoves);
            UpdateBoardFromPoint(board, move);
            Debug.Log("Move: " + move.x + move.y);
            PrintBoard();
        }

        _currentBoard = board;
    }

    private void UpdateAvailableMoves(Board board, List<Vector2Int> availableMoves, int hardLevel)
    {
        for (int i = 0; i < availableMoves.Count; i++) {
            var move = availableMoves[i];
            if (CheckLevelAroundPoint(board, move, hardLevel) == false) {
                availableMoves.RemoveAt(i);
                i--;
            }
        }
    }

    private Vector2Int GetRandomMove(List<Vector2Int> availableMoves)
    {
        var index = _systemRandom.Next(0, availableMoves.Count);
        return availableMoves[index];
    }

    private List<Vector2Int> GetAvailableMoves(Board board, int maxLevel)
    {
        var availableMoves = new List<Vector2Int>();
        for (int i = 0; i < board.x; i++) {
            for (int j = 0; j < board.y; j++) {
                if (board[i,j] < maxLevel) {
                    availableMoves.Add(new Vector2Int(i,j));
                }
            }
        }
        return availableMoves;
    }

    private void UpdateBoardFromPoint(Board board, Vector2Int nextPoint)
    {
        ChangeStateAtPoint(board, new Vector2Int(nextPoint.x + 1, nextPoint.y));
        ChangeStateAtPoint(board, new Vector2Int(nextPoint.x - 1, nextPoint.y));
        ChangeStateAtPoint(board, new Vector2Int(nextPoint.x, nextPoint.y + 1));
        ChangeStateAtPoint(board, new Vector2Int(nextPoint.x, nextPoint.y - 1));
        ChangeStateAtPoint(board, nextPoint);
    }

    private void ChangeStateAtPoint(Board board, Vector2Int nextPoint)
    {
        if (IsPointOutSideOfBoard(nextPoint, board)) return;
        board[nextPoint.x, nextPoint.y] += 1;
    }

    private bool IsPointOutSideOfBoard(Vector2Int point, Board board)
    {
        if (point.x > board.x - 1 || point.x < 0 || point.y < 0 || point.y > board.y - 1)
            return true;
        else
            return false;
    }
    
    private bool CheckLevelAroundPoint (Board board, Vector2Int point, int maxLevel)
    {
        var c0 = CheckLevelAtPoint(board, point, maxLevel);
        var c1 = CheckLevelAtPoint(board, new Vector2Int(point.x + 1, point.y), maxLevel);
        var c2 = CheckLevelAtPoint(board, new Vector2Int(point.x - 1, point.y), maxLevel);
        var c3 = CheckLevelAtPoint(board, new Vector2Int(point.x, point.y + 1), maxLevel);
        var c4 = CheckLevelAtPoint(board, new Vector2Int(point.x, point.y - 1), maxLevel);
        return c1 && c2 && c3 && c4 && c0;
    }

    private bool CheckLevelAtPoint (Board board, Vector2Int point, int maxLevel)
    {
        // int level = 0;
        // _levelOfEachTile.TryGetValue(point, out level);
        if (IsPointOutSideOfBoard(point, board)) return true;

        return board[point.x, point.y] + 1 <= maxLevel;
    }

    public int[,] GetBoard()
    {
        if (_currentBoard != null)
            return _currentBoard.Tiles;
        
        throw new Exception("Board is null.");
    }

    public Vector2 GetDimension()
    {
        if (_currentBoard != null)
            return new Vector2(_currentBoard.x, _currentBoard.y);
        
        throw new Exception("Board is null.");
    }

    public bool IsBoardClean()
    {
        if (_currentBoard == null) throw new Exception("Board is null.");

        for (int i = 0; i < _currentBoard.x; i++) {
            for (int j = 0; j < _currentBoard.y; j++) {
                if (_currentBoard[i,j] % 2 != 0)
                    return false;
            }
        }

        return true;
    }

    public void PrintBoard()
    {
        if (_currentBoard == null) throw new Exception("Board is null.");

        string c = "";

        for (int i = 0; i < _currentBoard.x; i++) {
            for (int j = 0; j < _currentBoard.y; j++) {
                c += _currentBoard[i, j] + " ";
                if (j == _currentBoard.y - 1)
                {
                    c += "\n";
                }
            }
        }

        Debug.Log(c);
    }

    public void UpdateBoard(Vector2 position)
    {
        UpdateBoardFromPoint(_currentBoard, new Vector2Int((int)position.x, (int)position.y));
    }
}