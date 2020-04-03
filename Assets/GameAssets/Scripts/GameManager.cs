using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int lives = 3;
    public int score = 0;
    public int highScore = 0;

    private int _level = 0;
    public int level
    {
        get => _level; set
        {
            SceneManager.LoadSceneAsync(value);
            _level = value;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }

    public void Quite()
    {
        Application.Quit();
    }

}
