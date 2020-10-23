using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class Projectile : MonoBehaviour
{

    public GameObject mainLight;
    public float lifeDuration = 5;
    public bool destroyOnHit = false;


    void Start()
    {
        StartCoroutine(DestroyProjectileAfterTime(lifeDuration));
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (destroyOnHit == true)
        {
            Destroy(mainLight);
            Destroy(GetComponent<Rigidbody2D>());
            GetComponent<Collider>().enabled = false;
            
        }
    }


    private IEnumerator DestroyProjectileAfterTime(float t)
    {
        yield return new WaitForSeconds(t);
        Destroy(gameObject);
    }
}
