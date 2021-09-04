using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameSwitch : MonoBehaviour
{
    public GameObject activeFrame;
    public GameObject lastFrameEdge;
    public GameObject ObjectsToDisable;
    public GameObject ObjectsToEnable;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            activeFrame.SetActive(true);
            lastFrameEdge.SetActive(false);
            ObjectsToDisable.SetActive(false);
            ObjectsToEnable.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            activeFrame.SetActive(false);
        }
    }
}
