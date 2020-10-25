using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    private int inputDir = 0;
    private bool isAirborne = false;
    public int speed = 1;
    public float jumpPower = 50;
    public float projectileSpeed = 6;
    private Rigidbody2D rb;
    public GameObject projectile;
    private CapsuleCollider2D coll;
    private SpriteRenderer renderer;
    [SerializeField] private Light2D spotLight;
    public bool isControllsLocked = false;

    bool canFire = true;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        inputDir = 0;
        if (isControllsLocked == false)
        {

            if (Input.GetKey(KeyCode.A))
                inputDir -= 1;
            if (Input.GetKey(KeyCode.D))
                inputDir += 1;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (Physics2D.OverlapBox(new Vector2(transform.position.x, transform.position.y - coll.bounds.extents.y - 0.05f), new Vector2(coll.size.x, 0.1f), 0f, LayerMask.GetMask("World")) != null)
                {
                    Debug.Log("jumping");
                    //rb.AddForce(new Vector2(0f, jumpPower), ForceMode2D.Impulse);
                    rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                }

                /*RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), -Vector3.up, coll.bounds.extents.y + 0.5f, LayerMask.GetMask("World"));
                if (hit)
                {
                    Debug.Log("jumping");
                    rb.AddForce(new Vector2(0f, jumpPower), ForceMode2D.Impulse);
                }*/
            }

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            Vector3 faceToaimDirection = mousePos - transform.position;
            Vector2 faceToAimNormalized = new Vector2(faceToaimDirection.x, faceToaimDirection.y).normalized;

            if (faceToAimNormalized.x < 0)
            {
                renderer.flipX = true;
            }
            else if (faceToAimNormalized.x > 0)
            {
                renderer.flipX = false;
            }




            if (canFire && Input.GetMouseButtonDown((int)MouseButton.LeftMouse))
            {
                Projectile proj = Instantiate(projectile)?.GetComponent<Projectile>();
                proj.user = gameObject;
                Rigidbody2D projRB = proj.GetComponent<Rigidbody2D>();

                projRB.transform.position = transform.position + faceToaimDirection.normalized * 2;


                //Physics2D.OverlapBox(coll.bounds.center, coll.bounds.size, 0f, )

                projRB.AddForce(new Vector2(faceToaimDirection.x, faceToaimDirection.y).normalized * projectileSpeed, ForceMode2D.Impulse);

                StartCoroutine(FireLock());


            }

            if (Input.GetMouseButtonDown((int)MouseButton.RightMouse))
            {
                GetComponent<SpecialLightManager>()?.SwitchLight();
         
            }
        }

        rb.velocity = new Vector2(inputDir * speed, rb.velocity.y);
    }

    private void LateUpdate()
    {
      
        //transform.position += new Vector3(inputDir * speed * Time.deltaTime, 0, 0);
        //rb.AddForce(new Vector2(inputDir, 0), ForceMode2D.Force);
    }

    private IEnumerator FireLock()
    {
        canFire = false;
        yield return new WaitForSeconds(0.4f);
        canFire = true;
    }
}
