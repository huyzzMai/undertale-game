using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameMenu : MonoBehaviour
{
    public GameObject EndGameMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (PlayerCollision.GameIsEnd)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        EndGameMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Replay()
    {
        PlayerCollision.GameIsEnd = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Battle");
    }

    public void LoadMenuAtEnd()
    {
        PlayerCollision.GameIsEnd = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Title");
    }
    public void QuitGameAtEnd()
    {
        Debug.Log("Quit Game....");
        Application.Quit();
    }
}
