using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerGetCaught : MonoBehaviour
{
    public GameObject panelGameOver;
    public float time;
    public string sceneGameOVer;

    public float catchRange;
    public LayerMask enemyMask;
    // Start is called before the first frame update
    void Start()
    {

        panelGameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] enemyCatchDog = Physics.OverlapSphere(transform.position, catchRange, enemyMask);
        if(enemyCatchDog.Length > 0)
        {
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("CAUGHT");

            //panelGameOver.SetActive(true);
            //SceneManager.LoadScene(sceneGameOVer);
            StartCoroutine(DogIsCaught());
        }
    }

    IEnumerator DogIsCaught()
    {
        panelGameOver.SetActive(true);
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(sceneGameOVer);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, catchRange);
    }


}
