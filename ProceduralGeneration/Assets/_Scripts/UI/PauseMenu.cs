using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuCanvas;
    public GameObject PauseButtonCanvas;
    public void ClosePause()
    {
        PauseMenuCanvas.SetActive(false);
        PauseButtonCanvas.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

}
