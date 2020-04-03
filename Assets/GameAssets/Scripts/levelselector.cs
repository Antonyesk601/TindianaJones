using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelselector : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        Scene num =SceneManager.GetActiveScene();
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.UnloadSceneAsync(num.buildIndex);
            SceneManager.LoadScene(num.buildIndex, LoadSceneMode.Single);
        }
        if (Input.GetKey(KeyCode.N))
        {
            SceneManager.UnloadSceneAsync(num.buildIndex);
            SceneManager.LoadScene(num.buildIndex+1, LoadSceneMode.Single);
        }
        if (Input.GetKey(KeyCode.P))
        {
            if (num.buildIndex != 0)
            {
                SceneManager.UnloadSceneAsync(num.buildIndex);
                SceneManager.LoadScene(num.buildIndex - 1, LoadSceneMode.Single);
            }
            else
            {
                SceneManager.UnloadSceneAsync(num.buildIndex);
                SceneManager.LoadScene(SceneManager.sceneCount - 1, LoadSceneMode.Single);
            }
        }
    }
    
}
