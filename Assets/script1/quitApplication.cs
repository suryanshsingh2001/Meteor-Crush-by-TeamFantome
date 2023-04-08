using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class quitApplication : MonoBehaviour
{
    public void ExitButton()
    {
        Application.Quit();
    }
    public void PlayButton()
    {
        SceneManager.LoadScene("Game");
    }
}
