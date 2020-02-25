using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public float speed;
    public GameObject myCamera;
    public GameObject player;

    private Rigidbody rb;
    private void Start()
    {
        rb = player.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.W))
        { 
            
        }
        
    }
}
