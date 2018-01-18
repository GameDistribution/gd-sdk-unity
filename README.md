[![GitHub version](https://img.shields.io/badge/version-1.0.0-green.svg)](https://github.com/GameDistribution/gd-sdk-unity/)
[![license](https://img.shields.io/github/license/mashape/apistatus.svg)](https://github.com/GameDistribution/gd-sdk-unity/blob/master/LICENSE)


# Gamedistribution.com Unity HTML5 SDK plugin
This is the documentation of the "Gamedistribution.com Unity HTML5 SDK plugin" project for adding the SDK within your <strong>Unity WebGL</strong> game.

Gamedistribution.com is the biggest broker of high quality, cross-platform games. We connect the best game developers to the biggest publishers.

Running into any issues? Check out the F.A.Q. within the Wiki of the github repository before mailing to <a href="support@gamedistribution.com" target="_blank">support@gamedistribution.com</a>

## Implementation within games
 1. Drag the prefab "GameDistribution" into your scene.
 1. Replace the GAME_KEY and USER_ID values with your own keys.
 1. Use GameDistribution.Instance.ShowAd() to show an advertisement.
 1. Make use of the events `GameDistribution.OnResumeGame` and `GameDistribution.OnPauseGame` for resuming/pausing your game in between ads.

### Example:

```
public class ExampleClass: MonoBehaviour {
	void Awake()
	{
	  GameDistribution.OnResumeGame += ResumeGame;
	  GameDistribution.OnPauseGame += PauseGame;
	}

	public void ResumeGame()
	{
	  // RESUME MY GAME
	}

	public void PauseGame()
	{
	  // PAUSE MY GAME
	}

	public void ShowAd()
	{
	  GameDistribution.Instance.ShowAd();	
	}
}
```