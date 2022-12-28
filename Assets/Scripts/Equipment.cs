using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
	public void AddToInventory()
	{
		Debug.Log(string.Format("{0}를 인벤토리에 집어넣음.", gameObject.name));
		Destroy(gameObject);
	}
}
