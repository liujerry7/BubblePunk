using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject player;
    public BubbleWand bubbleWand;
    public List<GameObject> levels;
    private int currLevelIdx = 0;
    public static event Action OnReset;

    void Start()
    {
        BubbleSoap.OnBubbleSoapCollect += FillBubbleWand;
        PlayerHealth.OnPlayerDied += GameOverScreen;
        gameOverScreen.SetActive(false);
    }

    public void ResetGame()
    {
        gameOverScreen.SetActive(false);
        LoadLevel(0);
        OnReset.Invoke();
    }

    private void FillBubbleWand()
    {
        bubbleWand.Fill();
    }

    private void GameOverScreen()
    {
        gameOverScreen.SetActive(true);

    }

    private void LoadLevel(int levelIdx)
    {
        levels[currLevelIdx].gameObject.SetActive(false);
        levels[levelIdx].gameObject.SetActive(true);
        player.transform.position = new Vector3(0, 0.2f, 0);
        currLevelIdx = levelIdx;
    }
}
