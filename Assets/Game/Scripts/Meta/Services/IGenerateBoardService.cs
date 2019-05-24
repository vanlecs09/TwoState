using UnityEngine;

public interface IGenerateBoardService
{
    void GenerateBoard(Vector2 demension);
    void PrintBoard();

    int[,] GetBoard();
}