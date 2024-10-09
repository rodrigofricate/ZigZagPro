using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Vector3 speedAnim;
    float speedRot;
    public GameObject explosionFX;
    
    // Start is called before the first frame update
    void Start()
    {
        speedRot = 150f;
    }

    // Update is called once per frame
    void Update()
    {
        if ((GameObject.Find("Player").transform.position.z - transform.position.z > 2) && (GameObject.Find("Player").transform.position.x - transform.position.x > 2))
        {
            Destroy(gameObject);
        }
        transform.Rotate(0, 0, speedRot * Time.deltaTime, Space.Self);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            speedRot = 1500;
        }
    }
    IEnumerator AutoDestruction()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject,10.0f);
    }
}
