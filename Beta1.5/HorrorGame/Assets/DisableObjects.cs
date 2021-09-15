using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObjects : MonoBehaviour
{
    public GameObject DO1;
    public GameObject DO2;
    public GameObject DO3;
    public GameObject DO4;
    public GameObject DO5;
    public GameObject DO6;


    public GameObject EO1;
    public GameObject EO2;
    public GameObject EO3;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            EO1.SetActive(true);
            EO2.SetActive(true);
            EO3.SetActive(true);
            DO1.SetActive(false);
            DO2.SetActive(false);
            DO3.SetActive(false);
            DO4.SetActive(false);
            DO5.SetActive(false);
            DO6.SetActive(false);
        }
    }
}
