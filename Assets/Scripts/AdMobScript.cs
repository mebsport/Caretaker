﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System;
using GoogleMobileAds.Api;

public class AdMobScript : MonoBehaviour
{

    string App_ID = "ca-app-pub-1205664286750936~2523202317";

    //Ad ID's (TEST ID'S)
    string Banner_Ad_ID = "ca-app-pub-3940256099942544/6300978111";
    string Interstitial_Ad_ID = "ca-app-pub-3940256099942544/1033173712";
    string Rewarded_Ad_ID = "ca-app-pub-3940256099942544/5224354917";

    private BannerView bannerView;
    private InterstitialAd interstitial;
    private RewardBasedVideoAd rewardBasedVideo;

    public Text adStatus;


    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(App_ID);
    }

    public void RequestBanner()
    {

        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(Banner_Ad_ID, AdSize.Banner, AdPosition.Bottom);

        // Called when an ad request has successfully loaded.
        this.bannerView.OnAdLoaded += this.HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.bannerView.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;
        // Called when an ad is clicked.
        this.bannerView.OnAdOpening += this.HandleOnAdOpened;
        // Called when the user returned from the app after an ad click.
        this.bannerView.OnAdClosed += this.HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.bannerView.OnAdLeavingApplication += this.HandleOnAdLeavingApplication;
    }

    public void ShowBannerAd()
    {
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);

    }

    public void RequestInterstitialAd()
    {
        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(Interstitial_Ad_ID);

        // Called when an ad request has successfully loaded.
        this.interstitial.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        this.interstitial.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;

        AdRequest request = new AdRequest.Builder().Build();
        this.interstitial.LoadAd(request);
    }

    public void ShowInterstitialAd()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
    }

    public void RequestRewardedBasedVideo()
    {
        rewardBasedVideo = RewardBasedVideoAd.Instance;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded video ad with the request.
        this.rewardBasedVideo.LoadAd(request, Rewarded_Ad_ID);
    }

    public void ShowVideoRewardAd()
    {
        if (rewardBasedVideo.IsLoaded())
        {
            rewardBasedVideo.Show();
        }

    }

    //EVENTS AND DELEGAETS FOR ADS

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        adStatus.text = "AD Loaded";

        //MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        adStatus.text = "Ad Failed To Load";
        
        //MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                            //+ args.Message);
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }


}
