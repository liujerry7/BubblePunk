using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject tutorial;
    public GameObject gameOverScreen;
    public TMP_Text gameOverText;
    public GameObject player;
    public BubbleWand bubbleWand;
    public List<GameObject> levels;
    private int currLevelIdx = 0;
    public static event Action OnReset;

    void Start()
    {
        BubbleSoap.OnBubbleSoapCollect += FillBubbleWand;
        PlayerHealth.OnPlayerDied += LoseGame;
        PlayerHealth.OnPlayerBeatLevel += NextLevel;
        gameOverScreen.SetActive(false);
        tutorial.SetActive(false);
    }

    public void ResetGame()
    {
        gameOverScreen.SetActive(false);
        LoadLevel(0);
        OnReset.Invoke();
    }

    private void NextLevel()
    {
        if (currLevelIdx >= levels.Count - 1) {
            GameOverScreen("YOU WIN!");
        } else {
            LoadLevel(currLevelIdx + 1);
        }
    }

    private void FillBubbleWand()
    {
        bubbleWand.Fill();
        tutorial.SetActive(true);
    }

    private void LoseGame()
    {
        GameOverScreen("GAME OVER");
    }

    private void GameOverScreen(string text)
    {
        gameOverScreen.SetActive(true);
        gameOverText.text = text;
    }

    private void LoadLevel(int levelIdx)
    {
        levels[currLevelIdx].gameObject.SetActive(false);
        levels[levelIdx].gameObject.SetActive(true);
        player.transform.position = new Vector3(0, 0.2f, 0);
        currLevelIdx = levelIdx;
    }
}
