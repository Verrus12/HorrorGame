using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoNotDestroyOnLoad : MonoBehaviour
{
    private Scene scene;

    private void Awake() {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");
        if( musicObj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    private void Update() {
        scene = SceneManager.GetActiveScene();

        if (scene.name == "1")
        {
            Debug.Log("1");
            Destroy(this.gameObject);
        }
    }
}
