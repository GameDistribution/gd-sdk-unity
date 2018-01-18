using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;

    private void Awake()
    {
        if (GameManager.Instance == null)
            GameManager.Instance = this;
        else
            Destroy(this);
    }

    public Text infoText;

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
