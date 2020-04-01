using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiater : MonoBehaviour
{
	public GameObject Camera;
	public GameObject Canvas;

	void Start()
    {
		Camera = Instantiate(Camera).GetComponentInChildren<Rigidbody>().gameObject;
		Canvas = Instantiate(Canvas);
    }
}
