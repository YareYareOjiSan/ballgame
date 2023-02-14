using UnityEngine;

public class ScoreBall : MonoBehaviour
{
    GameManager gameManager => FindObjectOfType<GameManager>();
    Vector2 initialVelocity;

    [SerializeField] float moveSpeed;

     Vector2 lastFrameVelocity;
     Rigidbody2D rb;
    
    void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        initialVelocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        rb.velocity = initialVelocity * moveSpeed;
    }

    void Update()
    {
        lastFrameVelocity = rb.velocity;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {        
        Bounce(collision.GetContact(0).normal);
        
        if(collision.gameObject.CompareTag("Player"))
        {
            gameManager.UpdateScore();
            gameManager.UpdateHiscore();
            Destroy(gameObject);
        }
    }

    void Bounce(Vector2 collisionNormal)
    {
        var direction = Vector2.Reflect(lastFrameVelocity.normalized, collisionNormal);

        
        rb.velocity = direction * moveSpeed;
    }
}

//The script is attached to a "score ball" game object and it has a "moveSpeed" value that determines
//how fast the ball moves. The script also has a reference to the game's "GameManager" script. When the script is enabled
//(when the ball is instantiated), it gets a reference to the ball's Rigidbody2D component and sets the ball's velocity to a random direction at the "moveSpeed" value.
//In the "Update" method, the script stores the ball's velocity in the previous frame. When the ball collides with another game object, the script
//bounces the ball off the other object using the "Bounce" method. The "Bounce" method uses the "Reflect" method to change the ball's velocity based on the direction it
//was moving and the normal of the collision (the direction perpendicular to the surface of the colliding object). If the ball collides with a game object with the "Player" tag,
//the script updates the player's score and hiscore in the "GameManager" script and destroys the ball game object.



