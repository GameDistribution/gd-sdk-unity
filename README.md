![](https://static.gamedistribution.com/wiki/TiysCcT.png)

[![GitHub version](https://img.shields.io/badge/version-1.0.0-green.svg)](https://github.com/GameDistribution/gd-sdk-unity/)
[![license](https://img.shields.io/github/license/mashape/apistatus.svg)](https://github.com/GameDistribution/gd-sdk-unity/blob/master/LICENSE)

# Gamedistribution.com Unity HTML5 SDK plugin

This is the documentation of the "Gamedistribution.com Unity HTML5 SDK plugin" project for adding the SDK within your <strong>Unity WebGL</strong> game.

Gamedistribution.com is the biggest broker of high quality, cross-platform games. We connect the best game developers to the biggest publishers.

Running into any issues?

Check out the F.A.Q. within the Wiki of the github repository before mailing to support@gamedistribution.com.

## Implementation within games

1.  Download and import the .unitypackage into your game (download [here](https://github.com/GameDistribution/gd-sdk-unity/raw/master/GameDistribution_Unity.unitypackage)).
    ![](https://static.gamedistribution.com/wiki/gd-html5-sdk-unity-plugin/1.png)
    ![](https://static.gamedistribution.com/wiki/gd-html5-sdk-unity-plugin/2.png)

1.  Drag the prefab "GameDistribution" into your scene.
    ![](https://static.gamedistribution.com/wiki/gd-html5-sdk-unity-plugin/3.png)

1.  Copy your GAME_KEY in your GameDistribution developer's control panel (in the 'Upload' tab), at <a href="https://developer.gamedistribution.com" target="_blank">developer.gamedistribution.com</a>

1.  Open the prefab and replace the GAME_KEY value with your own key.
    ![](https://static.gamedistribution.com/wiki/gd-html5-sdk-unity-plugin/4.png)

1.  Use GameDistribution.Instance.ShowAd() to show an advertisement.
    ![](https://static.gamedistribution.com/wiki/gd-html5-sdk-unity-plugin/5.png)

1.  Use GameDistribution.Instance.ShowRewardedAd() to show a rewarded advertisement.
    ![](https://static.gamedistribution.com/wiki/gd-html5-sdk-unity-plugin/6.png)

1.  Use GameDistribution.Instance.PreloadRewardedAd() to preload a rewarded advertisement
    ![](https://static.gamedistribution.com/wiki/gd-html5-sdk-unity-plugin/7.png)

1.  Make use of the events `GameDistribution.OnResumeGame` and `GameDistribution.OnPauseGame` for resuming/pausing your game in between ads.

1.  Make use of the event GameDistribution.OnPreloadAd for checking the availability of rewarded advertisement after called GameDistribution.Instance.PreloadRewardedAd()

### Example:

```csharp
public class ExampleClass: MonoBehaviour {

    void Awake()
    {
        GameDistribution.OnResumeGame += OnResumeGame;
        GameDistribution.OnPauseGame += OnPauseGame;
        GameDistribution.OnPreloadAd += OnPreloadAd;
    }

    public void OnResumeGame()
    {
        // RESUME MY GAME
    }

    public void OnPauseGame()
    {
        // PAUSE MY GAME
    }

    public void OnPreloadAd(int loaded)
    {
        // Feedback about preloading ad after called GameDistribution.Instance.PreloadAd
	// 0: SDK couldn't preload ad
	// 1: SDK preloaded ad
    }

    public void ShowAd()
    {
        GameDistribution.Instance.ShowRewardedAd();
    }

    public void PreloadRewardedAd()
    {
        GameDistribution.Instance.PreloadRewardedAd();
    }
}
```

## Best Practice for Rewarded Ads

You can use multiple ad slots for rewarded ads and give your players multiple way of gathering rewards. Samples below is very nice way of implementing this feature.

`Let them watch an ad to increase their attacks!` <br>
<img src="https://static.gamedistribution.com/wiki/rewarded-usage-1.png" width="70%">
<br>

`No coin no pain? Oh, it is not. Let them gain some free coins.` <br>
<img src="https://static.gamedistribution.com/wiki/rewarded-usage-2.png" width="70%">
<br>

`Who doesn't want a second chance?` <br>
<img src="https://static.gamedistribution.com/wiki/rewarded-usage-3.png" width="70%">
<br>

`Your players can take their chances to gain some buffs!` <br>
<img src="https://static.gamedistribution.com/wiki/rewarded-usage-4.png" width="70%">
<br>

`You can give away some daily gifts to your players.` <br>
<img src="https://static.gamedistribution.com/wiki/rewarded-usage-5.png" width="70%">
