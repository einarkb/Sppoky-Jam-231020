using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGoal : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if (ball)
        {
            Debug.Log("Reached Goal");
            ball.ReachedGoal();
            GetComponent<ParticleSystem>().Stop();
        }
    }

}
