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
    
    // Update is called once per frame
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
