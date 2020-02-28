using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public GameObject MainCamera; //аттач главной камеры для получения вектора направления движения
    public GameObject Player; //Объект игрок
    public float speed; //Скорость перемещения
    
    private Rigidbody rb; //Физическое тело
    void Start()
    {
        rb = Player.GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        //Двигаемся вперед по вектору камеры
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(MainCamera.transform.forward * speed * Time.deltaTime);
        }
        //Движение назад по вектору камеры
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-MainCamera.transform.forward * speed * Time.deltaTime);
        }

        //Движение вправо по вектору камеры
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(MainCamera.transform.right * speed * Time.deltaTime);
        }
        //Движение влево по вектору камеры
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-MainCamera.transform.right * speed * Time.deltaTime);
        }
    }
}
