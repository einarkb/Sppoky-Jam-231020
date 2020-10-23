using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private int inputDir = 0;
    public int speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputDir = 0;

        if (Input.GetKey(KeyCode.A))
            inputDir -= 1;
        if (Input.GetKey(KeyCode.D))
            inputDir += 1;
    }

    private void LateUpdate()
    {
        transform.position += new Vector3(inputDir * speed * Time.deltaTime, 0, 0);
    }
}
