using UnityEngine;
public class GenerateBoardService : IGenerateBoardService
{
    int[,] _board;
    Vector2 _demension;

    public int[,] GetBoard()
    {
        return _board;
    }

    public void GenerateBoard(Vector2 demension)
    {
        _demension  = demension;
        CreateAndResetBoard(demension);

        int numberTouch = 20;
        int currentTouch = 0;
        while (currentTouch < numberTouch)
        {
            Vector2 nextPoint = GetNextRandomPoint();
            // Debug.Log(nextPoint);
            ChangeRelateStateFromPoint(nextPoint);
            currentTouch++;
            // PrintBoard();
        }
    }

    public void UpdateBoard(Vector2 position)
    {
        ChangeRelateStateFromPoint(position);
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
        Debug.LogWarning("ChangeStateAtPoint " + nextPoint);
        if(nextPoint.x > _demension.x - 1 || nextPoint.x < 0 || nextPoint.y  < 0 || nextPoint.y > _demension.y - 1) return;
         _board[(int)nextPoint.x, (int)nextPoint.y] = _board[(int)nextPoint.x, (int)nextPoint.y] == 0 ? 1 : 0;
    }

    void CreateAndResetBoard(Vector2 demension)
    {
        _board = new int[(int)demension.x, (int)demension.y];
        for (int i = 0; i < demension.x; i++)
        {
            for (int j = 0; j < demension.y; j++)
            {
                _board[i,j] = 0;
            }
        }
    }

    Vector2 GetNextRandomPoint()
    {
        return new Vector2(Random.Range(0, (int)_demension.x - 1), Random.Range(0, (int)_demension.y - 1));
    }

    public void PrintBoard()
    {
        string c = "";
         for (int i = 0; i < _demension.x; i++)
        {
            for (int j = 0; j < _demension.y; j++)
            {
                // _board[i,j] = 0;
                c += _board[i,j] + " ";
                if(j  == _demension.y - 1)
                {
                    c += "\n";
                }
            }
        }

        Debug.Log(c);
    }
}