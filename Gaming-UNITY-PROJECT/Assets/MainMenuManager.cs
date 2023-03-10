using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    public string gameScene;
    public SaveS save;

    public GameObject keyboardPan, controllerPan;
    // Update is called once per frame

    private void Start()
    {
        keyboardPan.SetActive(false);
        controllerPan.SetActive(false);
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.X))
        {
            save.saving = 0;
        }
    }

    public void ActiveKeyPanel()
    {

        keyboardPan.SetActive(true);
        controllerPan.SetActive(false);
    }


    public void ActiveCOntrollerPanel()
    {
        keyboardPan.SetActive(false);
        controllerPan.SetActive(true);
    }


    public void Back()
    {
        keyboardPan.SetActive(false);
        controllerPan.SetActive(false);
    }

    public void LaunchGame()
    {
        if(save.saving == 0)
        {
            NewGame();
        }

        if (save.saving == 1)
        {
            LoadGame();
        }
    }

    void NewGame()
    {
        save.isLoad = 0;
        save.Lastposition = save.firstPos;

        SceneManager.LoadScene(gameScene);
    }

    void LoadGame()
    {
        save.isLoad = 1;

        SceneManager.LoadScene(gameScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
