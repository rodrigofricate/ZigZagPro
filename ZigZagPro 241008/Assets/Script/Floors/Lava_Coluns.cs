using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava_Coluns : MonoBehaviour
{
    public Rigidbody rb;
    
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           
            GameObject.Find("Player").GetComponent<Player>().floorPlayered++;

            rb.useGravity = true;
            Destroy(gameObject, 1.0f);
            GameObject.Find("Controller").GetComponent<FloorMaker>().floorQtt--;

        }
    }
    
}
