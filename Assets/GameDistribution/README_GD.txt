#UNTIY GD PLUGIN

Setup:
 - Drag the prefab "GameDistribution" into your scene
 - Replace the GAME_KEY value with your own keys
 - Use GameDistribution.Instance.ShowAd() to show an interstitial advertisement
 - Use GameDistribution.Instance.ShowRewardedAd() to show a rewarded advertisement
 - Use GameDistribution.Instance.PreloadRewaredAd() to preload a rewarded advertisement
 - Make use of the events GameDistribution.OnResumeGame and GameDistribution.OnPauseGame for resuming/pausing your game in between ads
 - Make use of the event GameDistribution.OnPreloadRewardedVideo for checking the availability of rewarded advertisement after called GameDistribution.Instance.PreloadAd("rewarded")

Example:

public class ExampleClass: MonoBehaviour {

    void Awake()
    {
        GameDistribution.OnResumeGame += OnResumeGame;
        GameDistribution.OnPauseGame += OnPauseGame;
        GameDistribution.OnPreloadRewardedVideo += OnPreloadRewardedVideo;
    }

    public void OnResumeGame()
    {
        // RESUME MY GAME
    }

    public void OnPauseGame()
    {
        // PAUSE MY GAME
    }

    public void OnPreloadRewardedVideo(int loaded)
    {
        // FEEDBACK ABOUT PRELOADING AD
		// 0: SDK couldn't preloaded ad
		// 1: SDK preloaded ad
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