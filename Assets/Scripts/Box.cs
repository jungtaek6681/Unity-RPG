using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, IInteractable
{
	public void Interaction(PlayerController player)
	{
		Debug.Log(string.Format("{0}가 {1}와 상호작용하여 열림.", gameObject.name, player.gameObject.name));
	}
}
