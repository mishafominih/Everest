using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsMount : MonoBehaviour
{
	private void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player")
		{
			other.gameObject.GetComponent<MoveScript>().isMount = true;
			other.gameObject.GetComponent<MoveScript>().rotate = transform.rotation;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
			other.gameObject.GetComponent<MoveScript>().isMount = false;
	}
}
