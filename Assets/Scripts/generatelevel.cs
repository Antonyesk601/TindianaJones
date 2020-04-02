using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generatelevel : MonoBehaviour
{
    public List<GameObject> environmentSprites = new List<GameObject>();
    public float length;
    public float width;
    void Start()
    {
        generateWalls();
    }
    void generateWalls()
    {
        float walllength = environmentSprites[0].GetComponent<SpriteRenderer>().sprite.rect.width / 100;
        float unitlength = length / walllength;
        float unitwidth = width / walllength;
        List<GameObject> walls = new List<GameObject>();
        for (int i = 0; i <= 3; i++)
        {
            walls.Add(new GameObject());
        }
        walls[0].transform.position = new Vector2(gameObject.transform.position.x - unitwidth, gameObject.transform.position.y - unitlength);
        walls[3].transform.position = new Vector2(gameObject.transform.position.x + unitwidth -walllength, gameObject.transform.position.y - unitlength);
        walls[2].transform.position = new Vector2(gameObject.transform.position.x - unitwidth, gameObject.transform.position.y - unitlength);
        walls[1].transform.position = new Vector2(gameObject.transform.position.x - unitwidth, gameObject.transform.position.y + unitlength - width / length * walllength);
        for (int i = 0; i <= 3; i++)
        {
            if (i < 2)
            {
                for (int n = 0; n <= length; n++)
                {
                    GameObject wallpiece = new GameObject();
                    wallpiece.transform.SetParent(walls[i].transform);
                    wallpiece.AddComponent<SpriteRenderer>();
                    wallpiece.GetComponent<SpriteRenderer>().sprite = environmentSprites[0].GetComponent<SpriteRenderer>().sprite;

                    wallpiece.transform.localPosition = new Vector2(n * walllength, 0);
                }
                
            }
            if (i >= 2)
            {
            for (int n = 0; n <= width; n++)
                    {
                        GameObject wallpiece = new GameObject();
                        wallpiece.transform.SetParent(walls[i].transform);
                        wallpiece.AddComponent<SpriteRenderer>();
                        wallpiece.GetComponent<SpriteRenderer>().sprite = environmentSprites[0].GetComponent<SpriteRenderer>().sprite;

                        wallpiece.transform.localPosition = new Vector2(n * walllength, 0);

                        wallpiece.transform.localPosition = new Vector2(0, n * walllength);
                    }
            }
        }

    }
}