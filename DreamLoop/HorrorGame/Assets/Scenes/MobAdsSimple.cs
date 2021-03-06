using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class MobAdsSimple : MonoBehaviour
{
    private InterstitialAd interstitialAd;

#if UNITY_ANDROID
    private const string interstitialUnitId = "ca-app-pub-8363350638806517/3267220886";
#elif UNITY_IPHONE
    private const string interstitialUnitId = "";
#else
    private const string interstitialUnitId = "unexpected_platform";
#endif
    void OnEnable()
    {
        interstitialAd = new InterstitialAd(interstitialUnitId);
        AdRequest adRequest = new AdRequest.Builder().Build();
        interstitialAd.LoadAd(adRequest);
    }

    public void ShowAd()
    {
        if (interstitialAd.IsLoaded())
        {
            interstitialAd.Show();
        }
    }
}
