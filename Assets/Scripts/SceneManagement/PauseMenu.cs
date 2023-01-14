using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class PauseMenu : MonoBehaviour
{
    //GameIsPaused was static
    public static bool GameIsPaused = false;
    public GameObject pauseMenu;
    public PlayerControls playerControls;
    private InputAction pause;
    private PlayerInput playerInput;
    public PlayerMovement playerMovement;
    private void Awake()
    {
        playerControls = new PlayerControls();
        playerInput = GetComponent<PlayerInput>();
        playerMovement.TakeInput(playerControls);
    }

    
    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (GameIsPaused)
            {
                playerMovement.StopInput();
            }
        }

        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (!GameIsPaused)
            {
                playerMovement.TakeInput(playerControls);
            }
        }
    }
    private void OnEnable()
    {
        pause = playerControls.Player.Pause;
        pause.Enable();
        pause.performed += PauseResume;
    }

    private void OnDisable()
    {
        pause.Disable();
    }
    
    public void PauseResume(InputAction.CallbackContext context)
    {
        if (GameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {   
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMainMenu()
    {
            Resume();
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void TakeInputForResumeButton()
    {
        playerMovement.TakeInput(playerControls);
    }
}
