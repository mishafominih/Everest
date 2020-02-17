using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destr : MonoBehaviour
{
	public GameObject Effect;

	private void OnTriggerEnter(Collider other)
	{
		Instantiate(Effect);
		Effect.transform.position = transform.position;
		transform.position -= new Vector3(0, 10, 0);
		Destroy(gameObject, 1);
	}
}
