using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BayatGames.SaveGameFree;
using Assets.Script;
using UnityEngine.SceneManagement;
using UnityEngine.Video;


public class CanvaControllerStartScreen : MonoBehaviour
{ 
    [SerializeField] GameObject canvaOptions;
    [SerializeField] GameObject canAssignement;
    public Canvas startScreen, profileMaker, profileScreen, canvasHelp, canvasHelpB;
    public Text btt_text_dinamicProfile, playername, higscore;
    public Button bttDelete;
    public Dropdown profileList;
    public InputField profileName;
    PlayerData playerData = new PlayerData();
    bool createOrLoad;
    [SerializeField] VideoPlayer mainVideo;
    private void Awake()
    {
        Login();
    }

    void Update()
    {
        //implement player name and score
        if (StaticValues.PlayerRef != null)
        {
            if (playerData.dicPlayerName.ContainsKey(StaticValues.PlayerRef))
            {
                playername.text = playerData.dicPlayerName[StaticValues.PlayerRef];
            }
            if (playerData.dicHighScore.ContainsKey(StaticValues.PlayerRef))
            {
                higscore.text = "HighScore: " + playerData.dicHighScore[StaticValues.PlayerRef].ToString();
            }
        }
        if (profileList.captionText.text == "Create New Profile")
        {
            btt_text_dinamicProfile.text = "Create";
            bttDelete.interactable = false;
            createOrLoad = true;
        }
        else
        {
            btt_text_dinamicProfile.text = "Load";
            bttDelete.interactable = true;
            createOrLoad = false;
        }

        mainVideo.SetDirectAudioVolume(0, StaticOptions.MasterVolume);
        
    }
    public void CreateButton()
    {
        if (createOrLoad == true)
        {
            profileScreen.GetComponent<Canvas>().enabled = false;
            profileMaker.GetComponent<Canvas>().enabled = true;
        }
        else
        {
            StaticValues.PlayerRef = profileList.captionText.text;
            startScreen.GetComponent<Canvas>().enabled = true;
            profileMaker.GetComponent<Canvas>().enabled = false;
            profileScreen.GetComponent<Canvas>().enabled = false;
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void SaveProfile()
    {
        if (playerData.dicPlayerName.ContainsKey(profileName.text))
        {
            Debug.Log("Este save já existe");
        }
        else
        {
            StaticValues.PlayerRef = profileName.text;
            PlayerBuy playerBuy = new PlayerBuy();
            playerData.dicPlayerName.Add(profileName.text, profileName.text);
            playerData.dicCoins.Add(profileName.text, 0);
            playerData.dicPlayerBuy.Add(profileName.text, playerBuy);
            playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayBallTexture[0] = 2;
            playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayMusic[0] = 2;
            playerData.dicPlayerBuy[StaticValues.PlayerRef].arraySkybox[0] = 2;
            playerData.dicHighScore[StaticValues.PlayerRef] = 0;
            playerData.coinAchivement[StaticValues.PlayerRef] = false;
            SaveGame.Save<PlayerData>(StaticValues.saveLocation, playerData);

            startScreen.GetComponent<Canvas>().enabled = true;
            profileMaker.GetComponent<Canvas>().enabled = false;
            profileScreen.GetComponent<Canvas>().enabled = false;
        }

    }

    public void RemoveProfile()
    {

        if (playerData.dicPlayerName.ContainsKey(profileList.captionText.text))
        {
            playerData.dicPlayerName.Remove(profileList.captionText.text);
            playerData.dicCoins.Remove(profileList.captionText.text);
            playerData.dicPlayerBuy.Remove(profileList.captionText.text);
            playerData.coinAchivement.Remove(profileList.captionText.text);
            playerData.dicHighScore.Remove(profileList.captionText.text);
            profileList.ClearOptions();

            List<string> temString = new List<string>();
            temString.Add("Create New Profile");
            foreach (string obj in playerData.dicPlayerName.Values)
            {
                temString.Add(obj);
            }
            profileList.AddOptions(temString);
        }
        else
        {
            Debug.Log("Chave Inexistente");
        }

        SaveGame.Save<PlayerData>(StaticValues.saveLocation, playerData);
    }

    public void NormalMode()
    {
        StaticValues.gameMode = 0;
        SceneManager.LoadScene("MainGame", LoadSceneMode.Single);
    }
    public void ShopMode()
    {
        SceneManager.LoadScene("Shop", LoadSceneMode.Single);
    }
    public void RaceMode()
    {
        StaticValues.gameMode = 1;
        SceneManager.LoadScene("MainGame", LoadSceneMode.Single);
    }
    public void Login()
    {
        profileScreen.GetComponent<Canvas>().enabled = true;
        startScreen.GetComponent<Canvas>().enabled = false;
        profileMaker.GetComponent<Canvas>().enabled = false;
        canvasHelp.GetComponent<Canvas>().enabled = false;
        canvasHelpB.GetComponent<Canvas>().enabled = false;
        DisableAssignement();
      canvaOptions.SetActive(false);

        playerData = SaveGame.Load<PlayerData>(StaticValues.saveLocation);

        if (playerData == null)
        {
            playerData = new PlayerData();
        }
        else
        {
            int lastUser = profileList.value;
            profileList.ClearOptions();
            List<string> temString = new List<string>();
            temString.Add("Create New Profile");
            foreach (string obj in playerData.dicPlayerName.Values)
            {
                temString.Add(obj);
            }
            profileList.AddOptions(temString);
            profileList.value = lastUser;
        }
        if (StaticValues.perfectReturn == true)
        {
            GameObject.Find("CanvaController").GetComponent<CanvaControllerStartScreen>().startScreen.GetComponent<Canvas>().enabled = true;
            GameObject.Find("CanvaController").GetComponent<CanvaControllerStartScreen>().profileMaker.GetComponent<Canvas>().enabled = false;
            GameObject.Find("CanvaController").GetComponent<CanvaControllerStartScreen>().profileScreen.GetComponent<Canvas>().enabled = false;
            StaticValues.perfectReturn = false;
        }

    }
    public void NextHelp()
    {
        canvasHelp.GetComponent<Canvas>().enabled = false;
        canvasHelpB.GetComponent<Canvas>().enabled = true;
    }
    public void LastHelp()
    {
        canvasHelp.GetComponent<Canvas>().enabled = true;
        canvasHelpB.GetComponent<Canvas>().enabled = false;
    }
    public void OpenHelp()
    {
        canvasHelp.GetComponent<Canvas>().enabled = true;
    }
    public void CloseHelp()
    {
        canvasHelp.GetComponent<Canvas>().enabled = false;
        canvasHelpB.GetComponent<Canvas>().enabled = false;
    }

    public void EnableAssignement()
    {
        canAssignement.SetActive(true);
    }
    public void DisableAssignement()
    {
        canAssignement.SetActive(false);
    }
}
