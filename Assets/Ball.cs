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
    public SpriteRenderer renderer;

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
        StartCoroutine(FadeAndDestroy(0.25f));
    }

    public void Kill()
    {
        GetComponent<Collider2D>().enabled = false;
        StartCoroutine(FadeAndDestroy(0.12f));
    }

    private IEnumerator FadeAndDestroy(float decayTime)
    {
        float intensity = mainLight.intensity;
        float time = 0;
   

        ps.Stop();
        while (time < decayTime)
        {
            float a = Mathf.Lerp(intensity, 0f, time * 1 / decayTime);
            float a2 = Mathf.Lerp(renderer.color.a, 0f, time * 1 / decayTime);
            mainLight.intensity = a;
            renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.g, a2);
         


            time += Time.deltaTime;
            yield return new WaitForSeconds(0.01f);
        }
        mainLight.intensity = 0f;
        renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.g, 0f);

        while (ps.particleCount > 0)
        {
            yield return new WaitForSeconds(0.01f);
        }

        Destroy(gameObject);
    }
}
