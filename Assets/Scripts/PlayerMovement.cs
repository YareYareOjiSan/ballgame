using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb => GetComponent<Rigidbody2D>();
    GameManager gameManager => FindObjectOfType<GameManager>();
    Animator animator => GetComponent<Animator>();
    
    Vector2 moveDirection;
    [SerializeField]float moveSpeed;
    
    void Update()
    {
       GetInput();
       SetVelocity();

       if(rb.IsSleeping() == true) animator.SetBool("isIdle", true);

    }

    void GetInput() 
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        moveDirection = new Vector2(xInput, yInput);
    }

    void SetVelocity() 
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Powerup")) 
        {
            gameManager.StartCoroutine("PowerupActive");
            Destroy(other.gameObject);
        }         
    }
}

//This is a script for controlling the movement of a player character.
//The script is attached to the player game object and it uses a Rigidbody2D component to move the player.
//The script gets input from the player (using the "Horizontal" and "Vertical" axes) and sets the player's velocity based on that input and a move speed value.
//The script also has an Animator component and sets an "isIdle" bool in the Animator to true when the player's Rigidbody2D is sleeping (not moving).
//When the player collides with a game object with the "Powerup" tag, the script starts a "PowerupActive" coroutine in the GameManager and destroys the power-up game object.
