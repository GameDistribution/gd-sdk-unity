using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using System.Text.RegularExpressions;
public class GameDistribution : MonoBehaviour
{
    public static GameDistribution Instance;

    public string GAME_KEY = "YOUR_GAME_KEY_HERE";

    public static Action<string> OnEvent;
    public static Action OnResumeGame;
    public static Action OnPauseGame;
    public static Action OnRewardGame;
    public static Action OnRewardedVideoSuccess;
    public static Action OnRewardedVideoFailure;
    public static Action<int> OnPreloadRewardedVideo;

    [DllImport("__Internal")]
    private static extern void SDK_Init(string gameKey);

    [DllImport("__Internal")]
    private static extern void SDK_PreloadAd();

    [DllImport("__Internal")]
    private static extern void SDK_ShowAd(string adType);
    [DllImport("__Internal")]
    private static extern void SDK_SendEvent(string options);

    private bool _isRewardedVideoLoaded = false;

    void Awake()
    {
        if (GameDistribution.Instance == null)
            GameDistribution.Instance = this;
        else
            Destroy(this);

        DontDestroyOnLoad(this);

        Init();
    }

    void Init()
    {
        try
        {
            SDK_Init(GAME_KEY);
        }
        catch (EntryPointNotFoundException e)
        {
            Debug.LogWarning("GD initialization failed. Make sure you are running a WebGL build in a browser:" + e.Message);
        }
    }
    internal void ShowAd()
    {
        try
        {
            SDK_ShowAd(null);
        }
        catch (EntryPointNotFoundException e)
        {
            Debug.LogWarning("GD ShowAd failed. Make sure you are running a WebGL build in a browser:" + e.Message);
        }
    }

    internal void ShowRewardedAd()
    {
        try
        {
            SDK_ShowAd("rewarded");
        }
        catch (EntryPointNotFoundException e)
        {
            Debug.LogWarning("GD ShowAd failed. Make sure you are running a WebGL build in a browser:" + e.Message);
        }
    }

    internal void PreloadRewardedAd()
    {
        try
        {
            SDK_PreloadAd();
        }
        catch (EntryPointNotFoundException e)
        {
            Debug.LogWarning("GD Preload failed. Make sure you are running a WebGL build in a browser:" + e.Message);
        }
    }

    internal void SendEvent(string options)
    {
        try
        {
            SDK_SendEvent(options);
        }
        catch (EntryPointNotFoundException e)
        {
            Debug.LogWarning("GD SendEvent failed. Make sure you are running a WebGL build in a browser:" + e.Message);
        }
    }
    /// <summary>
    /// It is being called by HTML5 SDK when the game should start.
    /// </summary>
    void ResumeGameCallback()
    {
        if (OnResumeGame != null) OnResumeGame();
    }

    /// <summary>
    /// It is being called by HTML5 SDK when the game should pause.
    /// </summary>
    void PauseGameCallback()
    {
        if (OnPauseGame != null) OnPauseGame();
    }

    /// <summary>
    /// It is being called by HTML5 SDK when the game should should give reward.
    /// </summary>
    void RewardedCompleteCallback()
    {
        if (OnRewardGame != null) OnRewardGame();
    }

    /// <summary>
    /// It is being called by HTML5 SDK when the rewarded video succeeded.
    /// </summary>
    void RewardedVideoSuccessCallback()
    {
        _isRewardedVideoLoaded = false;

        if (OnRewardedVideoSuccess != null) OnRewardedVideoSuccess();
    }

    /// <summary>
    /// It is being called by HTML5 SDK when the rewarded video failed.
    /// </summary>
    void RewardedVideoFailureCallback()
    {
        _isRewardedVideoLoaded = false;

        if (OnRewardedVideoFailure != null) OnRewardedVideoFailure();
    }

    /// <summary>
    /// It is being called by HTML5 SDK when it preloaded rewarded video
    /// </summary>
    void PreloadRewardedVideoCallback(int loaded)
    {
        _isRewardedVideoLoaded = (loaded == 1);

        if (OnPreloadRewardedVideo != null) OnPreloadRewardedVideo(loaded);
    }

    /// <summary>
    /// It is being called by HTML5 SDK when it any event triggered
    /// </summary>
    void EventCallback(string eventData)
    {
        if (OnEvent != null) OnEvent(eventData);
    }

    public bool IsRewardedVideoLoaded()
    {
        return _isRewardedVideoLoaded;
    }
}