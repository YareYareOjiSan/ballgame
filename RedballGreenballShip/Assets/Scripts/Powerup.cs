using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    GameManager gameManager => FindObjectOfType<GameManager>();
    

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(gameManager.killballScale, gameManager.killballScale, 1);
    }
}
