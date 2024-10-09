using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colider : MonoBehaviour
{
    public GameObject cutParticles;
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
                Instantiate(cutParticles, collision.transform);
                AudioMannager.Instance.PlayFX(AudioMannager.Instance.CutFX);
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
