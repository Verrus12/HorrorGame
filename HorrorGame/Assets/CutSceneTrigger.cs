using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneTrigger : MonoBehaviour
{
    public GameObject TimeLineManager;



    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            TimeLineManager.SetActive(true);
        }
    }
}
