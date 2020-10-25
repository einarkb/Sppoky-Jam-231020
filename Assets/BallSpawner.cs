using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public Ball ballPrefab;
    public Vector2 spawnPosition;
    public Vector2 intialVelocity = new Vector2(0f, 0f);
    private Ball activeBall = null;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player") || collision.gameObject.layer == LayerMask.NameToLayer("FriendlyProjectile"))
        {
            if (activeBall != null)
            {
                activeBall.Kill();
            }
            activeBall = Instantiate(ballPrefab, new Vector3(spawnPosition.x, spawnPosition.y, 0f), ballPrefab.transform.rotation);
            activeBall.GetComponent<Rigidbody2D>().velocity = intialVelocity;
            activeBall.spawner = this;

            /*if (!activeBall)
            {
                activeBall = Instantiate(ballPrefab, new Vector3(spawnPosition.x, spawnPosition.y, 0f), ballPrefab.transform.rotation);
                activeBall.spawner = this;
            }
            else
            {
                Rigidbody2D rb = activeBall.GetComponent<Rigidbody2D>();
                rb.velocity = new Vector2(0f, 0f);
                rb.MovePosition(spawnPosition);
            }
            Debug.Log("spawned ball");*/
        }
    }

    public void ReachedGoal()
    {

        StartCoroutine(FadeAndDestroy());
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
