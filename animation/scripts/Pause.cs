using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public Transform canvas, canvas2;

    void Start()
    {
        canvas.gameObject.SetActive(false);
        canvas2.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button7) || Input.GetKeyDown(KeyCode.Joystick2Button7))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        if (canvas.gameObject.activeInHierarchy == false)
        {
            canvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            if (canvas.gameObject.activeInHierarchy == true)
            {
                canvas.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

    public void Resume()
    {
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    public void BackToCharacterSelect()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("CharacterSelect");
    }

    public void ControlMenu()
    {
        canvas.gameObject.SetActive(false);
        canvas2.gameObject.SetActive(true);
    }

    public void ReturnFromControl()
    {
        canvas2.gameObject.SetActive(false);
        canvas.gameObject.SetActive(true);
    }
}
