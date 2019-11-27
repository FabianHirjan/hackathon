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
public void options()
    {
        SceneManager.LoadScene("Settings");
    }

    public void mainm()
    {
        SceneManager.LoadScene("MainM");
    }
    public void quitgame()
    {
        Application.Quit();
    }
}
