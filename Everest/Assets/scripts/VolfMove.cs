
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VolfMove : MonoBehaviour
{
	[SerializeField] public List<Vector3> road = new List<Vector3>();
	[SerializeField] public List<float> timeWait = new List<float>();
	[SerializeField] public List<StateAnimation> Animate = new List<StateAnimation>();
	[SerializeField] public bool loop = false;
	[SerializeField] public float speed = 0.02f;
	WolfMoveLogic logic;
	WolfAnimation animation;
	
	
	void Start()
    {
		logic = GetComponent<WolfMoveLogic>();
		animation = GetComponent<WolfAnimation>();
	}

	void FixedUpdate()
	{
		if (logic.Run())
		{
			if (logic.follow == false) logic.Move(logic.GetPath());//логика для движения
			else logic.Move(logic.GetTarget());
			animation.GetAnimation();
		}
		else
		{
			GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
			animation.GetAnimation(Animate);
		}
	}

	
	public void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			logic.follow = true;
			logic.end = false;
			logic.doing = true;
		}
	}
}
