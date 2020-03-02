using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public GameObject MainCamera; //аттач главной камеры для получения вектора направления движения
    public float speed; //Скорость перемещения
    public int slowRotate;
    Animator anim;
    bool isMove;

    void Start()
    {
        isMove = false;
        anim = GetComponent<Animator>();
        speed /= 10; 
    }

    Vector3 MoveVector()
    {
        var v = new Vector3(0, 0, 1);
        v.x = (float)(Math.Sin(MainCamera.transform.rotation.eulerAngles.y * Math.PI / 180));
        v.z = (float)(Math.Cos(MainCamera.transform.rotation.eulerAngles.y * Math.PI / 180));
        return v;
    }
    void FixedUpdate()
    {
        var moveVector = MoveVector();
        //Двигаемся вперед по вектору камеры
        if (Input.GetKey(KeyCode.W))
        {
            isMove = true;
            anim.Play("ArmatureAction");
            transform.position -= moveVector * speed;
        }
        else if (Input.GetKey(KeyCode.S))//Движение назад по вектору камеры
        {
            isMove = true;
            anim.Play("ArmatureAction");
            transform.position += moveVector * speed;
        }
        else
        {
            isMove = false;
            anim.Play("Armature|Standing");
        }
        if(isMove)
            if (transform.rotation.y != MainCamera.transform.rotation.y)
            {
                var angle =  180 + MainCamera.transform.rotation.eulerAngles.y;
                transform.rotation = Quaternion.Euler(0, angle, 0);
            }
    }
}
