using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighFloor : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        transform.position += new Vector3(0, 0.62f, 0);
    }

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

