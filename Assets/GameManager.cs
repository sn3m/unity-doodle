using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public LevelManager levelManager;
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public Transform player;

    private bool _paused = false;
    private bool allowPauseScreen = true;
    private float defaultTimeScale = 1.3f;
    private float timeScale;
    public float Score { get; set; }
    private bool gameHasEnded = false;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = defaultTimeScale;
        timeScale = Time.timeScale;
        Score = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause") && allowPauseScreen)
        {
            if (!_paused && Time.timeScale > 0.5f)
            {
                Pause();
            }
            else if (_paused)
            {
                Unpause();
            }
        }

        if(!_paused)
        {
            Score += levelManager.speed * Time.deltaTime;
        }

        if(player.position.y < -2)
        {
            if(gameHasEnded == false) {
                gameHasEnded = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                _paused = true;
                allowPauseScreen = false;
                gameOverMenu.SetActive(true);
            }
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _paused = true;
        pauseMenu.SetActive(true);
    }

    public void Unpause()
    {
        Time.timeScale = timeScale;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenu.transform.Find("Panel/PauseMenu").gameObject.SetActive(true);
        pauseMenu.transform.Find("Panel/OptionsMenu").gameObject.SetActive(false);
        pauseMenu.SetActive(false);
        _paused = false;
    }

    public void Restart()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("MainMenuScene");
    }
}
