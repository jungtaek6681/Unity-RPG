using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : SingleTon<InventoryManager>
{
	[SerializeField]
	private InventoryUI ui;

	public List<InventoryItem> items;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.I))
		{
			ui.UpdateUI();
			if (ui.gameObject.activeSelf)
			{
				Cursor.lockState = CursorLockMode.Locked;
				ui.gameObject.SetActive(false);
			}
			else
			{
				Cursor.lockState = CursorLockMode.None;
				ui.gameObject.SetActive(true);
			}
		}
	}

	public override void Awake()
	{
		base.Awake();
		items = new List<InventoryItem>();
		ui.UpdateUI();
	}

	public void AddItem(Item item)
	{
		InventoryItem instance = new InventoryItem();
		items.Add(instance);
		instance.data = item.data;
		ui.UpdateUI();
	}
}
