using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTile : MonoBehaviour
{
    BoxCollider2D coll;
    SpriteRenderer sr;
    Player player;

    public float startFallingAfter = 0.2f;
    public float fallDuration = 1.5f;
    public float fallSpeed = 1f;

    private bool falling = false;
    private Vector3 startPos;


    private void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        //rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        player = collision.gameObject.GetComponent<Player>();
        if (!player || falling == true)
            return;

        if ((player.transform.position.y - collision.collider.bounds.extents.y) >= (transform.position.y + coll.size.y / 2f))
        {
            StartCoroutine(StartFalling());
        }
    }

    private IEnumerator StartFalling()
    {
        falling = true;
        yield return new WaitForSeconds(startFallingAfter);

        float curSpeed = 0.5f;
        float curDur = 0f;
        
        while (curDur < fallDuration)
        {
            //Debug.Log(curSpeed);
            //rb.MovePosition(new Vector3(transform.position.x, transform.position.y - curSpeed, 0f));
            transform.position = new Vector3(transform.position.x, transform.position.y - curSpeed * Time.deltaTime, 0f);

            curDur += Time.deltaTime;
            curSpeed += fallSpeed;// * Time.deltaTime;

            yield return new WaitForSeconds(0.0001f);
        }
        Debug.Log("moved");
        transform.position = startPos;
        falling = false;
    }

 
}
