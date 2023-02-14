using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    GameManager gameManager => FindObjectOfType<GameManager>();
    

   
    void Update()
    {
        transform.localScale = new Vector3(gameManager.killballScale, gameManager.killballScale, 1);
    }
}


//The script is attached to a "power-up" game object and it has a reference to the game's "GameManager" script.
//In the "Update" method, the script scales the "power-up" based on a value in the "GameManager" script.