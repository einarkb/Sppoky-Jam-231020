using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class LevelGoal : MonoBehaviour
{
    private bool entered = false;
    public WinMenu winMenu;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (entered == false) {
            entered = true;
            collision.gameObject.GetComponent<PlayerMovement>().isControllsLocked = true;
            StartCoroutine(Accend());
        }
    }


 

    private IEnumerator Accend()
    {

        Light2D light = GetComponent<Light2D>();

        float startPos = transform.position.y;
        float diff = 76f - startPos;

        winMenu.gameObject.SetActive(true);

        while (transform.position.y < 76f)
        {
            float intensity = (transform.position.y - startPos) / diff;
            //print(intensity);
            light.intensity = intensity /3f - 0.02f;

            transform.position = (transform.position + new Vector3(0f, 10f * Time.deltaTime, 0f));
            Vector3 playerPos = GameManager.instance.player.transform.position;
            GameManager.instance.player.transform.position = new Vector3(playerPos.x, transform.position.y + 1f, 0f);
            yield return new WaitForSeconds(0.001f);
        }

        winMenu.exitButton.SetActive(true);
    }
}
