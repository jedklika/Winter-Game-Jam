using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    public float SkateSpeed = 10f;
    public float PushSpeed = 5;
    bool Ongroud = true;
    bool Onboard = true;
    public GameObject Player;
    public float rotationSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        float rotation = 0f;
        transform.Translate(0, 0, SkateSpeed* Time.deltaTime);
        if (Input.GetMouseButtonDown(0))
        {
            transform.Translate(0, 0, PushSpeed * Time.deltaTime);
        }
    }
}

