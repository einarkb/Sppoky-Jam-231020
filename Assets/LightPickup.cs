using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPickup : MonoBehaviour
{
    public SpecialLight specialLight;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        collision.gameObject.GetComponent<SpecialLightManager>()?.Add(specialLight);
    }
}
