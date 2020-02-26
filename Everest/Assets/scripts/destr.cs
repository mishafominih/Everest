using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class destr : MonoBehaviour
{
	public GameObject Effect;
	Rigidbody rb;
	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		rb.useGravity = false;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Terrarian")
		{
			var a = GetComponents<BoxCollider>().Where(x => x.isTrigger == false)
				.First().isTrigger = true;
			Instantiate(Effect);
			Effect.transform.position = transform.position;
			transform.position -= new Vector3(0, 10, 0);
			Destroy(gameObject, 1);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			rb.useGravity = true;
		}
	}
}
