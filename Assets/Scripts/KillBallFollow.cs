using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBallFollow : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    
    GameManager gameManager => FindObjectOfType<GameManager>();
    Transform target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        transform.localScale = new Vector3(gameManager.killballScale, gameManager.killballScale, 1);
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {                
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            gameManager.GameOver();
        }
    }
}

//This is a script for a "kill ball".
//The script is attached to a "kill ball" game object and it has a "moveSpeed" value that determines how fast the ball moves.
//The script also has a reference to the game's "GameManager" script. In the "Start" method, the script gets a reference to the player's transform
//(the position, rotation, and scale of the player). In the "Update" method, the script scales the ball based on a value in the "GameManager" script
//and moves the ball towards the player's position at a speed determined by the ball's "moveSpeed" value. When the ball collides with a game object with the "Player" tag,
//the script destroys the player game object and calls the "GameOver" method in the "GameManager" script.



