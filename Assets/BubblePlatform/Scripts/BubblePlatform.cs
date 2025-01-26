using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblePlatform : MonoBehaviour
{
    public Rigidbody2D rb;
    public float gravity = 1f;
    public float lifetime = 0f;
    public float lifetimeMax = 5f;

    void Update()
    {
        rb.velocity = new Vector2(rb.velocity.x, gravity); 
        lifetime += Time.deltaTime;

        if (lifetime >= lifetimeMax)
        {
            Destroy(gameObject);
        }
    }
}
