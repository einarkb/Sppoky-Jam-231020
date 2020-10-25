using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private bool isTriggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player p = collision.gameObject.GetComponent<Player>();
        if (isTriggered == false && p)
        {
            isTriggered = true;
            p.respawnPoint = new Vector3(transform.position.x, math.round(transform.position.y) + 1f, 0f);
            StartCoroutine(FadeAndDestroy());
            
        }
    }

    private IEnumerator FadeAndDestroy()
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();
        ps.Stop();
        while (ps.particleCount > 0)
        {
            yield return new WaitForSeconds(0.01f);

        }
        Destroy(gameObject);
    }
}
