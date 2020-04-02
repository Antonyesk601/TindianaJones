using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapGenerator : MonoBehaviour
{
    public Grid grid;
    public List<Tilemap> Environment= new List<Tilemap>();
    public int levelWidth;
    public int levelheight;
    public float[] maxLevelHeight;
    public float[] maxLevelWidth;
    public int[] platformlength;
    public Tile main;

    void Start()
    {
        levelWidth =Mathf.CeilToInt(Random.Range(maxLevelWidth[0], maxLevelWidth[1]));
        generateplatform(levelheight,levelWidth);
    }

    void generateplatform(int height, int width)
    {
        int previousheight;
        for (int i=0; i< width; i++)
        {
            levelheight= Mathf.CeilToInt(Random.Range(maxLevelHeight[0], maxLevelHeight[1]));
            
            height = levelheight;
            Environment[0].SetTile(new Vector3Int(i, height, Mathf.CeilToInt(gameObject.transform.position.z)), main);
        }
    }
}
