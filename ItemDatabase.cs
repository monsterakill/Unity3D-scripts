using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {
	public List<Item> items = new List<Item>();

	void Start()
	{
		items.Add(new Item("Sword of Likaretsnom", 0, "Sword of God", 2, 0, Item.ItemType.Weapon));
		items.Add(new Item("Apple", 1, "Fresh Red Apple", 0, 0, Item.ItemType.Consumable));
		items.Add(new Item("Small Potion", 2, "Restore 25 Health", 0, 0, Item.ItemType.Consumable));
		items.Add(new Item("Flower Leaf", 3, "Quest Item", 0, 0, Item.ItemType.Quest));
		items.Add(new Item("Map", 4, "World Map", 0, 0, Item.ItemType.Quest));
		items.Add(new Item("H2O", 5, "Restore 25 Oxygen", 0, 0, Item.ItemType.Consumable));
		items.Add(new Item("SMG Barrel", 6, "SMG Part", 0, 0, Item.ItemType.Quest));
		items.Add(new Item("SMG Receiver", 7, "SMG Part", 0, 0, Item.ItemType.Quest));
		items.Add(new Item("SMG Stock", 8, "SMG Part", 0, 0, Item.ItemType.Quest));

	}
	
}
