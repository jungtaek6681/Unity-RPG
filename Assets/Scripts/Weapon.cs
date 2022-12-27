using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	private new Collider collider;

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
}
