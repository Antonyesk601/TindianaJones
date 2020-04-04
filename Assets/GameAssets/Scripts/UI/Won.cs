using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Won : MonoBehaviour
{
    public int nextLevelNumber;

    private GameManager gm;

    void Start()
    {
        gm = GameManager.Instance;
    }

    public void goToLevel()
    {
        gm.level = nextLevelNumber;
    }

    public void ResetLives()
    {
        gm.level = nextLevelNumber;
        gm.score = 0;
        gm.lives = 3;
    }
}
