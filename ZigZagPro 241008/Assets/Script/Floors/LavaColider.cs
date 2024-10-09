using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaColider : MonoBehaviour
{
    public GameObject lavaParticles;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<Player>().shield == false)
            {
                Instantiate(lavaParticles, collision.transform);
                AudioMannager.Instance.PlayFX(AudioMannager.Instance.LavaFX);
                collision.gameObject.GetComponent<Player>().gameOver = true;
            }
            else
            {
                Destroy(gameObject);
                collision.gameObject.GetComponent<Player>().shield = false;
            }
        }
        
    }
}
