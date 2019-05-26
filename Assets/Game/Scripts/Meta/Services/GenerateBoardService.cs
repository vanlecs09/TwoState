using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GenerateBoardService : IGenerateBoardService
{
    int[,] _board;
    Vector2 _dimension;
    List<Vector2> _availablePoints;
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

    public void GenerateBoard(Vector2 boadDimension, int hardLevel = 2)
    {

        CreateAndResetBoard(boadDimension, hardLevel);


        while (IsBoardStillCanRandom(_availablePoints))
        {
            var nextPoint = GetNextRandomPoint();
            UpdateBoardFromPoint( _board, nextPoint);
            UpdateAvailablePoint(_availablePoints, nextPoint);
            PrintBoard();
        }
    }

    public void UpdateBoard(Vector2 position)
    {
        UpdateBoardFromPoint(_board, position);
    }

    public bool IsBoardClean()
    {
        for (int i = 0; i < _dimension.x; i++)
        {
            for (int j = 0; j < _dimension.y; j++)
            {
                if (_board[i, j] % 2 != 0)
                    return false;
            }
        }

        return true;
    }

    void UpdateBoardFromPoint(int[,] boards, Vector2 nextPoint)
    {
        ChangeStateAtPoint(new Vector2(nextPoint.x + 1, nextPoint.y));
        ChangeStateAtPoint(new Vector2(nextPoint.x - 1, nextPoint.y));
        ChangeStateAtPoint(new Vector2(nextPoint.x, nextPoint.y + 1));
        ChangeStateAtPoint(new Vector2(nextPoint.x, nextPoint.y - 1));
        ChangeStateAtPoint(nextPoint);
    }

    void ChangeStateAtPoint(Vector2 nextPoint)
    {
        if (IsPointOutSideOfBoard(nextPoint)) return;
        _board[(int)nextPoint.x, (int)nextPoint.y] += 1;
    }

    bool IsPointOutSideOfBoard(Vector2 nextPoint)
    {
        if (nextPoint.x > _dimension.x - 1 || nextPoint.x < 0 || nextPoint.y < 0 || nextPoint.y > _dimension.y - 1) return true;
        else return false;
    }


    bool IsBoardStillCanRandom(List<Vector2> avaiblePoint)
    {
        return avaiblePoint.Count > 0;
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
        if (IsPointOutSideOfBoard(point)) return true;

        return _board[(int)point.x, (int)point.y] + 1 <= _maxLevel;
    }

    void CreateAndResetBoard(Vector2 dimension, int hardLevel)
    {
        _maxLevel = hardLevel;
        _dimension = dimension;
        _systemRandom = new System.Random();
        _availablePoints = new List<Vector2>();
        _previousStep = Vector2.zero;
        _board = new int[(int)dimension.x, (int)dimension.y];
        for (int i = 0; i < dimension.x; i++)
        {
            for (int j = 0; j < dimension.y; j++)
            {
                _board[i, j] = 0;
                _availablePoints.Add(new Vector2(i, j));
            }
        }
    }

    Vector2 GetNextRandomPoint()
    {
        Vector2 randomPoint = Vector2.zero;
        var index = _systemRandom.Next(0, _availablePoints.Count - 1);
        randomPoint = _availablePoints[index];
        return randomPoint;
    }

    void UpdateAvailablePoint(List<Vector2> avaiblePoint, Vector2 point)
    {
        if (CheckLevelAroundPoint(point) == false)
        {
            _availablePoints.Remove(point);
            Debug.Log("Wrong Move: " + point.x + point.y);
        }
        else
        {
            // Debug.Log("Right Move: " + point.x + point.y);
        }
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
