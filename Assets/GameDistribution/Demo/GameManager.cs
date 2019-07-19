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
        infoText.text = loaded>0 ? "GAME PRELOADED AD" : "GAME DIDN'T PRELOAD AD";
    }

    public void ShowAd(string adType)
    {
        GameDistribution.Instance.ShowAd(adType);
    }

    public void PreloadAd(string adType)
    {
        GameDistribution.Instance.PreloadAd(adType);
    }
}
