using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitToMainMenu : MonoBehaviour
{
    public void MainMenu()
    {
        GameManager.Instance.level = 0;
    }
}
