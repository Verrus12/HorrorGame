using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoundManager : MonoBehaviour
{
    public AudioSource enemyWalkSound;
    public AudioSource enemyWalkSound2;
    public AudioSource playerDeathSound;
    public AudioSource idleSound;
    public GameObject AgressiveSound;

    public void EnemyWalkSound()
    {
        enemyWalkSound.Play();
    }
    public void EnemyWalkSound2()
    {
        enemyWalkSound2.Play();
    }
     public void PlayerDeathSound()
    {
        playerDeathSound.Play();
    }
    public void IdleSound()
    {
        idleSound.Play();
    }   
    public void EnemyAgressiveStateSound()
    {
        AgressiveSound.SetActive(true);
    }
}
