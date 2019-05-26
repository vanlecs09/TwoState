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

        FindObjectOfType<MainController>().StartCoroutine(EndGame());
    }

    private IEnumerator EndGame()
    {
        Debug.Log("WEFASAD");
        yield return new WaitForSeconds(3);
        Debug.Log("ASDASD");
        Contexts.sharedInstance.input.CreateGameOverEntity();
    }

    public void QuitGame () {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
