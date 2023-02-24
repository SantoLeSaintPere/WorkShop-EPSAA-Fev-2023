using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    public string gameScene;
    public SaveS save;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame()
    {
        save.isLoad = 0;
        save.Lastposition = save.firstPos;

        SceneManager.LoadScene(gameScene);
    }

    public void LoadGame()
    {
        save.isLoad = 1;

        SceneManager.LoadScene(gameScene);
    }
}
