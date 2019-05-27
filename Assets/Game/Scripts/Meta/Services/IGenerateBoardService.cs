using UnityEngine;

public interface IGenerateBoardService
{
    void GenerateBoard(Vector2 dimension, int hardLevel);
    void PrintBoard();

    int[,] GetBoard();

    void UpdateBoard(Vector2 position);

    bool IsBoardClean();

    Vector2 GetDimension();
}