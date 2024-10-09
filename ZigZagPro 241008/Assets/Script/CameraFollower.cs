using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script;
public class CameraFollower : MonoBehaviour
{
    [SerializeField]
    private Transform ballTransform;

    private Vector3 distance, pos, targetPos;
    [SerializeField] float lerpValue;
    [SerializeField] Transform[] cameraPos;
    // Start is called before the first frame update
    void Start()
    {
        //a posição da bola - a camera.
        distance = ballTransform.position - transform.position;
        distance += new Vector3(0, -0.2f * StaticValues.cameraRotation.x / 2, -0.18f * StaticValues.cameraRotation.x / 2);
        transform.Rotate(StaticValues.cameraRotation);

       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (transform.rotation.eulerAngles.x >= 0 && transform.rotation.eulerAngles.x <= 87)
            {
                distance += new Vector3(0, -0.2f, -0.12f);
                transform.Rotate(new Vector3(2, 0, 0));
                StaticValues.cameraRotation += new Vector3(2, 0, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (transform.rotation.eulerAngles.x >= 1 && transform.rotation.eulerAngles.x <= 89)
            {
                distance += new Vector3(0, 0.2f, 0.12f);
                transform.Rotate(new Vector3(-2, 0, 0));
                StaticValues.cameraRotation += new Vector3(-2, 0, 0);
            }
        }

     
    }
    void LateUpdate()
    {
        if (GameObject.Find("Player").GetComponent<Player>().gameOver == false)
        {
            FollowCamera();
        }
    }


    //***************Metodos
    void FollowCamera()
    {
      
        pos = transform.position;
        targetPos = ballTransform.position - distance;
        pos = Vector3.Lerp(pos, targetPos, lerpValue);
        transform.position = pos;
    }

   
}
