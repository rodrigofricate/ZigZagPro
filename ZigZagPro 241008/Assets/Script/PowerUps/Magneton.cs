using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magneton : MonoBehaviour
{
    Vector3 magSpeed = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player").GetComponent<Player>().magnectField == true)
        {
            transform.position = GameObject.Find("Player").transform.position;
        }
        else
        {
            transform.position = new Vector3(-15f, 0, 0);
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (GameObject.Find("Player").GetComponent<Player>().magnectField == true)
        {
           
            if (other.CompareTag("Coin"))
            {
               
                other.transform.position = Vector3.SmoothDamp(other.transform.position, GameObject.Find("Player").transform.position, ref magSpeed, 0.1f);
            }

        }
    }
}
