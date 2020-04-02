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
    public Tile main;
    // Start is called before the first frame update
    void Start()
    {
        generateplatform(levelheight,levelWidth);
        
    }
    void generateplatform(int height, int width)
    {
        Environment[0].BoxFill(new Vector3Int(0, 0, 0), main, 0, 0, width, height); 
    }
    
}
