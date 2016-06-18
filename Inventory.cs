using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
	public int slotsX, slotsY;
	public GUISkin skin;
	public List<Item> inventory = new List<Item>();
	public List<Item> slots = new List<Item>();
	private bool showInventory;//
	private bool showTooltip;//
	private string tooltip;//

	private bool draggingItem;//
	private Item draggedItem;//
	private int prevIndex;//


	private ItemDatabase database;//


	// Use this for initialization
	void Start () 
	{
		for(int i = 0; i < (slotsX * slotsY); i++)
		{
			slots.Add(new Item());
			inventory.Add(new Item());
		}
		database = GameObject.FindGameObjectWithTag ("ItemDatabase").GetComponent<ItemDatabase> ();
		//AddItem(1);
		//AddItem(0);
		//AddItem(2);
		//AddItem(4);
		//AddItem(5);
		//QuestItemFlowerLeaf();

		//print (InventoryContains(3)); quest if(InventoryContains(3))/.......

	}

	public void QuestItemFlowerLeaf()
	{

		AddItem(3);

	}
	public void ConsumableItemH2OV2()
	{

		AddItem(5);

	}
	public void QuestItemSMGBarrel()
	{
		
		AddItem(6);
		
	}
	public void QuestItemSMGReceiver()
	{
		
		AddItem(7);
		
	}
	public void QuestItemSMGStock()
	{

		AddItem(8);
		
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Tab))
	    {
			showInventory = !showInventory;
		}
	}

	void OnGUI()
	{
		//if(GUI.Button(new Rect(40, 400, 100, 40), "Save"))
		if(Input.GetKeyDown(KeyCode.F5))
		{
			SaveInventory();
			
		}
		//if(GUI.Button(new Rect(40, 450, 100, 40), "Load"))
		if(Input.GetKeyDown(KeyCode.F7))
		{
			LoadInventory();
			//GUI.Label(new Rect(1350, 240, 200, 50), "Inventory Loaded");
		}

		tooltip = "";
		GUI.skin = skin;
		if(showInventory)
		{
			DrawInventory();
			if(showTooltip)
				GUI.Box(new Rect(Event.current.mousePosition.x + 15f, Event.current.mousePosition.y, 200, 200), tooltip, skin.GetStyle("Tooltip"));
		}
		if(draggingItem)
		{
			GUI.DrawTexture(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y, 50, 50), draggedItem.itemIcon);

		}

	}
	/*for (int i = 0; i < inventory.Count; i++) 
		{
			GUI.Label(new Rect(1350, 220 + i * 20, 200, 50), inventory[i].itemName);

		}*/

	void DrawInventory()
	{
		Event e = Event.current;
		int i = 0;
		for(int y = 0; y < slotsY; y++)
		{
			for(int x = 0; x < slotsX; x++)
			{
				Rect slotRect = new Rect(x * 60, y * 60, 50, 50);
				GUI.Box(slotRect, "", skin.GetStyle("Slot"));
				slots[i] = inventory[i];
				Item item = slots[i];
				if(slots[i].itemName != null)
				{

					GUI.DrawTexture(slotRect, slots[i].itemIcon);
					if(slotRect.Contains(e.mousePosition))
					{
						tooltip = CreateTooltip(slots[i]);
						showTooltip = true;
						if(e.button == 0 && e.type == EventType.mouseDrag && !draggingItem)
						{
							draggingItem = true;
							prevIndex = i;
							draggedItem = slots[i];
							inventory[i] = new Item();
						}
						if(e.type == EventType.mouseUp && draggingItem)
						{
							inventory[prevIndex] = inventory[i];
							inventory[i] = draggedItem;
							draggingItem = false;
							draggedItem = null;
						}
						if(e.isMouse && e.type == EventType.mouseDown && e.button == 1)
						{
							if(item.itemType == Item.ItemType.Consumable)
							{

								UseConsumable(slots[i],i,true);

							}
						}
					}
				} else {
					if(slotRect.Contains(e.mousePosition))
					{
						if(e.type == EventType.mouseUp && draggingItem)
						{
							inventory[i] = draggedItem;
							draggingItem = false;
							draggedItem = null;
						}
					}
				}
				if(tooltip == "")
				{
					showTooltip = false;
				}
				i++;
			}
		}
	}

	string CreateTooltip(Item item)
	{
		tooltip = "<color=#394DE3>" + item.itemName + "</color>\n\n" + "<color=#61BF47>" + item.itemDesc + "</color>";
		return tooltip;
	}

	void RemoveItem(int id)
	{
		for(int i = 0; i < inventory.Count; i++)
		{
			if(inventory[i].itemID == id)
			{
				inventory[i] = new Item();
				break;
			}
		}
	}


	
	void AddItem(int id)
	{
		for(int i = 0; i < inventory.Count; i++)
		{
			if(inventory[i].itemName == null)
			{
				for(int j = 0; j < database.items.Count; j++)
				{
					if(database.items[j].itemID == id)
					{
						inventory[i] = database.items[j];
					}
				}
				break;
			}
		}
	}

	bool InventoryContains(int id)
	{
		bool result = false;
		for(int i = 0; i < inventory.Count; i ++)
		{
			result = inventory[i].itemID == id;
			if(result)
			{
				break;
			}
		}
		return result;
	}
	private void UseConsumable(Item item, int slot, bool deleteItem)
	{

		switch(item.itemID)
		{
		case 5:
		{
			print ("USED ITEM " + item.itemName);
			break;
		}
		case 2:
		{
			print ("USED ITEM " + item.itemName);
			break;
		}
		case 1:
		{
			print ("USED ITEM " + item.itemName);
			break;
		}
		}
		if(deleteItem)
		{
			inventory[slot] = new Item();
		}
	}

	public void DeleteItems()
	{
		RemoveItem(6);
		RemoveItem(7);
		RemoveItem(8);

	}

	public void SaveInventory()
	{
		for(int i = 0; i < inventory.Count; i++)
			PlayerPrefs.SetInt("Inventory " + i, inventory[i].itemID);

	}

	public void LoadInventory()
	{
		for(int i = 0; i < inventory.Count; i++)
			inventory[i] = PlayerPrefs.GetInt("Inventory " + i, -1) >= 0 ? database.items[PlayerPrefs.GetInt("Inventory " + i)] : new Item();

	}
}
