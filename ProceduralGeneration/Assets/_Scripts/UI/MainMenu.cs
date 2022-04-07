using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsPanel;
    public AbstractClass generator;

    //public void GenerateMap() //only this procedure is public so that information hiding principles are maintained
    //{
    //    MainMenu mainMenu = new MainMenu();
    //    mainMenu.GenerateDungeon();

    //}

    public void StartGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void OpenLeaderboard()
    {
        SceneManager.LoadScene("Leaderboard");
    }

    public void ExitGame()
    {
        Application.Quit(); //won't work if run in Unity. To use, export or build game
        Debug.Log("Quitting Game");
    }
}
