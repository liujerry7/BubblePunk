using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    private float xMovement;

    void Start()
    {
        
    }

    void Update()
    {
        rb.velocity = new Vector2(xMovement * moveSpeed, rb.velocity.y);
    }

    public void Move(InputAction.CallbackContext context)
    {
        xMovement = context.ReadValue<Vector2>().x;
    }
}
