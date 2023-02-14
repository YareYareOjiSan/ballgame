using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] GameObject scoreBallPrefab;
    [SerializeField] GameObject killBallPrefab;
    [SerializeField] GameObject powerupPrefab;

    
    
    public void SpawnBalls() 
    {
        SpawnGreenBall();
        SpawnRedBall();
    }
    
    void SpawnGreenBall() 
    {
        float xPos = Random.Range(-3f,3f);
        float yPos = Random.Range(-3f,3f);

        Vector2 spawnPoint = new Vector2(xPos, yPos);
        Instantiate(scoreBallPrefab, spawnPoint, Quaternion.identity);
    }

    void SpawnRedBall() 
    {
        float xPos = Random.Range(-3f,3f);
        float yPos = Random.Range(-3f,3f);

        Vector2 spawnPoint = new Vector2(xPos, yPos);
        GameObject redball = Instantiate(killBallPrefab, spawnPoint, Quaternion.identity);
        print("Spawned Red Ball");
        
        int n = Random.Range(0,2);
        print(n);
            if(n == 0)
            {
                redball.GetComponent<KillBallReflect>().enabled = true;
                print("Enabled Reflection");
            }
                
            
            if(n == 1) {
                redball.GetComponent<KillBallFollow>().enabled = true;
                print("Enabled Follow");
                print(redball.GetComponent<KillBallFollow>());
            }
    }

    public void SpawnPowerup() 
    {
        float xPos = Random.Range(-3f,3f);
        float yPos = Random.Range(-3f,3f);

        Vector2 spawnPoint = new Vector2(xPos, yPos);
        Instantiate(powerupPrefab, spawnPoint, Quaternion.identity);
    }  


}
