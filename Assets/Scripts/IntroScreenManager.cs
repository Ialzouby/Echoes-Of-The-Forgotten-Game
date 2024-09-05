using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScreenManager : MonoBehaviour
{
    public void StartGame()
    {
       
        SceneManager.LoadScene("descriptionscene");
    }
}
