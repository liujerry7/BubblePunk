using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currHealth;
    public BubbleHearts bubbleHearts;
    private Rigidbody2D rb;
    public float hurtThrust;
    private SpriteRenderer spriteRenderer;
    public static event Action OnPlayerDied;

    public void Start()
    {
        ResetHealth();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        GameController.OnReset += ResetHealth;
    }

    private void ResetHealth()
    {
        currHealth = maxHealth;
        bubbleHearts.SetMaxHearts(maxHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (currHealth > 0 && collision.gameObject.layer == LayerMask.NameToLayer("Spike"))
        {
            Hurt(1);
            rb.velocity = new Vector2(rb.velocity.x, hurtThrust);
            SFXManager.Play("Pop");
        }
    }

    private void Hurt(int damage)
    {
        currHealth -= damage;
        bubbleHearts.UpdateHearts(currHealth);
        StartCoroutine(FlashRed());

        if (currHealth <= 0)
        {
            OnPlayerDied.Invoke();
        }
    }

    private IEnumerator FlashRed() 
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = Color.white;
    }
}