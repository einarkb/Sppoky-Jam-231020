using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using TreeEditor;
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
    private BoxCollider2D coll;
    private SpriteRenderer renderer;
    [SerializeField] private Light2D spotLight;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        inputDir = 0;

        if (Input.GetKey(KeyCode.A))
            inputDir -= 1;
        if (Input.GetKey(KeyCode.D))
            inputDir += 1;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), -Vector3.up, coll.bounds.extents.y + 0.1f, LayerMask.GetMask("World"));
            if (hit)
            {
                Debug.Log("jumping");
                rb.AddForce(new Vector2(0f, jumpPower), ForceMode2D.Impulse);
            }
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

    


        if (Input.GetMouseButtonDown((int)MouseButton.LeftMouse))
        {
            Projectile proj = Instantiate(projectile)?.GetComponent<Projectile>();
            proj.user = gameObject;
            Rigidbody2D projRB = proj.GetComponent<Rigidbody2D>();

            projRB.transform.position = transform.position + faceToaimDirection.normalized * 2;
     

            //Physics2D.OverlapBox(coll.bounds.center, coll.bounds.size, 0f, )

            projRB.AddForce(new Vector2(faceToaimDirection.x, faceToaimDirection.y).normalized * projectileSpeed, ForceMode2D.Impulse);

            Debug.Log(faceToaimDirection);

           
        }

        rb.velocity = new Vector2(inputDir * speed, rb.velocity.y);
    }

    private void LateUpdate()
    {
      
        //transform.position += new Vector3(inputDir * speed * Time.deltaTime, 0, 0);
        //rb.AddForce(new Vector2(inputDir, 0), ForceMode2D.Force);
    }
}
