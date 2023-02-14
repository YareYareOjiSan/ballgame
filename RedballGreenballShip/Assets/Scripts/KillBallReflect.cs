using UnityEngine;

public class KillBallReflect : MonoBehaviour
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

        transform.localScale = new Vector3(gameManager.killballScale, gameManager.killballScale, 1);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {        
        Bounce(collision.GetContact(0).normal);
        
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }

    void Bounce(Vector2 collisionNormal)
    {
        var direction = Vector2.Reflect(lastFrameVelocity.normalized, collisionNormal);

        //Debug.Log("Out Direction: " + direction);
        rb.velocity = direction * moveSpeed;
    }
}