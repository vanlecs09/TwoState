using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GenerateBoardService : IGenerateBoardService
{
    int[,] _board;
    Vector2 _dimension;
    Dictionary<Vector2, int> _levelOfEachTile;
    int _maxLevel;

    Vector2 _previousStep;

    System.Random _systemRandom;

    public int[,] GetBoard()
    {
        return _board;
    }

    public Vector2 GetDimension()
    {
        return _dimension;
    }

    public void GenerateBoard(Vector2 boadDimension)
    {
        _dimension = boadDimension;
        CreateAndResetBoard(boadDimension);
        _maxLevel = 2;

        while(IsBoardStillCanRandom())
        {
            var nextPoint = GetNextRandomPoint();
            ChangeRelateStateFromPoint(nextPoint);
            _previousStep = nextPoint;
            PrintBoard();
        }
    }

    public void UpdateBoard(Vector2 position)
    {
        ChangeRelateStateFromPoint(position);
    }

    public bool IsBoardClean()
    {
        for (int i = 0; i < _dimension.x; i++)
        {
            for (int j = 0; j < _dimension.y; j++)
            {
                if (_board[i, j] %2 != 0)
                    return false;
            }
        }

        return true;
    }

    void ChangeRelateStateFromPoint(Vector2 nextPoint)
    {
        ChangeStateAtPoint(new Vector2(nextPoint.x + 1, nextPoint.y));
        ChangeStateAtPoint(new Vector2(nextPoint.x - 1, nextPoint.y));
        ChangeStateAtPoint(new Vector2(nextPoint.x, nextPoint.y + 1));
        ChangeStateAtPoint(new Vector2(nextPoint.x, nextPoint.y - 1));
        ChangeStateAtPoint(nextPoint);
    }

    void ChangeStateAtPoint(Vector2 nextPoint)
    {
       if(IsPointOutSideOfBoard(nextPoint)) return;
        _board[(int)nextPoint.x, (int)nextPoint.y] += 1;
        // _board[(int)nextPoint.x, (int)nextPoint.y] = _board[(int)nextPoint.x, (int)nextPoint.y] == 0 ? 1 : 0;
        // _levelOfEachTile.try
    }

    bool IsPointOutSideOfBoard(Vector2 nextPoint)
    {
         if (nextPoint.x > _dimension.x - 1 || nextPoint.x < 0 || nextPoint.y < 0 || nextPoint.y > _dimension.y - 1) return true;
         else return false;
    }


    bool IsBoardStillCanRandom()
    {
        for (int i = 0; i < _dimension.x; i++)
        {
            for (int j = 0; j < _dimension.y; j++)
            {
                // _board[i, j] = 0;
                // _levelOfEachTile.Add(new Vector2(i, j), 0);
                if(CheckLevelAroundPoint(new Vector2(i, j)) == true) 
                    return true;
            }
        }
        return false;
    }

    bool CheckLevelAroundPoint(Vector2 point)
    {
        var c0 = CheckLevelAtPoint(point);
        var c1 = CheckLevelAtPoint(new Vector2(point.x + 1, point.y));
        var c2 = CheckLevelAtPoint(new Vector2(point.x - 1, point.y));
        var c3 = CheckLevelAtPoint(new Vector2(point.x, point.y + 1));
        var c4 = CheckLevelAtPoint(new Vector2(point.x, point.y - 1));
        return c1 && c2 && c3 && c4 && c0;
    }

    bool CheckLevelAtPoint(Vector2 point)
    {
        // int level = 0;
        // _levelOfEachTile.TryGetValue(point, out level);
        if(IsPointOutSideOfBoard(point)) return true;
        
        return _board[(int)point.x,(int)point.y] + 1 < _maxLevel;
    }

    void CreateAndResetBoard(Vector2 demension)
    {
        _systemRandom = new System.Random();
        _previousStep = Vector2.zero;
        _levelOfEachTile = new Dictionary<Vector2, int>();
        _board = new int[(int)demension.x, (int)demension.y];
        for (int i = 0; i < demension.x; i++)
        {
            for (int j = 0; j < demension.y; j++)
            {
                _board[i, j] = 0;
                _levelOfEachTile.Add(new Vector2(i, j), 0);
            }
        }
    }

    Vector2 GetNextRandomPoint()
    {
        Vector2 randomPoint = Vector2.zero;
        do
        {
            var nextX = _systemRandom.Next(0, (int)(_dimension.x - 1));
            var nextY = _systemRandom.Next(0, (int)(_dimension.y - 1));
            randomPoint = new Vector2(nextX, nextY);
            
        } while (randomPoint.x == _previousStep.x && randomPoint.y == _previousStep.y && CheckLevelAroundPoint(randomPoint) == false);
        Debug.Log(randomPoint);
        return randomPoint;
    }

    public void PrintBoard()
    {
        string c = "";
        for (int i = 0; i < _dimension.x; i++)
        {
            for (int j = 0; j < _dimension.y; j++)
            {
                // _board[i,j] = 0;
                c += _board[i, j] + " ";
                if (j == _dimension.y - 1)
                {
                    c += "\n";
                }
            }
        }

        c += _previousStep;

        Debug.Log(c);
    }
}