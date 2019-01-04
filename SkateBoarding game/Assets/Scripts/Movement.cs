using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float SkateSpeed = 20f;
    public float PushSpeed = 25f;
    bool onGround = true;
    public GameObject Player;
    public float rotationSpeed;
    public float Sensitivity = 2f;

    // Start is called before the first frame update
    void Start()
    {
        onGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (onGround == true)
        {
            transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * Time.deltaTime * Sensitivity);
        }
        float rotation = 0f;
        transform.Translate(0, 0, SkateSpeed * Time.deltaTime);
        if (onGround && Input.GetMouseButton(0))
        {
            transform.Translate(0, 0, PushSpeed * Time.deltaTime);
            onGround = true;
        }
        if (onGround && Input.GetKeyDown(KeyCode.Space))
        {
            this.GetComponent<Rigidbody>().AddForce(Vector3.up * 250);
            onGround = false;
        }
        else
        {
            onGround = true;
        }
    }
}

