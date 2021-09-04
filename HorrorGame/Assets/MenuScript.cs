using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
   
    public void LanguageMenu()
    {
        SceneManager.LoadScene(1);
    }
    

    public void NewGame()
    {
        SceneManager.LoadScene(2);
    }
     public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}