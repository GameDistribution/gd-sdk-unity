using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Text infoText;

    void Awake()
    {
        GameDistribution.OnResumeGame += OnResumeGame;
        GameDistribution.OnPauseGame += OnPauseGame;
        GameDistribution.OnPreloadAd += OnPreloadAd;
    }

    public void OnResumeGame()
    {
        // RESUME MY GAME
        infoText.text = "RESUME GAME";
    }

    public void OnPauseGame()
    {
        // PAUSE MY GAME
        infoText.text = "GAME PAUSED";
    }

    public void OnPreloadAd(int loaded)
    {
        // FEEDBACK ABOUT PRELOADED AD
        infoText.text = loaded > 0 ? "SDK PRELOADED AD" : "SDK COULDN'T PRELOAD AD";
    }

    public void ShowAd()
    {
        GameDistribution.Instance.ShowAd();
    }

    public void ShowRewardedAd()
    {
        GameDistribution.Instance.ShowRewardedAd();
    }


    public void PreloadRewardedAd()
    {
        GameDistribution.Instance.PreloadRewardedAd();
    }
}
