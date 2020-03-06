
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VolfMove : MonoBehaviour
{
	[SerializeField] public List<Vector3> road = new List<Vector3>();
	[SerializeField] public List<float> timeWait = new List<float>();
	[SerializeField] public List<StateAnimation> Animate = new List<StateAnimation>();
	[SerializeField] bool loop = false;
	[SerializeField] float speed = 0.02f;

	int index;
	bool moveNext = false;
	bool end = false;
	float timer = 0;
	bool doing = true;
	Rigidbody rb;
	bool Rotate = true;
	bool follow = false;
	Vector3 target;
	void Start()
    {
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		if (timer <= GetWait() && doing == false)//включение таймера
		{
			timer += Time.deltaTime;
			GetComponent<WolfAnimation>().GetAnimation(Animate, index);
		}
		else
			doing = true;
		if (end == false && doing == true)
		{
			Move();//логика для движения
			GetComponent<WolfAnimation>().GetAnimation();
		}
		else
		{
			rb.velocity = new Vector3(0, 0, 0);
			if (end == true)
				GetComponent<WolfAnimation>().GetAnimation(Animate, index);
		}
	}

	void Move()
	{
		var path = new Vector3();
		if (follow == false) path = GetPath();
		else path = UpdateValue();
		float deltaX = path.x - transform.position.x;
		float deltaZ = path.z - transform.position.z;
		if (Mathf.Abs(deltaX) >= 0.3 || Mathf.Abs(deltaZ) >= 0.3)
		{
			if (end != true)
			{
				float angle = Mathf.Atan2(deltaZ, deltaX);
				if (Rotate)
					rb.rotation = Quaternion.Euler(rb.rotation.x, 90 - angle * 180 / Mathf.PI, 0);
				transform.position += new Vector3(speed * Mathf.Cos(angle), 0,
					speed * Mathf.Sin(angle));
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

	Vector3 GetPath()
	{
		if(moveNext == true)
		{
			if (road.Count <= index + 1)
			{
				if (loop == false)
				{
					end = true;
					return new Vector3();
				}
				index = 0;
				return road[index];
			}
			index++;
			return road[index];
		}
		if (road.Count == 0)
		{
			end = true;
			return new Vector3();
		}
		return road[index];
	}

	float GetWait()
	{
		if(index <= timeWait.Count)
		{
			return timeWait[index];
		}
		return 0;
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			follow = true;
			end = false;
		}
	}

	Vector3 UpdateValue()
	{
		Rotate = true;
		return GameObject.FindGameObjectsWithTag("Player")[0].transform.position;
	}
}
