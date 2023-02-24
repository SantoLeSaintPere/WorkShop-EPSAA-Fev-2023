using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject panel;
    public static bool gameIsPaused = false;
    public string menuName;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused)
            {
                Resume();
            }

            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void Pause()
    {
        panel.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }


    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(menuName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
