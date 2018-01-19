using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class GameDistribution : MonoBehaviour
{
    public static GameDistribution Instance;

    public string GAME_KEY = "YOUR_GAME_KEY_HERE";
    public string USER_ID = "YOUR_USER_ID_HERE";

    public static Action OnResumeGame;
    public static Action OnPauseGame;

    [DllImport("__Internal")]
    private static extern void InitApi(string gameKey, string userId);

    [DllImport("__Internal")]
    private static extern void ShowBanner();

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
            InitApi(GAME_KEY, USER_ID);
        }
        catch (EntryPointNotFoundException e)
        {
            Debug.LogWarning("GD initialization failed. Make sure you are running a WebGL build in a browser");
        }
    }
    
    internal void ShowAd()
    {
        try
        {
            ShowBanner();
        }
        catch (EntryPointNotFoundException e)
        {
            Debug.LogWarning("GD ShowBanner failed. Make sure you are running a WebGL build in a browser");
        }
    }

    /// <summary>
    /// Resume the game, this method is used when an ad has been showed
    /// </summary>
    void ResumeGame()
    {
       if (OnResumeGame != null) OnResumeGame();
    }

    /// <summary>
    /// Pause the game, this method is used when we show an ad
    /// </summary>
    void PauseGame()
    {
        if(OnPauseGame != null) OnPauseGame();
    }
}
