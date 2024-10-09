using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste : MonoBehaviour
{
    Vector3 qualuqer;
    int i;
    // Start is called before the first frame update
    void Start()
    {
        i = 1;
        qualuqer = new Vector3(1, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        qualuqer = new Vector3(i, 0, 0);
    }
}
