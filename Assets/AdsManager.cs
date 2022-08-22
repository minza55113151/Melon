using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using System;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    public static AdsManager instance;
#if UNITY_IOS
        string gameId = "4895856";
        string[] adsName = {"Interstitial_iOS", "Rewarded_iOS", "Banner_iOS"}; 
#else
    string gameId = "4895857";
    string[] adsName = { "Interstitial_Android", "Rewarded_Android", "Banner_Android" };
#endif

    private Action onRewardedAdsSuccess;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        Advertisement.Initialize(gameId);
        Advertisement.AddListener(this);
    }
    public void PlayAd()
    {
        if (Advertisement.IsReady(adsName[0]))
        {
            Advertisement.Show(adsName[0]);
        }
    }
    public void PlayRewardedAd(Action onSuccess)
    {
        if (Advertisement.IsReady(adsName[1]))
        {
            onRewardedAdsSuccess = onSuccess;
            Advertisement.Show(adsName[1]);
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
    }

    public void OnUnityAdsDidError(string message)
    {
    }

    public void OnUnityAdsDidStart(string placementId)
    {
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (placementId == adsName[1] && showResult == ShowResult.Finished)
        {
            onRewardedAdsSuccess.Invoke();
        }
    }
}
