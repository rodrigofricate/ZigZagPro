using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BayatGames.SaveGameFree;
using Assets.Script;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class CanvasShopController : MonoBehaviour
{
    public Text txtCoins, txtLabelExplain;
    public InputField passWordField;
    //Txts de icons
    // public Text txtRedCoin, txtMagneton, txtSlowTime, txtShield;
    PlayerData playerData = new PlayerData();
    public Button[] bttPowerUpArrays = new Button[4];
    public Button[] bttMusicArrays = new Button[7];
    public Button[] bttAkyBoxArrays = new Button[5];
    public Button[] bttPlayerSkinsArrays = new Button[6];

    public Text[] txtPricePowerUp = new Text[4];
    public Text[] txtPriceMusic = new Text[7];
    public Text[] txtPriceSkyBox = new Text[5];
    public Text[] txtPricePlayerSkin = new Text[6];

    public int[] PowerUpPrice = new int[4];
    public int[] MusicPrice = new int[7];
    public int[] SkyBoxPrice = new int[5];
    public int[] PlayerSkinPrice = new int[6];


    private void Awake()
    {
      
        playerData = SaveGame.Load<PlayerData>(StaticValues.saveLocation);
        RemoveNullOfArray();
        ChargeVallues();
    }
    // Start is called before the first frame update
    void Start()
    {
        AudioMannager.Instance.PlayMusic(AudioMannager.Instance.ShopAudio);
    }

    // Update is called once per frame
    void Update()
    {


        txtCoins.text = "X " + playerData.dicCoins[StaticValues.PlayerRef].ToString();
        LoadTextButtons();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayBallTexture[0] += 1;
            playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayMusic[0] += 1;
            playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayPowerUp[0] += 1;
            playerData.dicPlayerBuy[StaticValues.PlayerRef].arraySkybox[0] += 1;
        }

    }




    //*************************METODOS**************************    

    public void Password()
    {
       if(passWordField.text == "sugardaddy" || passWordField.text == "money" )
        {
            playerData.dicCoins[StaticValues.PlayerRef] += 40000;
            txtLabelExplain.text = "Congratulations you received 40K";
        }
       if(passWordField.text == "sugarbaby")
        {
            playerData.coinAchivement[StaticValues.PlayerRef] = true;
            txtLabelExplain.text = "You unlocked Player Skin Random";
        }
       if(passWordField.text == "welovethisgame")
        {
            if (playerData.dicHighScore[StaticValues.PlayerRef] < 30000)
            {
                playerData.dicHighScore[StaticValues.PlayerRef] = 30000;
               
            }
            txtLabelExplain.text = "You unlocked Sky Random";
        }
        passWordField.text = "";
        SaveGame.Save<PlayerData>(StaticValues.saveLocation, playerData);
    }
    public void RemoveNullOfArray()
    {
        for (int i = 0; i < playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayBallTexture.Length; i++)
        {
            if (playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayBallTexture[i] == null)
            {
                playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayBallTexture[i] = 0;
            }

        }
        for (int i = 0; i < playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayMusic.Length; i++)
        {
            if (playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayMusic[i] == null)
            {
                playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayMusic[i] = 0;
            }
        }
        for (int i = 0; i < playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayPowerUp.Length; i++)
        {
            if (playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayPowerUp[i] == null)
            {
                playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayPowerUp[i] = 0;
            }
        }
        for (int i = 0; i < playerData.dicPlayerBuy[StaticValues.PlayerRef].arraySkybox.Length; i++)
        {
            if (playerData.dicPlayerBuy[StaticValues.PlayerRef].arraySkybox[i] == null)
            {
                playerData.dicPlayerBuy[StaticValues.PlayerRef].arraySkybox[i] = 0;
            }
        }
    }
    public void ChargeVallues()
    {
        for (int i = 0; i < txtPricePowerUp.Length; i++)
        {
            txtPricePowerUp[i].text = PowerUpPrice[i].ToString();
        }
        for (int i = 0; i < txtPriceMusic.Length; i++)
        {
            txtPriceMusic[i].text = MusicPrice[i].ToString();
        }
        txtPriceMusic[0].text = "Free";
        txtPriceMusic[6].text = "Locked";
        for (int i = 0; i < txtPriceSkyBox.Length; i++)
        {
            txtPriceSkyBox[i].text = SkyBoxPrice[i].ToString();
        }
        txtPriceSkyBox[0].text = "Free";
        txtPriceSkyBox[4].text = "Locked";
        for (int i = 0; i < txtPricePlayerSkin.Length; i++)
        {
            txtPricePlayerSkin[i].text = PlayerSkinPrice[i].ToString();
        }
        txtPricePlayerSkin[0].text = "Free";
        txtPricePlayerSkin[5].text = "Locked";
    }

    public void LoadTextButtons()
    {
        for (int i = 0; i < playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayBallTexture.Length; i++)
        {
            if (playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayBallTexture[i] == 0)
            {
                bttPlayerSkinsArrays[i].GetComponentInChildren<Text>().text = "Buy";
                if (PlayerSkinPrice[i] > playerData.dicCoins[StaticValues.PlayerRef])
                {
                    bttPlayerSkinsArrays[i].interactable = false;
                }
            }
            else if (playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayBallTexture[i] == 1)
            {
                bttPlayerSkinsArrays[i].GetComponentInChildren<Text>().text = "Select";
                bttPlayerSkinsArrays[i].interactable = true;
            }
            else
            {
                bttPlayerSkinsArrays[i].GetComponentInChildren<Text>().text = "OK!!!";
                bttPlayerSkinsArrays[i].interactable = true;
            }


        }
        //Achivement
        if (playerData.coinAchivement[StaticValues.PlayerRef] == true)
        {
            if (playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayBallTexture[5] == 0)
            {
                playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayBallTexture[5] = 1;
            }
           
        }
     

        for (int i = 0; i < playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayMusic.Length; i++)
        {
            if (playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayMusic[i] == 0)
            {
                bttMusicArrays[i].GetComponentInChildren<Text>().text = "Buy";
                if (MusicPrice[i] > playerData.dicCoins[StaticValues.PlayerRef])
                {
                    bttMusicArrays[i].interactable = false;
                }
            }
            else if (playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayMusic[i] == 1)
            {
                bttMusicArrays[i].GetComponentInChildren<Text>().text = "Select";
                bttMusicArrays[i].interactable = true;
            }
            else
            {
                bttMusicArrays[i].GetComponentInChildren<Text>().text = "OK!!!";
                bttMusicArrays[i].interactable = true;
            }
        }
        //Music Achivement
        int tempCount=0;
        for(int i = 0; i < (playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayMusic.Length-1); i++)
        {
            if (playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayMusic[i] > 0)
            {
                tempCount++;
            }
        }
        if (tempCount >= 6)
        {
            if (playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayMusic[6] == 0)
            {
                playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayMusic[6] = 1;
            }
        }

   
        for (int i = 0; i < playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayPowerUp.Length; i++)
        {
            if (playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayPowerUp[i] == 0)
            {
                bttPowerUpArrays[i].GetComponentInChildren<Text>().text = "Buy";
                if (PowerUpPrice[i] > playerData.dicCoins[StaticValues.PlayerRef])
                {
                    bttPowerUpArrays[i].interactable = false;
                }
            }
            else if (playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayPowerUp[i] == 1)
            {
                bttPowerUpArrays[i].GetComponentInChildren<Text>().text = "Select";
                bttPowerUpArrays[i].interactable = true;
            }
            else
            {
                bttPowerUpArrays[i].GetComponentInChildren<Text>().text = "OK!!!";
                bttPowerUpArrays[i].interactable = true;
            }
        }
        // Achivment PowerUp

        for (int i = 0; i < playerData.dicPlayerBuy[StaticValues.PlayerRef].arraySkybox.Length; i++)
        {
            if (playerData.dicPlayerBuy[StaticValues.PlayerRef].arraySkybox[i] == 0)
            {
                bttAkyBoxArrays[i].GetComponentInChildren<Text>().text = "Buy";
                if (SkyBoxPrice[i] > playerData.dicCoins[StaticValues.PlayerRef])
                {
                    bttAkyBoxArrays[i].interactable = false;
                }
            }
            else if (playerData.dicPlayerBuy[StaticValues.PlayerRef].arraySkybox[i] == 1)
            {
                bttAkyBoxArrays[i].GetComponentInChildren<Text>().text = "Select";
                bttAkyBoxArrays[i].interactable = true;
            }
            else
            {
                bttAkyBoxArrays[i].GetComponentInChildren<Text>().text = "OK!!!";
                bttAkyBoxArrays[i].interactable = true;
            }
        }
        //AchivementSkybox
        if (playerData.dicHighScore[StaticValues.PlayerRef] >= 30000)
        {
            if (playerData.dicPlayerBuy[StaticValues.PlayerRef].arraySkybox[4] == 0)
            {
                playerData.dicPlayerBuy[StaticValues.PlayerRef].arraySkybox[4] = 1;
            }
        }
    }

    //Metodos de botões on Click

    public void BackToStart()
    {
        StaticValues.perfectReturn = true;
        SceneManager.LoadScene("StartScreen", LoadSceneMode.Single);
        
     
        //ADD aqui o que será salvo!!!
    }

    public void BuySetSave()
    {
        string targetName = EventSystem.current.currentSelectedGameObject.name;

        for (int i = 0; i < bttPowerUpArrays.Length; i++)
        {
            if (bttPowerUpArrays[i].name == targetName && playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayPowerUp[i] == 0)
            {

                playerData.dicCoins[StaticValues.PlayerRef] -= PowerUpPrice[i];
                playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayPowerUp[i] = 1;
               
            }
            else if (bttPowerUpArrays[i].name == targetName && playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayPowerUp[i] == 1)
            {

           
                playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayPowerUp[i] = 2;
            }
        }

        for (int i = 0; i < bttMusicArrays.Length; i++)
        {
            if (bttMusicArrays[i].name == targetName && playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayMusic[i] == 0)
            {

                playerData.dicCoins[StaticValues.PlayerRef] -= MusicPrice[i];
                playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayMusic[i] = 1;

            }
            else if (bttMusicArrays[i].name == targetName && playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayMusic[i] == 1)
            {
                for (int j = 0; j < playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayMusic.Length; j++)
                {

                    if (playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayMusic[j] == 2)
                    {
                        playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayMusic[j] = 1;
                    }
                }
                playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayMusic[i] = 2;
            }
        }

        for (int i = 0; i < bttAkyBoxArrays.Length; i++)
        {
            if (bttAkyBoxArrays[i].name == targetName && playerData.dicPlayerBuy[StaticValues.PlayerRef].arraySkybox[i] == 0)
            {
                playerData.dicCoins[StaticValues.PlayerRef] -= SkyBoxPrice[i];
                playerData.dicPlayerBuy[StaticValues.PlayerRef].arraySkybox[i] = 1;
            }
            else if (bttAkyBoxArrays[i].name == targetName && playerData.dicPlayerBuy[StaticValues.PlayerRef].arraySkybox[i] == 1)
            {
                for (int j = 0; j < playerData.dicPlayerBuy[StaticValues.PlayerRef].arraySkybox.Length; j++)
                {

                    if (playerData.dicPlayerBuy[StaticValues.PlayerRef].arraySkybox[j] == 2)
                    {
                        playerData.dicPlayerBuy[StaticValues.PlayerRef].arraySkybox[j] = 1;
                    }
                }
                playerData.dicPlayerBuy[StaticValues.PlayerRef].arraySkybox[i] = 2;
            }
          
        }

        for (int i = 0; i < bttPlayerSkinsArrays.Length; i++)
        {
            if (bttPlayerSkinsArrays[i].name == targetName && playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayBallTexture[i] == 0)
            {
                playerData.dicCoins[StaticValues.PlayerRef] -= PlayerSkinPrice[i];
                playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayBallTexture[i] = 1;
            }
            else if (bttPlayerSkinsArrays[i].name == targetName && playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayBallTexture[i] == 1)
            {
                for (int j = 0; j < playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayBallTexture.Length; j++)
                {

                    if (playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayBallTexture[j] == 2)
                    {
                        playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayBallTexture[j] = 1;
                    }
                }
                playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayBallTexture[i] = 2;
            }

        }
        SaveGame.Save<PlayerData>(StaticValues.saveLocation, playerData);
    }

    //Metodos de Labels
    public void ExitMouse()
    {
        txtLabelExplain.text = "";
    }
    public void LabelRedCoin()
    {
        txtLabelExplain.text = "Make Red Coins randonly appear in your course, one Red Coin is equal to 5 coins";
    }
    public void LabelSlowTime()
    {
        txtLabelExplain.text = "Make a Slow Time Power randonly appear in your course";
    }
    public void LabelMagnetic()
    {
        txtLabelExplain.text = "Make appear a Magnetic Power acapable to attract coins, randonly appear in your course";
    }
    public void LabelShield()
    {
        txtLabelExplain.text = "Make appear a Shield alround you acapable to save you from one hit, randonly appear in your course";
    }
    public void LabelSunnySky()
    {
        txtLabelExplain.text = "Make a Sunny sky on your course";
    }
    public void LabelSunsetSky()
    {
        txtLabelExplain.text = "Make a Sunset sky on your course";
    }
    public void LabelNigthSky()
    {
        txtLabelExplain.text = "Make a Night sky on your course";
    }
    public void LabelRainy()
    {
        txtLabelExplain.text = "Make a Rainy sky on your course";
    }
    public void LabelRandomSky()
    {
        if (playerData.dicPlayerBuy[StaticValues.PlayerRef].arraySkybox[4] < 1)
        {
            txtLabelExplain.text = "have a score great then 30000 to unlock";
        }
        else
        {
            txtLabelExplain.text = "Make a Random sky on your course";
        }
    }
    public void LabelNewSong()
    {
        txtLabelExplain.text = "Free this song to use during your course";
    }
    public void LabelRandSong()
    {
        if (playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayMusic[6] < 1)
        {
            txtLabelExplain.text = "buy all the other songs in list to unlock";
        }
        else
        {
            txtLabelExplain.text = "Randomly your songs to use during your course";
        }
    }
    public void LabelSkin()
    {
        txtLabelExplain.text = "Free this skin to use during your course";
    }
    public void LabelRandSkin()
    {
        if (playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayBallTexture[5] < 1)
        {
            txtLabelExplain.text = "collect 250 coins or more in a single run to unlock";
        }
        else
        {
            txtLabelExplain.text = "Randomly your skins to use during your course";
        }
    }


}
