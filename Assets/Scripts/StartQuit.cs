using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class StartQuit : MonoBehaviour
{
    // Start is called before the first frame update
public void PlayGame()
    {
        //LoaderUtility.Initialize();
        SceneManager.LoadScene("ImageTracking");

    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Start");
    }
}
