using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Script;


public class CanvaController : MonoBehaviour
{
    public Canvas gameOver, canvaHelp, canvaHelpB, startCanva;
    bool helper;
    public Text  higScore;
    
    // Start is called before the first frame update

    private void Awake()
    {
       
        helper = false;

        gameOver.GetComponent<Canvas>().enabled = false;
        canvaHelp.GetComponent<Canvas>().enabled = false;
        canvaHelpB.GetComponent<Canvas>().enabled = false;
        startCanva.GetComponent<Canvas>().enabled = true;
    }

 
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GameObject.Find("Player").GetComponent<Player>().gameOver == true)
        {
            RetryButton();
        }
      if (Input.GetKeyDown(KeyCode.RightControl)&& helper==false)
        {
            
            PauseButton();
        }

    }

    //*********************Métodos**********************
    public void PauseButton()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;

        }
        else
        {
            Time.timeScale = 1;
        }
    }
    public void RetryButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainGame", LoadSceneMode.Single);
    }
    public void QuitGame()
    {
        StaticValues.perfectReturn = true;
        SceneManager.LoadScene("StartScreen", LoadSceneMode.Single);
    }

    public void NextHelp()
    {
        canvaHelp.GetComponent<Canvas>().enabled = false;
        canvaHelpB.GetComponent<Canvas>().enabled = true;
    }
    public void LastHelp()
    {
        canvaHelp.GetComponent<Canvas>().enabled = true;
        canvaHelpB.GetComponent<Canvas>().enabled = false;
    }
    public void OpenHelp()
    {
        if (Time.timeScale == 1)
        {
            PauseButton();
            canvaHelp.GetComponent<Canvas>().enabled = true;
            helper = true;
        }
    }
    public void CloseHelp()
    {
        canvaHelp.GetComponent<Canvas>().enabled = false;
        canvaHelpB.GetComponent<Canvas>().enabled = false;
        PauseButton();
        helper = false;
    }
}
