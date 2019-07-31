using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class GameDistribution : MonoBehaviour
{
    public static GameDistribution Instance;

    public string GAME_KEY = "YOUR_GAME_KEY_HERE";

    public static Action OnResumeGame;
    public static Action OnPauseGame;
    public static Action<int> OnPreloadAd;

    [DllImport("__Internal")]
    private static extern void SDK_Init(string gameKey);

    [DllImport("__Internal")]
    private static extern void SDK_PreloadAd();

    [DllImport("__Internal")]
    private static extern void SDK_ShowAd(string adType);

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
    /// It is being called by HTML5 SDK when it preloaded ad
    /// </summary>
    void PreloadAdCallback(int loaded)
    {
        if (OnPreloadAd != null) OnPreloadAd(loaded);
    }
}