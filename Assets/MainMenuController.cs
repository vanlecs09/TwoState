using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public void StartGame (string difficulty) {
        Contexts.sharedInstance.input.CreateHideUiCommandEntity("MainMenu");
        Contexts.sharedInstance.input.CreateStartGameEntity(difficulty);
    }

    public void QuitGame () {
        
    }
}
