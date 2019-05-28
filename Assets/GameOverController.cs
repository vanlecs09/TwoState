using UnityEngine;

public class GameOverController : MonoBehaviour
{
    private void Start() {
        GetComponent<Canvas>().enabled = true;
    }

    public void GoToMainMenu () {
        Contexts.sharedInstance.game.CreateClearBoardEntity();
        Contexts.sharedInstance.input.CreateHideUiCommandEntity("GameOver");
        Contexts.sharedInstance.input.CreateShowUiCommandEntity("MainMenu");
    }
}
