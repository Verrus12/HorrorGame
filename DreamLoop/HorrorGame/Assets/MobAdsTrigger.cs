using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobAdsTrigger : MonoBehaviour
{
   public MobAdsSimple mobAdsSimple;

   private void OnTriggerEnter2D(Collider2D other) {
       if(other.tag == "Player")
       {
           mobAdsSimple.ShowAd();
       }
   }
}
