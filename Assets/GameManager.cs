using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public LevelManager levelManager;
    public GameObject pauseMenu;
    public Transform player;

    private bool _paused = false;
    private float timeScale;
    public float Score { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        timeScale = Time.timeScale;
        Score = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
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

        if(player.position.y < -1)
        {
            Debug.Log("Game Over");
            // TODO go to gameover menu
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
        pauseMenu.SetActive(false);
        _paused = false;
    }
}
