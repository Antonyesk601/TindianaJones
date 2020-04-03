using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { 
        get { 
            if(instance == null)
            {
                var gameObject = new GameObject("GameManager", typeof(GameManager));
                instance = gameObject.GetComponent<GameManager>();
            }

            return instance;
        } 
        private set => instance = value; 
    }

    public int lives = 3;
    public int score = 0;
    public int highScore = 0;
    public int whips = 0;

    private int _level = 0;
    private static GameManager instance;

    public int level
    {
        get => _level; set
        {
            SceneManager.LoadSceneAsync(value);
            _level = value;
        }
    }

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
