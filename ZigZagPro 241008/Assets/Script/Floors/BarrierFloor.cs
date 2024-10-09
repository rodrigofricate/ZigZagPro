using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BarrierFloor : MonoBehaviour
{
    public Rigidbody rb;
   public GameObject barrier;
    public TextMeshPro coinsTextM;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinsTextM.text = GameObject.Find("Player").GetComponent<Player>().floorPlayered.ToString();

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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(GameObject.Find("Player").GetComponent<Player>().coins>= GameObject.Find("Player").GetComponent<Player>().floorPlayered)
            {
                AudioMannager.Instance.PlayFX(AudioMannager.Instance.OpenBarrierFX);
                Destroy(barrier);
            }
            else
            {
                AudioMannager.Instance.PlayFX(AudioMannager.Instance.FailBarrierFX);
                rb.useGravity = true;

            }
        }
    }
}
