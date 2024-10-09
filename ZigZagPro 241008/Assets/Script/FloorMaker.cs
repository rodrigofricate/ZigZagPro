using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script;
using BayatGames.SaveGameFree;


public class FloorMaker : MonoBehaviour
{
    
    public Transform initFloor;
    public GameObject[] Floor, powerUps, loadCoin;
    public int floorQtt = 0, sort, randomize = 0, lastFloor_1 = 0, lastFloor_2 = 0, gameMode;
    float scaleFloor, rotateDir;
    Vector3 lastPosition;
    bool gameOver;
    Vector3 posA, posB, posC;
    private int floorDifficulty, fakeluck = 0, floorTypes;
    [HideInInspector]

    private void Awake()
    {
        gameMode = StaticValues.gameMode;
        //Bypass SaveSysten require have one profile named as Andre
        if (StaticValues.PlayerRef == null)
        {
            StaticValues.PlayerRef = "Rodrigo";
        }
    }
    void Start()
    {
        if (GameObject.Find("Loader").GetComponent<LoadShopItens>().playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayPowerUp[0] == 2)
        {
            powerUps[1] = loadCoin[1];
        }
        else
        {
            powerUps[1] = loadCoin[0];
        }
        if (GameObject.Find("Loader").GetComponent<LoadShopItens>().playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayPowerUp[1] == 2)
        {
            powerUps[2] = loadCoin[2];
        }
        else
        {
            powerUps[2] = loadCoin[0];
        }
        if (GameObject.Find("Loader").GetComponent<LoadShopItens>().playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayPowerUp[2] == 2)
        {
            powerUps[3] = loadCoin[3];
        }
        else
        {
            powerUps[3] = loadCoin[0];
        }
        if (GameObject.Find("Loader").GetComponent<LoadShopItens>().playerData.dicPlayerBuy[StaticValues.PlayerRef].arrayPowerUp[3] == 2)
        {
            powerUps[4] = loadCoin[4];
        }
        else
        {
            powerUps[4] = loadCoin[0];
        }
        scaleFloor = initFloor.localScale.x;
        lastPosition = initFloor.transform.position;
        StartCoroutine(CreateFloor());
        floorTypes = Floor.GetLength(0);

    }

    // Update is called once per frame
    void Update()
    {
        floorDifficulty = GameObject.Find("Player").GetComponent<Player>().difficulty;
        sort = Random.Range(1, 7);
        if(GameObject.Find("Canva_Controller").GetComponent<CanvaController>().startCanva.GetComponent<Canvas>().enabled == true && GameObject.Find("Player").GetComponent<Player>().started == true)
        {
            GameObject.Find("Canva_Controller").GetComponent<CanvaController>().startCanva.GetComponent<Canvas>().enabled = false;
        }

    }

    IEnumerator CreateFloor()
    {

        while (gameOver == false)
        {

            yield return new WaitForSeconds(0.002f);//0.2f
            if (floorQtt <= 25)
            {

                randomize = SortFloor(Random.Range(1, 101));
                if (Floor[randomize].name == "BarrierFloor_X")
                {
                    rotateDir = Barrier();
                    while (Floor[randomize].name == "HighFloor" || Floor[randomize].name == "BarrierFloor_X")
                    {
                        randomize = SortFloor(Random.Range(1, 101));
                    }
                }
                else
                {
                    rotateDir = RotateDir(Random.Range(0, 11));
                }
                if (Floor[lastFloor_2].name == "HighFloor" && Floor[randomize].name == "HighFloor")
                {
                    while (Floor[randomize].name == "HighFloor" || Floor[randomize].name == "BarrierFloor_X")
                    {
                        randomize = SortFloor(Random.Range(1, 101));
                    }
                }
                Instantiate(Floor[randomize], lastPosition, Quaternion.Euler(0, rotateDir, 0));
                lastFloor_2 = lastFloor_1;
                lastFloor_1 = randomize;
                CoinSort(sort, randomize, posA, posB, posC);


                floorQtt++;
            }
        }

    }
    private float Zigzag()
    {
        if (fakeluck == 0)
        {
            lastPosition.x += scaleFloor;
            fakeluck = 1;
            return 90f;
        }
        else
        {
            lastPosition.z += scaleFloor;
            fakeluck = 0;
            return 0;
        }
    }

