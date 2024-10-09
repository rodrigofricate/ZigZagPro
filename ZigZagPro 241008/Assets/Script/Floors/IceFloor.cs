using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceFloor : MonoBehaviour
{
    public Rigidbody rb;
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
            collision.transform.GetComponent<Player>().iceWalk = 0.1f;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
      
        if (collision.transform.CompareTag("Player"))
        {
            GameObject.Find("Player").GetComponent<Player>().iceWalk = 0;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
       
       
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            GameObject.Find("Player").GetComponent<Player>().floorPlayered++;

            rb.useGravity = true;
            Destroy(gameObject, 1f);
            GameObject.Find("Controller").GetComponent<FloorMaker>().floorQtt--;

        }
    }
}
