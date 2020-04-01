using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    GameObject MainCamera; //аттач главной камеры для получения вектора направления движения
    public float speed; //Скорость перемещения
	public float speedClimb;//Скорость взбирания
	public int slowRotate;
    Animator anim;
	public bool isMount = false;
	public Quaternion rotate;
	Rigidbody rb;

    void Start()
    {
		rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        speed /= 100;
		speedClimb /= 100;
		MainCamera = GetComponent<Instantiater>().Camera;
    }
	
	void Update()
	{
		if (isMount) Climbing();
		else Walking();
	}

	private void Climbing()
	{
		rb.useGravity = false;
		transform.rotation = rotate;
		if (Input.GetKey(KeyCode.W))
		{
			Vector3 move = ClimbAndAnimation(1);
			move.y = speedClimb;
			transform.position += move;
		}
		else if (Input.GetKey(KeyCode.S))
		{
			Vector3 move = ClimbAndAnimation(-1);
			move.y = -speedClimb;
			transform.position += move;
		}
		else if(Input.GetKey(KeyCode.A))
		{
			Vector3 move = ClimbAndAnimation(1);
			transform.position += move;
			transform.position -= Rotate(MoveVector(gameObject.transform.rotation) * speedClimb);
		}
		else if (Input.GetKey(KeyCode.D))
		{
			Vector3 move = ClimbAndAnimation(1);
			transform.position += move;
			transform.position += Rotate(MoveVector(gameObject.transform.rotation) * speedClimb);
		}
		else anim.speed = 0;
	}
	
	private void Walking()
	{
		rb.useGravity = true;
		var moveVector = MoveVector(MainCamera.transform.rotation);
		if (Input.GetKey(KeyCode.W)) Move(moveVector, 1);
		else if (Input.GetKey(KeyCode.S)) Move(moveVector, -1);
		else anim.Play("Armature|Standing");
	}

	private void Move(Vector3 moveVector, int d)
	{
		var angle = 180 + MainCamera.transform.rotation.eulerAngles.y;
		transform.rotation = Quaternion.Euler(0, angle, 0);
		if(d<0) anim.Play("ArmatureAction");
		else anim.Play("MirrorArmatureAction");
		transform.position -= moveVector * speed * d;
	}

	private Vector3 ClimbAndAnimation(int d)
	{
		if(d > 0)anim.Play("CliffClimb");
		else anim.Play("MirrorClimb");
		anim.speed = 1;
		var move = MoveVector(gameObject.transform.rotation) * speed;
		return move;
	}

	Vector3 MoveVector(Quaternion rotation)
	{
		var v = new Vector3(0, 0, 1);
		v.x = (float)(Math.Sin(rotation.eulerAngles.y * Math.PI / 180));
		v.z = (float)(Math.Cos(rotation.eulerAngles.y * Math.PI / 180));
		return v;
	}

	Vector3 Rotate(Vector3 v)
	{
		return new Vector3(v.z, v.y, -v.x);
	}
}
