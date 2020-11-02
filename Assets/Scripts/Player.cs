using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int deathCount = 0;
    public Vector2 respawnPoint = new Vector2(0f, 0f);
    public TextMeshProUGUI deathsText;

    public void KillPlayer()
    {
        deathCount += 1;
        transform.position = new Vector3(respawnPoint.x, respawnPoint.y, 0f);
        deathsText.text = "Deaths: " + deathCount.ToString();
    }
}
