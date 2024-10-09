using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingFloor : MonoBehaviour
{
    public Rigidbody rb;
    float delay;
    bool gravityTrigger;
    // Start is called before the first frame update
    void Start()
    {
        gravityTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (gravityTrigger == true)
        {
            delay += Time.deltaTime;

        }
        if ((delay > 0.45f && GameObject.Find("Player").GetComponent<Player>().playerSpeed<=5.0)|| (delay > 0.3f && GameObject.Find("Player").GetComponent<Player>().playerSpeed > 5 && GameObject.Find("Player").GetComponent<Player>().playerSpeed <= 7.5)||(delay > 0.2f && GameObject.Find("Player").GetComponent<Player>().playerSpeed > 7.5))
        {
            rb.useGravity = true;
            Destroy(gameObject, 1.0f);
            GameObject.Find("Controller").GetComponent<FloorMaker>().floorQtt--;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
      
        if (collision.transform.CompareTag("Player"))
        {
            gravityTrigger = true;          
            
            

        }
    }
 
}
