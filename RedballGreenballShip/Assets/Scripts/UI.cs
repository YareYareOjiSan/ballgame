using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit() 
    {
        Application.Quit();
    }

    public void StartGame() 
    {
        SceneManager.LoadScene("Game");
    }
}
