using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public GameObject exitButton;

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
