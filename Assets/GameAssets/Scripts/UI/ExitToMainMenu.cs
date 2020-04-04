using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitToMainMenu : MonoBehaviour
{
    public void MainMenu()
    {
        GameManager.Instance.level = 0;
        GameManager.Instance.lives = 3;
        GameManager.Instance.score = 0;
        GameManager.Instance.whips = 2;
    }
}
