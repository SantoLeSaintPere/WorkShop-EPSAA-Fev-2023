using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMainMenu : MonoBehaviour
{
    public string gameScene;
    public SaveS save;
    public string mainMenuScene;

    public void GoToMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
    }

    public void LoadGame()
    {
        save.isLoad = 1;
        SceneManager.LoadScene(gameScene);
    }
}
