using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazerblock : MonoBehaviour, ITriggerReactor
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collision.gameObject.GetComponent<Player>().KillPlayer();
        }
        else
        {
            collision.GetComponent<Ball>()?.Kill();
        }
    }

    public void Trigger()
    {
        Destroy(gameObject);
    }
}
