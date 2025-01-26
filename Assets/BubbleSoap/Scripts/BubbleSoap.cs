using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSoap : MonoBehaviour
{
    // public BubbleAmmo bubblesUi;
    public BubbleWand bubbleWand;
    // public static event Action OnBubbleSoapCollect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player") {
            // OnBubbleSoapCollect.Invoke();
            var playerPower = collision.gameObject.GetComponent<PlayerPower>();
            playerPower.ammo++;
            bubbleWand.Fill();
            Destroy(gameObject);
        }
    }
}
