using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUnit : MonoBehaviour
{
	[SerializeField]
	private Button useButton;
	[SerializeField]
	private Button dropButton;
	[SerializeField]
	private Sprite icon;
	private InventoryItem item;

	public void AddItem(InventoryItem item)
	{
		this.item = item;
		useButton.interactable = true;
		dropButton.interactable = true;
		icon = item.data.icon;
	}

	public void RemoveItem()
	{
		this.item = null;
		useButton.interactable = false;
		dropButton.interactable = false;
		icon = null;
	}
}
