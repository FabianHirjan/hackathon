using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class progresive : MonoBehaviour
{
    public Text guiText;
    public float pause = 0.1f;
    string message;

    void Start()
    {
        message = guiText.text;
        guiText.text = ""; // Clear the GUI text
        StartCoroutine(TypeLetters());
        
    }
    void next()
    {
        SceneManager.LoadScene("LVL1");
    }

    IEnumerator TypeLetters()
    {
        // Iterate over each letter
        foreach (char letter in message.ToCharArray())
        {
            guiText.text += letter; // Add a single character to the GUI text
            yield return new WaitForSeconds(pause);
        }
        next();
    }
}
