using UnityEngine;
using Entitas;
public class GameController: MonoBehaviour
{
    public void ResetGame()
    {
        Contexts.sharedInstance.game.CreateClearBoardEntity();
        Contexts.sharedInstance.game.CreateGenerateBoardEntity();
    }
}