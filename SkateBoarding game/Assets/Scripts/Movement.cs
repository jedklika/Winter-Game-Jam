using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    public float SkateSpeed = 10f;
    public float PushSpeed = 5;
    bool Ongroud = true;
    bool Onboard = true;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {   float rotation = 0;
        transform.Translate(Vector3.forward * PushSpeed * Time.deltaTime);
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Faster");
            transform.Translate(Vector3.forward * SkateSpeed * Time.deltaTime);
            Debug.Log("Go");
        } 
    }
}

