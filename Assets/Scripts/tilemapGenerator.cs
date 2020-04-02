using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapGenerator : MonoBehaviour
{
    [SerializeField]
    private Grid grid;
    [SerializeField]
    private List<Tilemap> Environment= new List<Tilemap>();
    [SerializeField]
    private int levelWidth;
    [SerializeField]
    private int levelheight;
    [SerializeField]
    private Tile main;


    void Start()
    {
        generateplatform(levelheight,levelWidth);
        
    }

    void generateplatform(int height, int width)
    {
        Environment[0].BoxFill(new Vector3Int(0, 0, 0), main, 0, 0, width, height); 
    }
}
