using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public static bool isPaused;

    void Start()
    {
        // Check if pauseMenu and optionsMenu exist before trying to set them inactive
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }
        if (optionsMenu != null)
        {
            optionsMenu.SetActive(false);
        }
    }

    void Update()
    {
        // Check if the Escape key is pressed and if optionsMenu exists and is not active
        if (Input.GetKeyDown(KeyCode.Escape) && (optionsMenu == null || !optionsMenu.activeInHierarchy))
        {
            if (isPaused)
            {
                ResumeGame(); 
            }
            else
            {
                PauseGame();
            }
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            AudioManager.instance.PlaySound("Click");
        }
    }

    public void PlayGame()
    {
        AudioManager.instance.PlayMusic("CombatMusic");
        SceneManager.LoadScene("Level 1");
        Time.timeScale = 1f;
        isPaused = false;

        // Check if pauseMenu exists before trying to activate it
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(true);
        }
    }

    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Check if pauseMenu exists before trying to activate it
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(true);
        }
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        // Check if pauseMenu exists before trying to deactivate it
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        isPaused = false;
        AudioManager.instance.StopMusic();
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Retry()
    {
        AudioManager.instance.PlayMusic("CombatMusic");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;

        // Check if pauseMenu exists before trying to activate it
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(true);
        }
    }
}