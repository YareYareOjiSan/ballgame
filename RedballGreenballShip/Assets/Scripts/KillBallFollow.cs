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
