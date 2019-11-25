using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class prog : MonoBehaviour
{
    public Text guiText;
    public float pause = 0.1f;
    string message;

    void Start()
    {
        message = guiText.text;
        guiText.text = "";
        StartCoroutine(TypeLetters());

    }
    void next()
    {
        message = "ABEL: Wow!Nobody would belive me if I'm to go back down empty handed";
        guiText.text = "";
        StartCoroutine(TypeLetter());
    }
    IEnumerator TypeLetter()
    {
        // Iterate over each letter
        foreach (char letter in message.ToCharArray())
        {
            guiText.text += letter; // Add a single character to the GUI text
            yield return new WaitForSeconds(pause);
        }
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
