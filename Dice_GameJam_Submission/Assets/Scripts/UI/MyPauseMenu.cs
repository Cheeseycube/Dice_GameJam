using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MyPauseMenu : MonoBehaviour
{
    // uncomment the below stuff for controller support

    public GameObject pauseMenu;
    //public GameObject pauseFirstButton;
    public static bool isPaused;
    public static bool ControllerPaused = false;

    //BackgroundMusic musicObj;

    // Start is called before the first frame update
    void Start()
    {
        //musicObj = new BackgroundMusic();
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Pause")) // replace with getbuttondown at some point.  Also experiment with the layers
        {
            //ControllerPaused = false;
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
        /*if (Input.GetButtonDown("PauseController"))
        {
            ControllerPaused = true;
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGameController();
            }
        }*/
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    /*public void PauseGameController()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

        // clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        // set a new selected object
        EventSystem.current.SetSelectedGameObject(pauseFirstButton);
    }*/

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }


    public void QuitGame()
    {
        Application.Quit();
    }

    public void ToMainMenu()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        isPaused = false;
        SceneManager.LoadScene(0);
    }

    public void ToggleAudio()
    {
        FindObjectOfType<BackgroundMusic>().AudioToggle();
    }
}
