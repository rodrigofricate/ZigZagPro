using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Coluns : MonoBehaviour
{
    public float speedRotCenterMax,speedRotCenterMin,speedRotCenter;
    public Vector3 speedRotCol;
    // Start is called before the first frame update
    void Start()
    {
        speedRotCenter=Random.Range(speedRotCenterMin*100,speedRotCenterMax*100);
        speedRotCenter = speedRotCenter/100;
    }

    // Update is called once per frame
    void Update()
    {
   
        transform.Rotate(0,speedRotCenter,0);        
        foreach (Transform child in transform) 
        {                
            child.transform.Rotate(speedRotCol);
        }
        if(this.GetComponent<Rigidbody>().useGravity == true)
        {
           foreach (Transform child in transform) 
            {                
                child.GetComponent<Rigidbody>().useGravity= true;
            }
        }
    }
}
