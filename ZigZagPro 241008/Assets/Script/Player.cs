using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script;
using BayatGames.SaveGameFree;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public float playerSpeed, iceWalk, iceWalkAdd, playerImpulseAdd;
    [HideInInspector]
    public bool canJump, gameOver;
    [HideInInspector]
    public string LastDirection;
    public int reverseX = 1, reverseZ = 1;
    public Rigidbody rb;
    [HideInInspector]
    public int coins, floorPlayered = 0, difficulty = 0;
    [HideInInspector]
    public bool hitting, magnectField, shield, stomped;
    // [HideInInspector]
    public float finalSpeed, playerImpulse;
    RaycastHit hitData;
    Ray myRay;
    public bool started;
    public bool alreadySaved;
    public Image PUPShieldIcon, PUPMagneticIcon, PUPSlowIcon;

    private void Awake()
    {
        iceWalk = 0;
        rb = GetComponent<Rigidbody>();
        coins = 0;
        difficulty = 1;
    }
    void Start()
    {
        started = false;
        alreadySaved = false;
        canJump = true;
        LastDirection = "Right";
        magnectField = false;
        shield = false;
        rb.useGravity = false;
        PUPShieldIcon.fillAmount = 0;
        PUPMagneticIcon.fillAmount = 0;
        PUPSlowIcon.fillAmount = 0;
    }

    void Update()
    {
        if (started == false)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                started = true;
                rb.velocity = new Vector3(playerSpeed, 0, 0);
                StartCoroutine(SpeedUp());
                rb.useGravity = true;
                GameObject.Find("Canva_Controller").GetComponent<CanvaController>().startCanva.GetComponent<Canvas>().enabled = false;
            }
        }
        else
        {
            AutoSave();
            myRay = new Ray(transform.position, Vector3.down);
            hitting = Physics.Raycast(myRay, out hitData, 2f);
            if (hitData.collider != null && (hitData.collider.name == "IceFloor(Clone)"))
            {
                iceWalk = iceWalkAdd;
            }
            else
            {
                iceWalk = 0.0f;
            }

            if (gameOver == false && canJump == true)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow) && Mathf.Abs(rb.velocity.x) > 0.1f)
                {
                    rb.velocity = new Vector3(iceWalk * rb.velocity.x, 0, playerSpeed * reverseZ);
                    if (reverseZ == 1) { LastDirection = "Up"; }
                    if (reverseZ == -1) { LastDirection = "Down"; }
                }
                if (Input.GetKeyDown(KeyCode.DownArrow) && Mathf.Abs(rb.velocity.x) > 0.1f)
                {
                    rb.velocity = new Vector3(iceWalk * rb.velocity.x, 0, -playerSpeed * reverseZ);
                    if (reverseZ == 1) { LastDirection = "Down"; }
                    if (reverseZ == -1) { LastDirection = "Up"; }
                }
                if (Input.GetKeyDown(KeyCode.RightArrow) && Mathf.Abs(rb.velocity.z) > 0.1f)
                {
                    rb.velocity = new Vector3(playerSpeed * reverseX, 0, iceWalk * rb.velocity.z);
                    if (reverseX == 1) { LastDirection = "Right"; }
                    if (reverseX == -1) { LastDirection = "Left"; }
                }
                if (Input.GetKeyDown(KeyCode.LeftArrow) && Mathf.Abs(rb.velocity.z) > 0.1f)
                {
                    rb.velocity = new Vector3(-playerSpeed * reverseX, 0, iceWalk * rb.velocity.z);
                    if (reverseX == 1) { LastDirection = "Left"; }
                    if (reverseX == -1) { LastDirection = "Right"; }
                }

                MoveBall();
                //Jump
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    AudioMannager.Instance.PlayFX(AudioMannager.Instance.JumpFX);

                }

                if (Input.GetKey(KeyCode.Space))
                {
                    playerImpulse += playerImpulseAdd;
                    if (playerImpulse < 4.3f)
                    {
                        rb.velocity = new Vector3(rb.velocity.x, playerImpulse, rb.velocity.z);
                    }
                    else
                    {
                        canJump = false;
                        playerImpulse = 0;
                    }
                }

                if (Input.GetKeyUp(KeyCode.Space))
                {
                    playerImpulse = 0;
                    canJump = false;
                }

            }
            if (gameOver == false && canJump == false)
            {
                if (Input.GetKeyDown(KeyCode.LeftControl))
                {
                    rb.velocity = new Vector3(rb.velocity.x, -5, rb.velocity.z);
                }
            }
            if (transform.position.y < -1)
            {
                gameOver = true;
                finalSpeed = playerSpeed;
            }
            if (gameOver == true)
            {
                int higScore = Mathf.RoundToInt((coins / 10) * floorPlayered);
                higScore = higScore * 10;
                GameObject.Find("Canva_Controller").GetComponent<CanvaController>().higScore.text = "HighScore: " + higScore.ToString();
                GameObject.Find("Canva_Controller").GetComponent<CanvaController>().gameOver.GetComponent<Canvas>().enabled = true;
            }
            //Aumenta a dificuldade
            if (floorPlayered >= difficulty * 15)
            {
                AudioMannager.Instance.PlayFX(AudioMannager.Instance.AddDificultyFX);
                AudioMannager.Instance.musicAudioSource.pitch += 0.0025f;
                difficulty++;
            }
        }

    }
    //***********Métodos*************************
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Floor"))
        {
            canJump = true;
            reverseX = 1;
            reverseZ = 1;
        }
        if (collision.transform.CompareTag("ReverseX"))
        {
            canJump = true;
            reverseX = -1;
            reverseZ = 1;
        }
        if (collision.transform.CompareTag("ReverseZ"))
        {
            canJump = true;
            reverseX = 1;
            reverseZ = -1;
        }
    }
    private void OnCollisionExit(Collision collision)
    {

        if (collision.transform.CompareTag("ReverseX"))
        {
            canJump = true;
            reverseX = 1;
            reverseZ = 1;
        }
        if (collision.transform.CompareTag("ReverseZ"))
        {
            canJump = true;
            reverseX = 1;
            reverseZ = 1;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            AudioMannager.Instance.PlayFX(AudioMannager.Instance.CoinFX);
            Instantiate(other.GetComponent<Coin>().explosionFX, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            coins++;
        }
        if (other.CompareTag("RedCoin"))
        {
            AudioMannager.Instance.PlayFX(AudioMannager.Instance.RedCoinFX);
            Instantiate(other.GetComponent<RedCoin>().explosionFX, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            coins += 5;
        }
        if (other.CompareTag("PUPSlowDown"))
        {
            AudioMannager.Instance.PlayFX(AudioMannager.Instance.CoinFX);
            Time.timeScale = 0.5f;
            StartCoroutine(RestoreTime());
            StartCoroutine(PUPIcon("SlowIcon"));
            Destroy(other.gameObject);
        }
        if (other.CompareTag("PUPMagnetic"))
        {
            AudioMannager.Instance.PlayFX(AudioMannager.Instance.RedCoinFX);
            magnectField = true;
            StartCoroutine(RestoreMagnetic());
            StartCoroutine(PUPIcon("MagneticIcon"));
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Shield"))
        {
            AudioMannager.Instance.PlayFX(AudioMannager.Instance.RedCoinFX);
            shield = true;
            StartCoroutine(PUPIcon("ShieldIcon"));
            Destroy(other.gameObject);
        }
    }

    public void MoveBall()
    {
        if (LastDirection == "Up")
        {
            rb.velocity = new Vector3(iceWalk * rb.velocity.x, rb.velocity.y, playerSpeed);
        }
        if (LastDirection == "Down")
        {
            rb.velocity = new Vector3(iceWalk * rb.velocity.x, rb.velocity.y, -playerSpeed);
        }
        if (LastDirection == "Right")
        {
            rb.velocity = new Vector3(playerSpeed, rb.velocity.y, iceWalk * rb.velocity.z);
        }
        if (LastDirection == "Left")
        {
            rb.velocity = new Vector3(-playerSpeed, rb.velocity.y, iceWalk * rb.velocity.z);
        }
    }
    public void AutoSave()
    {
        int higScore = Mathf.RoundToInt((coins / 10) * floorPlayered);
        higScore = higScore * 10;

        if (gameOver == true && alreadySaved == false)
        {
            GameObject.Find("Loader").GetComponent<LoadShopItens>().playerData.dicCoins[StaticValues.PlayerRef] += coins;
            if (coins >= 250)
            {
                GameObject.Find("Loader").GetComponent<LoadShopItens>().playerData.coinAchivement[StaticValues.PlayerRef] = true;
            }
            if (higScore > GameObject.Find("Loader").GetComponent<LoadShopItens>().playerData.dicHighScore[StaticValues.PlayerRef])
            {
                GameObject.Find("Loader").GetComponent<LoadShopItens>().playerData.dicHighScore[StaticValues.PlayerRef] = higScore;
            }
            SaveGame.Save<PlayerData>(StaticValues.saveLocation, GameObject.Find("Loader").GetComponent<LoadShopItens>().playerData);

            alreadySaved = true;
        }
    }
    //****************************Rotinas***********************
    IEnumerator SpeedUp()
    {
        if (GameObject.Find("Controller").GetComponent<FloorMaker>().gameMode == 0)
        {
            while (playerSpeed < 8.2f && !gameOver)
            {
                yield return new WaitForSeconds(2f);
                if (!gameOver)
                {
                    playerSpeed += 0.1f;
                }
                else
                {
                    finalSpeed = playerSpeed;
                    break;
                }
            }
        }
        else if (GameObject.Find("Controller").GetComponent<FloorMaker>().gameMode == 1)
        {
            while (playerSpeed < 12.2f && !gameOver)
            {
                yield return new WaitForSeconds(2f);
                if (!gameOver)
                {
                    playerSpeed += 0.2f;
                }
                else
                {
                    finalSpeed = playerSpeed;
                    break;
                }
            }
        }
    }
    IEnumerator RestoreTime()
    {
        yield return new WaitForSeconds(3f);
        Time.timeScale = 1;
    }
    IEnumerator RestoreMagnetic()
    {
        yield return new WaitForSeconds(10);
        magnectField = false;
    }

    IEnumerator PUPIcon(string PUP)
    {
        if (PUP == "ShieldIcon")
        {
            PUPShieldIcon.fillAmount = 1;
        }

        if (PUP == "MagneticIcon")
        {
            PUPMagneticIcon.fillAmount = 1;
            for (int i = 200; i >= 0; i--)
            {
                yield return new WaitForSeconds(0.05f);//10:200
                PUPMagneticIcon.fillAmount -= 0.005f;//1:200
            }
        }

        if (PUP == "SlowIcon")
        {
            PUPSlowIcon.fillAmount = 1;
            for (int i = 200; i >= 0; i--)
            {
                yield return new WaitForSeconds(0.015f);//3:200
                PUPSlowIcon.fillAmount -= 0.005f;//1:200
            }
        }
    }
}
