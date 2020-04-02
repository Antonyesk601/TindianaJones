using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class tilemapGenerator : MonoBehaviour
{
    public Grid grid;
    public List<Tilemap> Environment= new List<Tilemap>();
    public int levelWidth;
    public int levelheight;
    public float[] maxLevelHeight;
    public float[] maxLevelWidth;
    public Tile main;
    // Start is called before the first frame update
    void Start()
    {
        levelWidth =Mathf.CeilToInt(Random.Range(maxLevelWidth[0], maxLevelWidth[1]));
        generateplatform(levelheight,levelWidth);
        
    }
    void generateplatform(int height, int width)
    {
        for (int i=0; i< width; i++)
        {
            levelheight= Mathf.CeilToInt(Random.Range(maxLevelHeight[0], maxLevelHeight[1]));
            Environment[0].SetTile(new Vector3Int(i, height, Mathf.CeilToInt(gameObject.transform.position.z)), main);
        }
    }
    
}
