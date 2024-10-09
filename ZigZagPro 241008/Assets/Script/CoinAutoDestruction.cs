using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAutoDestruction : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(AutoDestruction());
    }

    IEnumerator AutoDestruction()
    {
        yield return new WaitForSeconds(1f);
        //Destroy(this.gameObject,10.0f);
    }
}
