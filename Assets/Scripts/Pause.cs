using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public AudioSource audioManager;
    public AudioSource soundFXManager;
    public AudioSource playerSoundManager;
    public AudioSource aiSoundManager;
    public GameObject gameStarted;
    Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("comecou");
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted.activeInHierarchy)
            return;
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }   
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

        audioManager.Pause();
        soundFXManager.Pause();
        playerSoundManager.Pause();
        aiSoundManager.Pause();
    }

    public void ResumeGame()
    {        
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

        audioManager.UnPause();
        soundFXManager.UnPause();
        playerSoundManager.UnPause();
        aiSoundManager.UnPause();
    }

    public bool isPaused()
    {
        return GameIsPaused;
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

