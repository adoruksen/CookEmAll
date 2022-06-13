using System.Collections;
using System.Collections.Generic;
using com.adjust.sdk;
using Facebook.Unity;
using GameAnalyticsSDK;
using LionStudios.Suite.Analytics;
using UnityEngine;

public class Initialize : MonoBehaviour
{
    public static Initialize instance;

    void Awake()
    {
        instance = this;

        if (!FB.IsInitialized)
        {
            // Initialize the Facebook SDK
            FB.Init(InitCallback, OnHideUnity);
        }
        else
        {
            // Already initialized, signal an app activation App Event
            FB.ActivateApp();
        }

        GameAnalytics.Initialize();
    }

    // Start is called before the first frame update
    void Start()
    {
        GameAnalytics.Initialize();
        InitializeMax();
        InitializeAdjust();
    }

    private void InitializeMax()
    {
        MaxSdkCallbacks.OnSdkInitializedEvent += (MaxSdkBase.SdkConfiguration sdkConfiguration) =>
        {
            // AppLovin SDK is initialized, start loading ads
        };

        MaxSdk.SetSdkKey("yarZ5900aW8JRXCxm1FnZSCHq4HV5nzeF7V4RslMdUPAuskH04Pbrbh4HvBr_wqMBPuUlK7yBcqh9avDwcTeDc");
        MaxSdk.SetUserId(SystemInfo.deviceUniqueIdentifier);
        MaxSdk.SetVerboseLogging(true);
        MaxSdk.InitializeSdk();
       // MaxSdk.ShowMediationDebugger();
    }

    private void InitializeAdjust()
    {
        // import this package into the project:
        // https://github.com/adjust/unity_sdk/releases
#if UNITY_IOS
        /* Mandatory - set your iOS app token here */
        InitAdjust("YOUR_IOS_APP_TOKEN_HERE");
#elif UNITY_ANDROID
        /* Mandatory - set your Android app token here */
        InitAdjust("wfiudmr26s5c");
#endif
    }

    private void InitAdjust(string adjustAppToken)
    {
        var adjustConfig = new AdjustConfig(
            adjustAppToken,
            AdjustEnvironment.Production, // AdjustEnvironment.Sandbox to test in dashboard
            true
        );
        adjustConfig.setLogLevel(AdjustLogLevel.Info); // AdjustLogLevel.Suppress to disable logs
        adjustConfig.setSendInBackground(true);
        new GameObject("Adjust").AddComponent<Adjust>(); // do not remove or rename
        // Adjust.addSessionCallbackParameter("foo", "bar"); // if requested to set session-level parameters
        //adjustConfig.setAttributionChangedDelegate((adjustAttribution) => {
        //  Debug.LogFormat("Adjust Attribution Callback: ", adjustAttribution.trackerName);
        //});
        Adjust.start(adjustConfig);
    }

    private void InitCallback()
    {
        if (FB.IsInitialized)
        {
            // Signal an app activation App Event
            FB.ActivateApp();
            // Continue with Facebook SDK
            // ...
        }
        else
        {
            Debug.Log("Failed to Initialize the Facebook SDK");
        }
    }

    private void OnHideUnity(bool isGameShown)
    {
        if (!isGameShown)
        {
            // Pause the game - we will need to hide
            Time.timeScale = 0;
        }
        else
        {
            // Resume the game - we're getting focus again
            Time.timeScale = 1;
        }
    }


    public void LevelStart(int level)
    {

        LionAnalytics.LevelStart(level, 1);
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "World01", "Level" + (level) + "_Started");

    
    }

    public void LevelComplete(int level)
    {
        LionAnalytics.LevelComplete(level, 1);
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "World01", "Level" + (level) + "_Completed");
    }

    public void LevelRestart(int level)
    {
        LionAnalytics.LevelRestart(level, 1);

    }

    public void GameOverEvent()
    {
        GameAnalytics.NewDesignEvent("GameRestart", 1);
    }

    public void LevelFail()
    {
        GameAnalytics.NewDesignEvent("GameOver", 1);
    }

    public void ButonClicked(string skillName)
    {
        GameAnalytics.NewDesignEvent(skillName + "_Clicked",1);
    }

    public void MaxLevelNumber(int levelNumber)
    {
        GameAnalytics.NewDesignEvent("PlayerLevelNumber_" + levelNumber);
    }




}
