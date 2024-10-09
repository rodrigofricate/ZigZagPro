using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    void Update()
    {
        if (GameObject.Find("Player").GetComponent<Player>().shield == true)
        {
            transform.position = GameObject.Find("Player").transform.position;
            GameObject.Find("Player").GetComponent<Player>().PUPShieldIcon.enabled = true;
        }
        else
        {
            transform.position = new Vector3(-15f, 0, 0);
            GameObject.Find("Player").GetComponent<Player>().PUPShieldIcon.enabled = false;
        }
    }

}
