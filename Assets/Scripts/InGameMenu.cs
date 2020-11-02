using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{

    public GameObject objectToToggle;

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }

    public void Resume()
    {
        objectToToggle.SetActive(false);
        GameManager.instance.player.GetComponent<PlayerMovement>().isControllsLocked = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (objectToToggle.activeInHierarchy == false)
            {
                GameManager.instance.player.GetComponent<PlayerMovement>().isControllsLocked = true;
                objectToToggle.SetActive(true);
            }
            else
            {
                Resume();
            }
        }
    }
}
