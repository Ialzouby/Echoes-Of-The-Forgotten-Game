using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class DescriptionScene2Manager : MonoBehaviour
{
    // This method will be called when the button is pressed
    public void GoToScene()
    {
        SceneManager.LoadScene("CharacterSelectionScene");
    }
}