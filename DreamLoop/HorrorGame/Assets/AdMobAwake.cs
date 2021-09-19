using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdMobAwake : MonoBehaviour
{
    private MobAdsSimple m_mobAdsSimple;
     
    private void Awake() {
        m_mobAdsSimple = GetComponent<MobAdsSimple>();
        m_mobAdsSimple.ShowAd();
    }
}
