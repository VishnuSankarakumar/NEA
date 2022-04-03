using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public GameObject PauseMenuCanvas;
    public GameObject PauseButtonCanvas;
    public void OpenPause()
    {
        PauseMenuCanvas.SetActive(true);
        PauseButtonCanvas.SetActive(false);
    }

    
}
