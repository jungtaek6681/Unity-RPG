using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InterActionAdapter : MonoBehaviour, IInteractable
{
	public UnityEvent<PlayerController> OnInterAction;

	public void Interaction(PlayerController player)
	{
		OnInterAction?.Invoke(player);
	}
}
