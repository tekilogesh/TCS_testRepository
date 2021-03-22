using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class All_UI : MonoBehaviour
{
    
    public bool gamePaused;// bool to pause and unpause gameplay.

    public bool levelWon;// bool to finish the level.

    public bool gameOver;// bool to finish the game.

    public bool instructionsB;

    public KeyCode pauseKey;

    public GameObject gamePauseUI;

    public GameObject levelWonUI;

    public GameObject gameOverUI;

    public GameObject instructionsUI;
    void Start()
    {

    }


    void Update()
    {


        if (SceneManager.GetActiveScene().buildIndex > 0)
        {
            if (Input.GetKeyDown(pauseKey) && !gamePaused)
            {
                f_Pause();
            }
            if (levelWon && !levelWonUI.activeInHierarchy)
            {
                levelWonUI.SetActive(true);
            }
            else if (!levelWon && levelWonUI.activeInHierarchy)
            {
                levelWonUI.SetActive(false);
            }
        }
        else
        {
            if(instructionsB )
            {
                instructionsUI.SetActive(true);
            }
            else
            {
                instructionsUI.SetActive(false);
            }

        }
        if(gameOver && !gameOverUI.activeInHierarchy)
        {
            gameOverUI.SetActive(true);
            Time.timeScale = 0f;
        }



    }
    public void f_showInstructions()
    {
        instructionsB = true;
    }

    public void f_hideInstructions()
    {
        instructionsB = false;
    }

    public void Play()
    {
        f_loadScene(1);
    }

    public void f_Pause()
    {
        Time.timeScale = 0;
        gamePauseUI.SetActive(true);
        gamePaused = true;
    }

    public void f_resume()
    {
        if(gamePaused)
        {
            Time.timeScale = 1;
            gamePaused = false;
        gamePauseUI.SetActive(false);
        }
    }    

    public void f_loadScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void f_nextLevel()
    {
      if(SceneManager.GetActiveScene().buildIndex <3)
        f_loadScene(SceneManager.GetActiveScene().buildIndex + 1);
      else
            f_loadScene(0);

    }
    public void f_loadmenu()
    {
        f_loadScene(0);
    }

    public void f_reloadScene()
    {
        f_loadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void f_Quit()
    {
        Application.Quit();
    }
}