    public int SortFloor(int randomized)
    {
        if (floorDifficulty == 1)
        {
            return 0;
        }
        if (floorDifficulty == 2)
        {
            if (randomized <= 80)
            {
                return 0;
            }
            if (randomized > 80 && randomized <= 90)
            {
                return 2;
            }
            if (randomized > 90 && randomized <= 95)
            {
                return 3;
            }
            if (randomized > 95)
            {
                return 8;
            }
        }
        if (floorDifficulty == 3)
        {
            if (randomized <= 60)
            {
                return 0;
            }
            if (randomized > 60 && randomized <= 70)
            {
                return 2;
            }
            if (randomized > 70 && randomized <= 80)
            {
                return 3;
            }
            if (randomized > 80 && randomized <= 90)
            {
                return 5;
            }
            if (randomized > 90)
            {
                return 8;
            }
        }
        if (floorDifficulty == 4)
        {
            if (randomized <= 50)
            {
                return 0;
            }
            if (randomized > 50 && randomized <= 60)
            {
                return 2;
            }
            if (randomized > 60 && randomized <= 70)
            {
                return 3;
            }
            if (randomized > 70 && randomized <= 80)
            {
                return 5;
            }
            if (randomized > 80 && randomized <= 90)
            {
                return 4;
            }
            if (randomized > 90)
            {
                return 8;
            }

        }
        if (floorDifficulty == 5)
        {
            if (randomized <= 50)
            {
                return 0;
            }
            if (randomized > 50 && randomized <= 55)
            {
                return 2;
            }
            if (randomized > 55 && randomized <= 60)
            {
                return 3;
            }
            if (randomized > 60 && randomized <= 70)
            {
                return 4;
            }
            if (randomized > 70 && randomized <= 80)
            {
                return 5;
            }
            if (randomized > 80 && randomized <= 90)
            {
                return 7;
            }
            if (randomized > 90)
            {
                return 8;
            }

        }
        if (floorDifficulty == 6)
        {
            if (randomized <= 40)
            {
                return 0;
            }
            if (randomized > 40 && randomized <= 45)
            {
                return 2;
            }
            if (randomized > 45 && randomized <= 50)
            {
                return 3;
            }
            if (randomized > 50 && randomized <= 60)
            {
                return 4;
            }
            if (randomized > 60 && randomized <= 70)
            {
                return 5;
            }
            if (randomized > 70 && randomized <= 75)
            {
                return 6;
            }
            if (randomized > 75 && randomized <= 80)
            {
                return 9;
            }
            if (randomized > 80 && randomized <= 90)
            {
                return 7;
            }
            if (randomized > 90)
            {
                return 8;
            }

        }
        if (floorDifficulty == 7)
        {
            if (randomized <= 40)
            {
                return 0;
            }
            if (randomized > 40 && randomized <= 50)
            {
                return 1;
            }
            if (randomized > 50 && randomized <= 55)
            {
                return 2;
            }
            if (randomized > 55 && randomized <= 60)
            {
                return 3;
            }
            if (randomized > 60 && randomized <= 65)
            {
                return 4;
            }
            if (randomized > 65 && randomized <= 70)
            {
                return 5;
            }
            if (randomized > 70 && randomized <= 75)
            {
                return 2;
            }
            if (randomized > 75 && randomized <= 80)
            {
                return 6;
            }
            if (randomized > 80 && randomized <= 85)
            {
                return 9;
            }
            if (randomized > 85 && randomized <= 90)
            {
                return 7;
            }
            if (randomized > 90)
            {
                return 8;
            }

        }
        if (floorDifficulty == 8)
        {
            if (randomized <= 30)
            {
                return 0;
            }
            if (randomized > 30 && randomized <= 40)
            {
                return 1;
            }
            if (randomized > 40 && randomized <= 45)
            {
                return 2;
            }
            if (randomized > 45 && randomized <= 50)
            {
                return 3;
            }
            if (randomized > 50 && randomized <= 60)
            {
                return 4;
            }
            if (randomized > 60 && randomized <= 65)
            {
                return 5;
            }
            if (randomized > 65 && randomized <= 75)
            {
                return 1;
            }
            if (randomized > 75 && randomized <= 80)
            {
                return 6;
            }
            if (randomized > 80 && randomized <= 85)
            {
                return 9;
            }
            if (randomized > 85 && randomized <= 90)
            {
                return 7;
            }
            if (randomized > 90)
            {
                return 8;
            }

        }
        if (floorDifficulty == 9)
        {
            if (randomized <= 30)
            {
                return 0;
            }
            if (randomized > 30 && randomized <= 45)
            {
                return 1;
            }
            if (randomized > 45 && randomized <= 50)
            {
                return 2;
            }
            if (randomized > 50 && randomized <= 55)
            {
                return 3;
            }
            if (randomized > 55 && randomized <= 60)
            {
                return 4;
            }
            if (randomized > 60 && randomized <= 65)
            {
                return 5;
            }
            if (randomized > 65 && randomized <= 70)
            {
                return 7;
            }
            if (randomized > 70 && randomized <= 75)
            {
                return 6;
            }
            if (randomized > 75 && randomized <= 80)
            {
                return 9;
            }
            if (randomized > 80 && randomized <= 90)
            {
                return 7;
            }
            if (randomized > 90)
            {
                return 8;
            }

        }
        if (floorDifficulty == 10)
        {
            if (randomized <= 20)
            {
                return 0;
            }
            if (randomized > 20 && randomized <= 40)
            {
                return 1;
            }
            if (randomized > 40 && randomized <= 45)
            {
                return 2;
            }
            if (randomized > 45 && randomized <= 50)
            {
                return 3;
            }
            if (randomized > 50 && randomized <= 55)
            {
                return 4;
            }
            if (randomized > 55 && randomized <= 60)
            {
                return 5;
            }
            if (randomized > 60 && randomized <= 67)
            {
                return 6;
            }
            if (randomized > 68 && randomized <= 75)
            {
                return 9;
            }
            if (randomized > 75 && randomized <= 90)
            {
                return 7;
            }
            if (randomized > 90)
            {
                return 8;
            }

        }

        return 0;
    }
    public void CoinSort(int sort, int randomized, Vector3 posA, Vector3 posB, Vector3 posC)
    {

        int coinNumber = Random.Range(1, 13);
        int coinRandomize = Random.Range(1, 101);
        if (sort == 1)
        {

            posA = new Vector3(-1, 0.5f, -1);
            posB = new Vector3(0, 0.5f, -1);
            posC = new Vector3(1, 0.5f, -1);
        }
        if (sort == 2)
        {

            posA = new Vector3(-1, 0.5f, 0);
            posB = new Vector3(0, 0.5f, 0);
            posC = new Vector3(1, 0.5f, 0);
        }
        if (sort == 3)
        {

            posA = new Vector3(-1, 0.5f, 1);
            posB = new Vector3(0, 0.5f, 1);
            posC = new Vector3(1, 0.5f, 1);
        }
        if (sort == 4)
        {

            posA = new Vector3(-1, 0.5f, -1);
            posB = new Vector3(-1, 0.5f, 0);
            posC = new Vector3(-1, 0.5f, 1);
        }
        if (sort == 5)
        {

            posA = new Vector3(0, 0.5f, -1);
            posB = new Vector3(0, 0.5f, 0);
            posC = new Vector3(0, 0.5f, 1);

        }
        if (sort == 6)
        {

            posA = new Vector3(1, 0.5f, -1);
            posB = new Vector3(1, 0.5f, 0);
            posC = new Vector3(1, 0.5f, 1);
        }
        if (randomized == 2)
        {
            posA += new Vector3(0, 0.62f, 0);
            posB += new Vector3(0, 0.62f, 0);
            posC += new Vector3(0, 0.62f, 0);
        }
        if (coinNumber > 0 && coinNumber <= 4)
        {
            if (coinRandomize <= 90)
            {
                Instantiate(powerUps[0], (lastPosition + posA), Quaternion.Euler(90, 0, 90));
            }
            if (coinRandomize > 90 && coinRandomize <= 94)
            {
                Instantiate(powerUps[1], (lastPosition + posA), Quaternion.Euler(90, 0, 90));
            }
            if (coinRandomize > 94 && coinRandomize <= 96)
            {
                Instantiate(powerUps[2], (lastPosition + posA), Quaternion.Euler(90, 0, 90));
            }
            if (coinRandomize > 96 && coinRandomize <= 98)
            {
                Instantiate(powerUps[3], (lastPosition + posA), Quaternion.Euler(90, 0, 90));
            }
            if (coinRandomize > 98)
            {
                Instantiate(powerUps[4], (lastPosition + posA), Quaternion.Euler(90, 0, 90));
            }

        }
        if (coinNumber > 4 && coinNumber < 8)
        {
            Instantiate(powerUps[0], (lastPosition + posA), Quaternion.Euler(90, 0, 90));

            //Instantiate(coin, (lastPosition + posB), Quaternion.Euler(90, 0, 90));

            if (coinRandomize <= 90)
            {
                Instantiate(powerUps[0], (lastPosition + posB), Quaternion.Euler(90, 0, 90));
            }
            if (coinRandomize > 90 && coinRandomize <= 94)
            {
                Instantiate(powerUps[1], (lastPosition + posB), Quaternion.Euler(90, 0, 90));
            }
            if (coinRandomize > 94 && coinRandomize <= 96)
            {
                Instantiate(powerUps[2], (lastPosition + posB), Quaternion.Euler(90, 0, 90));
            }
            if (coinRandomize > 96 && coinRandomize <= 98)
            {
                Instantiate(powerUps[3], (lastPosition + posB), Quaternion.Euler(90, 0, 90));
            }
            if (coinRandomize > 98)
            {
                Instantiate(powerUps[4], (lastPosition + posB), Quaternion.Euler(90, 0, 90));
            }
        }
        if (coinNumber >= 8)
        {
            Instantiate(powerUps[0], (lastPosition + posA), Quaternion.Euler(90, 0, 90));
            Instantiate(powerUps[0], (lastPosition + posB), Quaternion.Euler(90, 0, 90));


            if (coinRandomize <= 90)
            {
                Instantiate(powerUps[0], (lastPosition + posC), Quaternion.Euler(90, 0, 90));
            }
            if (coinRandomize > 90 && coinRandomize <= 94)
            {
                Instantiate(powerUps[1], (lastPosition + posC), Quaternion.Euler(90, 0, 90));
            }
            if (coinRandomize > 94 && coinRandomize <= 96)
            {
                Instantiate(powerUps[2], (lastPosition + posC), Quaternion.Euler(90, 0, 90));
            }
            if (coinRandomize > 96 && coinRandomize <= 98)
            {
                Instantiate(powerUps[3], (lastPosition + posC), Quaternion.Euler(90, 0, 90));
            }
            if (coinRandomize > 98)
            {
                Instantiate(powerUps[4], (lastPosition + posC), Quaternion.Euler(90, 0, 90));
            }
        }

    }

    private float RotateDir(int luck)
    {
        if (gameMode == 0)//random
        {
            return LuckRotate(luck);
        }
        if (gameMode == 1)//lineX
        {
            return LuckRotate(5);
        }
        if (gameMode == 2)//lineZ
        {
            return LuckRotate(8);
        }
        if (gameMode == 3)//Zigzag
        {
            return Zigzag();
        }
        return 0;
    }
    private float LuckRotate(int luck)
    {
        if (luck <= 5)
        {
            lastPosition.x += scaleFloor;
            return 90f;
        }
        else
        {
            lastPosition.z += scaleFloor;
            return 0;
        }
    }
    public float Barrier()
    {
        float rotateDirNext = RotateDir(Random.Range(1, 11));
        if (rotateDirNext == 0)
        {
            Instantiate(Floor[8], lastPosition, Quaternion.Euler(0, 0f, 0));
            lastPosition.z += scaleFloor;
        }
        else
        {
        Instantiate(Floor[8], lastPosition, Quaternion.Euler(0, 90f, 0));
           
            lastPosition.x += scaleFloor;
        }
        return rotateDirNext;
    }

}
