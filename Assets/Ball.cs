using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{

    public Vector3 spawnPos;

    public ParticleSystem ps;
    public Light2D mainLight;

    public BallSpawner spawner;

    private void Start()
    {
        spawnPos = transform.position;
    }


    /*private void OnMouseOver()
    {
        if (GameManager.instance.player.GetComponent<PlayerMovement>().isControllsLocked == false && Input.GetMouseButtonDown((int)MouseButton.RightMouse))
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(0f, 0f);
            rb.MovePosition(spawnPos);
        }
    }*/

    public void ReachedGoal()
    {
        spawner.ReachedGoal();
        StartCoroutine(FadeAndDestroy());
    }

    private IEnumerator FadeAndDestroy()
    {
        float intensity = mainLight.intensity;
        float time = 0;

        ps.Stop();
        while (time < 0.25)
        {
            float a = Mathf.Lerp(intensity, 0f, time * 4);
            mainLight.intensity = a;


            time += Time.deltaTime;
            yield return new WaitForSeconds(0.01f);
        }
        mainLight.intensity = 0f;

        while (ps.particleCount > 0)
        {
            yield return new WaitForSeconds(0.01f);
        }

        Destroy(gameObject);
    }
}
