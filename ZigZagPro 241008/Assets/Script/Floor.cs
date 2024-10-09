using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public Rigidbody rb;
    private Vector3 fixTrans;
    // Start is called before the first frame update
    void Start()
    {
        if(this.name=="HighFloor(Clone)")
        {
            fixTrans = new Vector3(transform.position.x,0.62f,transform.position.z);
        }
        else
            fixTrans = new Vector3(transform.position.x,0.0f,transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.useGravity == false)
        {
            transform.position = fixTrans;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject.Find("Player").GetComponent<Player>().floorPlayered++;

            rb.useGravity = true;
            
            foreach (Transform child in transform) {
              if(child.name!="FloorTrigger")              
              child.GetComponent<Rigidbody>().useGravity= true;
              
            }
            Destroy(gameObject, 1.0f);
            GameObject.Find("Controller").GetComponent<FloorMaker>().floorQtt--;

        }
    }           
    
}
