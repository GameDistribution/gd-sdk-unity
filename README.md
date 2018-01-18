[![GitHub version](https://img.shields.io/badge/version-1.0.0-green.svg)](https://github.com/GameDistribution/gd-sdk-unity/)
[![license](https://img.shields.io/github/license/mashape/apistatus.svg)](https://github.com/GameDistribution/gd-sdk-unity/blob/master/LICENSE)


# Gamedistribution.com Unity HTML5 plugin

## Setup:
 - Drag the prefab "GameDistribution" into your scene.
 - Replace the GAME_KEY and USER_ID values with your own keys.
 - Use GameDistribution.Instance.ShowAd() to show an advertisement.
 - Make use of the events GameDistribution.OnResumeGame and GameDistribution.OnPauseGame for resuming/pausing your game in between ads.

## Example:

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