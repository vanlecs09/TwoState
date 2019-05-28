using UnityEngine;
public class GenerateBoardService2 : IGenerateBoardService
{
    int[,] _board;
    Vector2 _dimension;

    public int[,] GetBoard()
    {
        return _board;
    }

    public Vector2 GetDimension()
    {
        return _dimension;
    }

    public void GenerateBoard(Vector2 dimension,  int hardLevel)
    {
        _dimension  = dimension;
        CreateAndResetBoard(dimension);

        int numberTouch = 10;
        int currentTouch = 0;
        while (currentTouch < numberTouch)
        {
            Vector2 nextPoint = GetNextRandomPoint();
            ChangeRelateStateFromPoint(nextPoint);
            currentTouch++;
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
                if(_board[i,j] == 1)
                    return false;
            }
        }
        
        return true;
    }

    void ChangeRelateStateFromPoint(Vector2 nextPoint)
    {
        ChangeStateAtPoint(new Vector2(nextPoint.x + 1, nextPoint.y));
        ChangeStateAtPoint(new Vector2(nextPoint.x -1 , nextPoint.y));
        ChangeStateAtPoint(new Vector2(nextPoint.x, nextPoint.y + 1));
        ChangeStateAtPoint(new Vector2(nextPoint.x, nextPoint.y - 1));
        ChangeStateAtPoint(nextPoint);
    }

    void ChangeStateAtPoint(Vector2 nextPoint)
    {
        if(nextPoint.x > _dimension.x - 1 || nextPoint.x < 0 || nextPoint.y  < 0 || nextPoint.y > _dimension.y - 1) return;
         _board[(int)nextPoint.x, (int)nextPoint.y] = _board[(int)nextPoint.x, (int)nextPoint.y] == 0 ? 1 : 0;
    }

    void CreateAndResetBoard(Vector2 dimension)
    {
        _board = new int[(int)dimension.x, (int)dimension.y];
        for (int i = 0; i < dimension.x; i++)
        {
            for (int j = 0; j < dimension.y; j++)
            {
                _board[i,j] = 0;
            }
        }
    }

    Vector2 GetNextRandomPoint()
    {
        return new Vector2(Random.Range(0, (int)_dimension.x - 3), Random.Range(0, (int)_dimension.y - 3));
    }

    public void PrintBoard()
    {
        string c = "";
         for (int i = 0; i < _dimension.x; i++)
        {
            for (int j = 0; j < _dimension.y; j++)
            {
                // _board[i,j] = 0;
                c += _board[i,j] + " ";
                if(j  == _dimension.y - 1)
                {
                    c += "\n";
                }
            }
        }

        Debug.Log(c);
    }
}