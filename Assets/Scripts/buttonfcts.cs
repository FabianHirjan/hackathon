using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class buttonfcts : MonoBehaviour
{
public void startgm()
    {
        SceneManager.LoadScene("debug");
    }

public void quitgame()
    {
        Application.Quit();
    }
}
