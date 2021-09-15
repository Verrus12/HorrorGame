using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{
    public AudioSource playerWalkSound;
    public AudioSource playerWalkSound2;
    public AudioSource playerHideInBedSound;
    public AudioSource playerHideInWardrobe;
    public AudioSource playerDeath;

    public void PlayerWalkSound()
    {
        playerWalkSound.Play();
    }
    public void PlayerWalkSound2()
    {
        playerWalkSound2.Play();
    }
     public void PlayerHideInBedSound()
    {
        playerHideInBedSound.Play();
    }
     public void PlayerHideInWardrobe()
    {
        playerHideInWardrobe.Play();
    }
}
