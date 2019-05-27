using System;
using System.Collections;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    private void Start() {
        GetComponent<Canvas>().enabled = true;
    }
    
    public void StartGame (string difficulty) {
        Contexts.sharedInstance.input.CreateHideUiCommandEntity("MainMenu");
        Contexts.sharedInstance.input.CreateStartGameEntity(difficulty);

        // FindObjectOfType<App>().StartCoroutine(EndGame());
    }

    private IEnumerator EndGame()
    {
        yield return new WaitForSeconds(5);
        Debug.Log("Force GameOver here");
        Contexts.sharedInstance.input.CreateGameOverEntity();
    }

    public void QuitGame () {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
