using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : SingleTon<InventoryManager>
{
	private List<InventoryItem> items;

	private void Awake()
	{
		items = new List<InventoryItem>();
	}

	public void AddItem(Item item)
	{
		InventoryItem instance = new InventoryItem();
		items.Add(instance);
		instance.data = item.data;
	}
}
