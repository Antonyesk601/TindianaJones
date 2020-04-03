using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapGenerator : MonoBehaviour
{
    public Grid grid;
    public List<Tilemap> Environment = new List<Tilemap>();
    public int levelWidth;
    public int levelheight;
    public float[] maxLevelHeight;
    public float[] maxLevelWidth;
    public float[] platformlength;
    public Tile main;
    public Tile bg;
    public Tile bgn;
    int previousheight;
    public GameObject player;
    public List<tilemapdata> tilelocations = new List<tilemapdata>();
    int environmentidentifier;
    float environemntchance;

    void Start()
    {

        levelWidth = Mathf.CeilToInt(Random.Range(maxLevelWidth[0], maxLevelWidth[1]));
        generateplatform(levelheight, levelWidth);
        generateplatformnd(levelheight, levelWidth);
        generatebackground(Mathf.CeilToInt(maxLevelWidth[1]), Mathf.CeilToInt(maxLevelHeight[1]));
    }

    void generateplatform(int height, int width)
    {
       
        for (int i = 0; i < width; i++)
        {
            var result = Random.Range(0, 2) * 2 - 1;
             environemntchance = Random.Range(0f, 100f);
            if(environemntchance<33.3)
            {
                environmentidentifier = 1;
            }
            else if (environemntchance >=33.3f&& environemntchance < 66.6f)
            {
                environmentidentifier = 0;
            }
            else if(environemntchance >= 66.6f)
            {
                environmentidentifier = 2;
            }
            if (previousheight == 0)
            {

                levelheight = Mathf.CeilToInt(Random.Range(maxLevelHeight[0], maxLevelHeight[1]));
                height = levelheight;
                Environment[environmentidentifier].SetTile(new Vector3Int(i, height, Mathf.CeilToInt(gameObject.transform.position.z)), main);
                tilelocations.Add(new tilemapdata { xCoordinates= i,yCoordinates=height});
                previousheight = height;
                if (i == 0)
                {
                    player.transform.position = new Vector3Int(i + Mathf.CeilToInt(player.transform.localScale.x / 2), height + Mathf.CeilToInt(player.transform.localScale.x / 2), Mathf.CeilToInt(gameObject.transform.position.z));
                }

            }

            else
            {
                int platform = Mathf.FloorToInt(Random.Range(platformlength[0], platformlength[1]));
                for (int n = 0; n < platform; n++)
                {
                    Environment[environmentidentifier].SetTile(new Vector3Int(n + i, previousheight, Mathf.CeilToInt(gameObject.transform.position.z)), main);
                    tilelocations.Add(new tilemapdata { xCoordinates = i,yCoordinates = height});
    }
                i = i + platform;
                previousheight = 0;
            }
            float environmentchanceoffset = environemntchance - result*Random.Range(0f,height); 
        }

    }
    void generateplatformnd(int height, int width)
    {
        environemntchance = Random.Range(0f, 100f);
        if (environemntchance >= 50)
        {
            environmentidentifier = 1;
        }
        else
        {
            environmentidentifier = 0;
        }
        for (int i = 0; i < width; i++)
        {
            Debug.Log(tilelocations[i].xCoordinates+" "+tilelocations[i].yCoordinates);
            levelheight = Mathf.CeilToInt(Random.Range(maxLevelHeight[0], maxLevelHeight[1]));
            if (Mathf.Abs(levelheight - (tilelocations[i].yCoordinates)) > 2)
            {
                if (previousheight == 0)
                {

                    height = levelheight;
                    Environment[environmentidentifier].SetTile(new Vector3Int(i, height, Mathf.CeilToInt(gameObject.transform.position.z)), main);
                    previousheight = height;
                    if (i == 0)
                    {
                        player.transform.position = new Vector3Int(i + Mathf.CeilToInt(player.transform.localScale.x / 2), height + Mathf.CeilToInt(player.transform.localScale.x / 2), Mathf.CeilToInt(gameObject.transform.position.z));
                    }

                }

                else
                {
                    
                    int platform = Mathf.FloorToInt(Random.Range(platformlength[0], platformlength[1]));
                    for (int n = 0; n < platform; n++)
                    {
                        Environment[environmentidentifier].SetTile(new Vector3Int(n + i, previousheight, Mathf.CeilToInt(gameObject.transform.position.z)), main);
                    }
                    i = i + platform;
                    previousheight = 0;
                }
            }

            else
            {
                height = Mathf.CeilToInt(Random.Range(Mathf.Abs(levelheight - tilelocations[i].yCoordinates), Mathf.CeilToInt(Mathf.Abs(levelheight + tilelocations[i].yCoordinates))));
                Environment[environmentidentifier].SetTile(new Vector3Int(i, height, Mathf.CeilToInt(gameObject.transform.position.z)), main);
            }
        }
    }
        void generateramp()
        {

        }
        void generatebackground(int width, int height)
        {
            for (int i = 0; i < height; i++)
            {
                for (int n = 0; n < width; n++)
                    if ((n + i) % 2 == 0)
                    {
                        Environment[1].SetTile(new Vector3Int(n, i, 0), bg);
                    }
                    else
                    {
                        Environment[1].SetTile(new Vector3Int(n, i, 0), bgn);

                    }
            }
        }
    }

