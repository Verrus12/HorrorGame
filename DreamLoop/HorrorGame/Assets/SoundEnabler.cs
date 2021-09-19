using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEnabler : MonoBehaviour
{
    public AudioSource SE1;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            SE1.Play();
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
