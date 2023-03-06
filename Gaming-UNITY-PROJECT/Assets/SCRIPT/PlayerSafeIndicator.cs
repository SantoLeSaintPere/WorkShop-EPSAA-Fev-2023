using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSafeIndicator : MonoBehaviour
{
    public bool safe;
    public float safeRange;
    public bool unDetected;

    public Image safeIndicator;
    public Sprite safeSprite;
    public Sprite notSafeSprite;
    public Sprite detectedSprite;
    public LayerMask hidingPlace;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        unDetected = GetComponent<PlayerWoof>().notDetected;

        

        if (unDetected == true)
        {
            Collider[] playerSafetyZone = Physics.OverlapSphere(transform.position, safeRange, hidingPlace);
            if (playerSafetyZone.Length > 0)
            {
                safeIndicator.sprite = safeSprite;
                //safe = true;
            }

            else
            {
                safeIndicator.sprite = notSafeSprite;
                //safe = false;
            }
        }

        else
        {
            safeIndicator.sprite = detectedSprite;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, safeRange);
    }
}
