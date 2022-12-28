using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : SingleTon<InventoryManager>
{
	private List<Item> items;

	private void Awake()
	{
		items = new List<Item>();
	}

	public void AddItem(Item item)
	{
		items.Add(item);
	}
}
