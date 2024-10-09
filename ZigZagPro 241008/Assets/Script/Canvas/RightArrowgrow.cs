using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightArrowgrow : MonoBehaviour
{
    private Vector3 actualSize,size;
    public RectTransform rt;
    
    void Start()
    {
        size = rt.localScale;
        actualSize=size;   
        StartCoroutine(GrowShrink());    
    }

    IEnumerator GrowShrink()
    {
        while( GameObject.Find("Player").GetComponent<Player>().started == false)
        {
            yield return new WaitForSeconds(0.5f);   
            if(actualSize == size)
            {            
                actualSize=1.2f*actualSize;
                rt.localScale = actualSize;          
            }
            else
            {    
                actualSize=size;
                rt.localScale = actualSize;
            }     
        }
    }
}
