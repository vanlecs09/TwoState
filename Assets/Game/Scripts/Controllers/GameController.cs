using UnityEngine;
using Entitas;
public class GameController: MonoBehaviour
{
    public void BackToMainMenu()
    {
        Contexts.sharedInstance.game.CreateClearBoardEntity();
        // Contexts.sharedInstance.game.CreateGenerateBoardEntity();
        Contexts.sharedInstance.input.CreateShowUiCommandEntity("MainMenu");
    }
}