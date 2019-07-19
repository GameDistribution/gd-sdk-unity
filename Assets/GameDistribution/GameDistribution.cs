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
    public static Action OnPreloadAd;

    [DllImport("__Internal")]
    private static extern void SDK_Init(string gameKey, string userId);

    [DllImport("__Internal")]
    private static extern void SDK_PreloadAd(string adType);

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
            Debug.LogWarning("GD initialization failed. Make sure you are running a WebGL build in a browser");
        }
    }
    
    internal void ShowAd(string adType)
    {
        try
        {
            SDK_ShowAd(adType);
        }
        catch (EntryPointNotFoundException e)
        {
            Debug.LogWarning("GD ShowAd failed. Make sure you are running a WebGL build in a browser");
        }
    }

    internal void PreloadAd(string adType)
    {
        try
        {
            SDK_Preload(adType);
        }
        catch (EntryPointNotFoundException e)
        {
            Debug.LogWarning("GD Preload failed. Make sure you are running a WebGL build in a browser");
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
        if(OnPauseGame != null) OnPauseGame();
    }

    /// <summary>
    /// It is being called as a response when PreloadAd has been called
    /// </summary>
    void PreloadAdCallback(bool loaded)
    {
        if(OnPreloadAd != null) OnPreloadAd(loaded);
    }
}