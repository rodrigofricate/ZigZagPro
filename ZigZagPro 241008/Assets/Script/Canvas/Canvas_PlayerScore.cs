using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas_PlayerScore : MonoBehaviour
{
   public Text coinTxt, timerTxt, speedTxt, difficultyTxt, playerNameTXT;
    


    // Update is called once per frame
    void Update()
    {
        coinTxt.text = GameObject.Find("Player").GetComponent<Player>().coins.ToString();
        speedTxt.text = (GameObject.Find("Player").GetComponent<Player>().playerSpeed-2.4f).ToString("0.0");
        difficultyTxt.text = GameObject.Find("Player").GetComponent<Player>().difficulty.ToString();
    }
}
