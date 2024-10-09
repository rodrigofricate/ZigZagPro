using UnityEngine;
using Assets.Script;
using BayatGames.SaveGameFree;
using UnityEngine.UI;


public class LoadShopItens : MonoBehaviour
{
    // Start is called before the first frame update
    public Material[] arraySkyBox = new Material[5];
    public Material[] arrayPlayerSkin = new Material[6];
    public PlayerData playerData = new PlayerData();
    [SerializeField] Text playerName;
    private void Awake()
    {
        //Bypass SaveSysten require have one profile named as Andre
        if (StaticValues.PlayerRef == null)
        {
            StaticValues.PlayerRef = "Rodrigo";
        }
 
        playerData = SaveGame.Load<PlayerData>(StaticValues.saveLocation);

     


    }
    void Start()
    {
        LoadItems();
        Debug.Log(gameObject.name);
    }

    // Update is called once per frame

    public void LoadItems()
    {
        //SkyBox
        for (int i = 0; i < arraySkyBox.Length; i++)
        {
            if (playerData.dicPlayerBuy[StaticValues.PlayerRef].arraySkybox[i] == 2)
            {
                if (i < 4)
                {
                    GameObject.Find("Main Camera").GetComponent<Skybox>().material = arraySkyBox[i];
                }
                else
                {
                    int randomSky = Random.Range(0, 4);
                    while (playerData.dicPlayerBuy[StaticValues.PlayerRef].arraySkybox[randomSky] < 1)
                    {
                       randomSky = Random.Range(0, 4);
                    }
                    GameObject.Find("Main Camera").GetComponent<Skybox>().material = arraySkyBox[randomSky];
                }
            }
        }

        //sound
        for (int i = 0; i < AudioMannager.Instance.arraySound.Length; i++)
        {
            if (playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayMusic[i] == 2)
            {
                if (i < 6)
                {
                    AudioMannager.Instance.PlayMusic(i);
                   // GameObject.Find("Main Camera").GetComponent<AudioSource>().clip = arraySound[i];
                }
                else
                {
                    int randomSong = Random.Range(0, 6);
                    while (playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayMusic[randomSong] < 1)
                    {
                        randomSong = Random.Range(0, 6);
                    }
                    AudioMannager.Instance.PlayMusic(randomSong);
                   // GameObject.Find("Main Camera").GetComponent<AudioSource>().clip = arraySound[randomSong];
                }

            }
        }
       // GameObject.Find("Main Camera").GetComponent<AudioSource>().Play();

        //skin
        for (int i = 0; i < arrayPlayerSkin.Length; i++)
        {
            if (playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayBallTexture[i] == 2)
            {
                if (i < 5)
                {
                    GameObject.Find("Player").GetComponent<Renderer>().material = arrayPlayerSkin[i];
                }
                else
                {
                    int randomSkin = Random.Range(0, 5);
                    while (playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayBallTexture[randomSkin] < 1)
                    {
                       randomSkin = Random.Range(0, 5);
                    }
                    GameObject.Find("Player").GetComponent<Renderer>().material = arrayPlayerSkin[randomSkin];
                }
            }

        }
        playerName.text = playerData.dicPlayerName[StaticValues.PlayerRef];

    }
}
