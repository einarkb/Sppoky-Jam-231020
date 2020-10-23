using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TreeEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    private int inputDir = 0;
    private bool isAirborne = false;
    public int speed = 1;
    public float projectileSpeed = 6;
    private Rigidbody2D rb;
    public GameObject projectile;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        inputDir = 0;

        if (Input.GetKey(KeyCode.A))
            inputDir -= 1;
        if (Input.GetKey(KeyCode.D))
            inputDir += 1;

        if (Input.GetMouseButtonDown((int)MouseButton.LeftMouse))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Rigidbody2D projRB = Instantiate(projectile)?.GetComponent<Rigidbody2D>();
            Vector3 direction = mousePos - transform.position;

            projRB.transform.position = transform.position + direction.normalized * 2;
     
            projRB.AddForce(new Vector2(direction.x, direction.y).normalized * projectileSpeed, ForceMode2D.Impulse);
            Debug.Log(direction);
        }
    }

    private void LateUpdate()
    {
        transform.position += new Vector3(inputDir * speed * Time.deltaTime, 0, 0);
        rb.AddForce(new Vector2(inputDir, 0), ForceMode2D.Force);
    }
}
