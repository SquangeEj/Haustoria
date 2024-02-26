using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class ItemClass : ScriptableObject
{
	public GameObject itemPrefab;
	public Sprite itemSprite;
    public string itemName;
    public bool isStackable = true;
    public bool isEquipable = false;
	[SerializeField] private Button slotButton;

	public Sprite GetSprite()
	{
		return itemSprite;
	}

	public string GetName()
	{
		return itemName;
	}

	public GameObject GetPrefab()
	{
		return itemPrefab;
	}
}

