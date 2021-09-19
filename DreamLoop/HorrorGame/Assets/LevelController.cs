using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public static LevelController instance = null;
    int sceneIndex;
    int levelComplete;

    private void Start() {
        if(instance == null)
        {
            instance = this;
        }
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        levelComplete = PlayerPrefs.GetInt("LevelComplete");
    }

    public void isEndGame()
    {
        if(sceneIndex == 6)
        {
            Invoke("LoadMainMenu", 1f);
        }
        else
        {
            if(levelComplete < sceneIndex)
                PlayerPrefs.SetInt("LevelComplete", sceneIndex);
            Invoke("NextLevel", 1f);
        }
    }

    void NextLevel()
    {
        SceneManager.LoadScene(sceneIndex +1);
    }
    void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
