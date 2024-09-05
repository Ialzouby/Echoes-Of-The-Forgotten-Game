using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DescriptionSceneManager : MonoBehaviour
{
    // This method will be called when the button is pressed
    public void GoToCharacterSelectionScene()
    {
        SceneManager.LoadScene("descriptionscene2");
    }
}
