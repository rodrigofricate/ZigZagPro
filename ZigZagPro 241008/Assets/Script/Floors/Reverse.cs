using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reverse : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(this.name == "ReversedX(Clone)")
            {
                GameObject.Find("Player").GetComponent<Player>().reverseX=-1;
                GameObject.Find("Player").GetComponent<Player>().reverseZ=1;
            }
            if(this.name == "ReversedZ(Clone)")
            {
                GameObject.Find("Player").GetComponent<Player>().reverseX=1;
                GameObject.Find("Player").GetComponent<Player>().reverseZ=-1;
            }
                        
        }        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(this.name == "ReversedX(Clone)")
            {
                GameObject.Find("Player").GetComponent<Player>().reverseX=1;
                GameObject.Find("Player").GetComponent<Player>().reverseZ=1;
            }
            if(this.name == "ReversedZ(Clone)")
            {
                GameObject.Find("Player").GetComponent<Player>().reverseX=1;
                GameObject.Find("Player").GetComponent<Player>().reverseZ=1;
            }
                        
        }        
    }
}

