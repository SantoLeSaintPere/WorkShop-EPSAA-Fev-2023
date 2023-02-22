using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    public KeyCode reloadKey = KeyCode.R;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(reloadKey))
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
