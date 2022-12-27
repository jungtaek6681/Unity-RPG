using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	private Collider collider;

	private void Awake()
	{
		collider = GetComponent<Collider>();
	}

	public void EnableCollider()
	{
		collider.enabled = true;
	}

	public void DisableCollider()
	{
		collider.enabled = false;
	}

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("트리거 진입");
		if (other.gameObject.name == "Cube")
		{
			Destroy(other.gameObject);
		}
	}
}
