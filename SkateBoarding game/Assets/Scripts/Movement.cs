using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float SkateSpeed = 10f;
    public float PushSpeed = 5;
    public float JumpHeight;
    bool onGround = true;
    public GameObject Player;
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        onGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        float rotation = 0f;
        transform.Translate(0, 0, SkateSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(0, 0, PushSpeed * Time.deltaTime);
        }
        if (onGround && Input.GetKeyUp(KeyCode.Space))
        {
            this.GetComponent<Rigidbody>().AddForce(Vector3.up * 350);
            onGround = false;
        }
        }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            onGround = true;
            Debug.Log("Hit");
        }
    }
}

