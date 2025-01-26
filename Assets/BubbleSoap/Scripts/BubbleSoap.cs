using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSoap : MonoBehaviour
{
    public static event Action OnBubbleSoapCollect;
    public event Action OnBubbleDie;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player") {
            var playerPower = collision.gameObject.GetComponent<PlayerPower>();
            OnBubbleSoapCollect.Invoke();
            OnBubbleDie.Invoke();
            playerPower.ammo = Mathf.Min(1, playerPower.ammo + 1);
            SFXManager.Play("Pop");
            Destroy(gameObject);
        }
    }
}
