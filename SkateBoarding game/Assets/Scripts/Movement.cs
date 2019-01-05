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
    bool inAir;
    bool onRail;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * Time.deltaTime * Sensitivity);
        float rotation = 0f;
        transform.Translate(0, 0, SkateSpeed * Time.deltaTime);
        if (onGround && Input.GetMouseButton(0))
        {
            transform.Translate(0, 0, PushSpeed * Time.deltaTime);
            
        }
        if (onGround && Input.GetMouseButton(1))
        {
                this.GetComponent<Rigidbody>().AddForce(Vector3.up * 400);
            onGround = false;
            inAir = true;
            
        }
        if(transform.position.y >= 4.9){
            onGround = false;
            inAir = true;
        }
        if(inAir && Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("KickFlip");
        }
        if (inAir && Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("HeelFlip");
        }
        if (onGround && Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Mannual");
        }
        if (inAir && Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("Impossible");
        }
        if (inAir && Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("Melon");
        }
        if (inAir && Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("TailGrab");
        }
        if (inAir && Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Pop It shove it");
        }
        if (inAir && Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log("indy");
        }
        if (inAir && Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("Nosegrab");
        }
        if (onRail && Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("crooked");
        }
        if (onRail && Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Smith");
        }

    }
     void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            onGround = true;
            inAir = false;
            onRail = false;
        }
        if (other.gameObject.CompareTag("Rail"))
        {
            onGround = true;
            inAir = false;
            onRail = true;
            Debug.Log("Grind");
        }
    }
}

