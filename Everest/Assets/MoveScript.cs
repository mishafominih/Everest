using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public float speedAngle;
    public float speed;
    public Transform rotate;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            var v = new Vector3(0, 0, 1);
            v.x = (float)(Math.Sin(rotate.rotation.eulerAngles.y * Math.PI / 180));
            v.z = (float)(Math.Cos(rotate.rotation.eulerAngles.y * Math.PI / 180));
            transform.position -= v * speed;
        }
    }
}
