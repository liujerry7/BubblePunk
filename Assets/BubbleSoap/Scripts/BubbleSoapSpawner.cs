using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSoapSpawner : MonoBehaviour
{
    public BubbleSoap bubbleSoap;

    public float respawnTime = 5f;
    private float timer = 0f;
    private bool timerStarted = false;

    void Start()
    {
        SpawnSoap();
    }

    void Update()
    {
        if (timerStarted) {
            timer += Time.deltaTime;
            if (timer >= respawnTime)
            {
                SpawnSoap();
            }
        }
        
    }

    private void SpawnSoap()
    {
        BubbleSoap soapChild = Instantiate(bubbleSoap);
        soapChild.OnBubbleDie += StartTimer;
        timerStarted = false;
    }

    private void StartTimer() {
        timerStarted = true;
        timer = 0f;
    }
}
