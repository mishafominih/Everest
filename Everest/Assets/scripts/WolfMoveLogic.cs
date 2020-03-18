using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfMoveLogic : MonoBehaviour
{
	public bool follow = false;
	public int index;
	public bool end = false;
	public bool doing = true;


	bool moveNext = false;
	float timer = 0;
	bool Rotate = true;
	Vector3 target;
	Rigidbody rb;
	VolfMove volf;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		volf = GetComponent<VolfMove>();
	}

	public bool Run()
	{
		if (end == true) return false;
		if ((timer <= GetWait() && doing == false))//включение таймера
		{
			timer += Time.deltaTime;
			return false;
		}
		return doing = true;
	}

	public void Move(Vector3 target)
	{
		float deltaX = target.x - transform.position.x;
		float deltaZ = target.z - transform.position.z;
		if (Mathf.Abs(deltaX) >= 0.5 || Mathf.Abs(deltaZ) >= 0.5)
		{
			if (end != true)
			{
				float angle = Mathf.Atan2(deltaZ, deltaX);
				if (Rotate)
					rb.rotation = Quaternion.Euler(rb.rotation.x, 90 - angle * 180 / Mathf.PI, 0);
				transform.position += new Vector3(volf.speed * Mathf.Cos(angle), 0,
					volf.speed * Mathf.Sin(angle));
				moveNext = false;
				Rotate = false;
			}
		}
		else
		{
			if (follow == true)
			{
				Destroy(GameObject.FindGameObjectsWithTag("Player")[0]);
				follow = false;
			}
			else
			{
				moveNext = true;
				doing = false;
				timer = 0;
				Rotate = true;
			}
		}
	}

	public Vector3 GetPath()
	{
		if (moveNext == true)
		{
			if (volf.road.Count <= index + 1)
			{
				if (volf.loop == false)
				{
					end = true;
					return new Vector3();
				}
				index = 0;
				return volf.road[index];
			}
			index++;
			return volf.road[index];
		}
		if (volf.road.Count == 0)
		{
			end = true;
			return new Vector3();
		}
		return volf.road[index];
	}

	public float GetWait()
	{
		if (index <= volf.timeWait.Count)
		{
			return volf.timeWait[index];
		}
		return 0;
	}

	public Vector3 GetTarget()
	{
		Rotate = true;
		return GameObject.FindGameObjectsWithTag("Player")[0].transform.position;
	}
}
