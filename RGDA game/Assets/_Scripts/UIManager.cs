using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu;

    private void Awake()
    {
        PauseGame();
        PauseMenu.SetActive(true);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        AudioListener.pause = true;
        PauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        PauseMenu.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
