using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Text infoText;

    void Awake()
    {
        GameDistribution.OnResumeGame += ResumeGame;
        GameDistribution.OnPauseGame += PauseGame;
    }

    public void ResumeGame()
    {
        // RESUME MY GAME
        infoText.text = "RESUME GAME";
    }

    public void PauseGame()
    {
        // PAUSE MY GAME
        infoText.text = "GAME PAUSED";
    }


    public void ShowAd()
    {
        GameDistribution.Instance.ShowAd();
    }
}
