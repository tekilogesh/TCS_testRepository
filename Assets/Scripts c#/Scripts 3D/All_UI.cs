using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class All_UI : MonoBehaviour
{
    public static All_UI ui_instance;

    private void Awake()
    {
        if(ui_instance!=null)
        {
            ui_instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    public bool gamePaused;

    public bool levelWon;

    public KeyCode pauseKey;

    public GameObject gamePauseUI;

    public GameObject levelWonUI;

    

    void Start()
    {

    }


    void Update()
    {
        if (Input.GetKeyDown(pauseKey) && !gamePaused) 
        {
            Pause();
        }
        
        if(levelWon && !levelWonUI.activeInHierarchy)
        {
            levelWonUI.SetActive(true);
        }
        else if(!levelWon && levelWonUI.activeInHierarchy)
        {
            levelWonUI.SetActive(false);
        }

    }

    public void Play()
    {
        loadScene(1);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        gamePauseUI.SetActive(true);
        gamePaused = true;
    }

    public void resume()
    {
        if(gamePaused)
        {
            Time.timeScale = 1;
            gamePaused = false;
        gamePauseUI.SetActive(false);
        }
    }    

    public void loadScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void reloadScene()
    {
        loadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
