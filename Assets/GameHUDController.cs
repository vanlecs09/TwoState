using UnityEngine;
using Entitas;
public class GameHUDController: MonoBehaviour
{
    private void Start() {
        GetComponent<Canvas>().enabled = true;
    }

    public void BackToMainMenu()
    {
        Contexts.sharedInstance.game.CreateClearBoardEntity();
        // Contexts.sharedInstance.game.CreateGenerateBoardEntity();
        Contexts.sharedInstance.input.CreateHideUiCommandEntity("GameHUD");
        Contexts.sharedInstance.input.CreateShowUiCommandEntity("MainMenu");
    }
}