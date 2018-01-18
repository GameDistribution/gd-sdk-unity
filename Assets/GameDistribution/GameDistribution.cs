using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class GameDistribution : MonoBehaviour {

    public static GameDistribution Instance;

    public string GAME_KEY = "YOUR_GAME_KEY_HERE";
    public string USER_ID = "YOUR_USER_ID_HERE";

    public Action OnResumeGame;
    public Action OnPauseGame;

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

        InitApi(GAME_KEY, USER_ID);
    }

    internal void ShowAd()
    {
       ShowBanner();
    }

    /// <summary>
    /// Resume the game, this method is used when an ad has been showed
    /// </summary>
    void ResumeGame()
    {
       if (OnResumeGame!= null) OnResumeGame();
    }

    /// <summary>
    /// Pause the game, this method is used when we show an ad
    /// </summary>
    void PauseGame()
    {
        if (OnPauseGame != null) OnPauseGame();
    }
}
