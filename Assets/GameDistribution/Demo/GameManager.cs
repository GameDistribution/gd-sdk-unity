using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Text gameControlText;
    public Text rewardedAdText;
    public Text rewardPlayerText;

    void Awake()
    {
        GameDistribution.OnResumeGame += OnResumeGame;
        GameDistribution.OnPauseGame += OnPauseGame;
        GameDistribution.OnPreloadRewardedVideo += OnPreloadRewardedVideo;
        GameDistribution.OnRewardedVideoSuccess += OnRewardedVideoSuccess;
        GameDistribution.OnRewardedVideoFailure += OnRewardedVideoFailure;
        GameDistribution.OnRewardGame += OnRewardGame;
    }

    public void OnResumeGame()
    {
        // RESUME MY GAME
        gameControlText.text = "RESUME GAME";
    }

    public void OnPauseGame()
    {
        // PAUSE MY GAME
        gameControlText.text = "GAME PAUSED";
    }
    public void OnRewardGame()
    {
        // REWARD PLAYER HERE
        rewardPlayerText.text = "Give Reward Here.";
    }
    public void OnRewardedVideoSuccess()
    {
        rewardedAdText.text = "Rewarded video succeeded...";
    }

    public void OnRewardedVideoFailure()
    {
        rewardedAdText.text = "Rewarded video failed...";
    }

    public void OnPreloadRewardedVideo(int loaded)
    {
        // FEEDBACK ABOUT PRELOADED AD
        rewardedAdText.text = loaded == 1 ? "Rewarded video has been loaded." : "Rewarded video couldn't be loaded.";
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
