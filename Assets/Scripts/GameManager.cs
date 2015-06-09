using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using AssemblyCSharp;

public class GameManager : MonoBehaviour {

	public Inventory inv;
	public List<Recipe> recipeBook;
	public ItemDex iDex;

	//public Text wood_value;


	// Use this for initialization
	void Start () {
		inv = new Inventory();

		iDex = ItemDex.Load(Path.Combine(Application.dataPath, "XML/database.xml"));
		iniRecipeBook();

		//wood_value.text = "0";
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	/*DEPRECATED
	void iniItemDex() {
		itemDex = new List<Item>();
		Item wood = new Item("Wood", 0);
		itemDex.Add(wood);
		Item iron_ore = new Item("Iron Ore", 0);
		itemDex.Add(iron_ore);
		Item wood_plank = new Item("Wood Plank", 0);
		itemDex.Add(wood_plank);
		Item iron_bar = new Item("Iron Bar", 0);
		itemDex.Add(iron_bar);
		Item iron_sword = new Item("Iron Sword", 0);
		itemDex.Add(iron_sword);

	}
	*/

	void iniRecipeBook() {
		recipeBook = new List<Recipe>();

		Recipe wood_plank_R = new Recipe(iDex.index[0], iDex.index[0], iDex.index[2]);
		Recipe iron_bar_R = new Recipe(iDex.index[1], iDex.index[1], iDex.index[3]);
		Recipe iron_sword_R = new Recipe(iDex.index[3], iDex.index[2], iDex.index[4]);

		recipeBook.Add(wood_plank_R);
		recipeBook.Add(iron_bar_R);
		recipeBook.Add(iron_sword_R);
	}

	int findItem(string a) { 
		for (int i = 0; i < iDex.Count (); i++) {
			if (iDex.index[i].getName() == a) {
				return i;
			}
		}
		return -1;
	}
	
	public void addItem(string iName) {
		int item = findItem(iName);
		if (item != -1) {
			inv.addItem(iDex.index[item], 1);
		} else {
			Debug.Log("No item to be added");
		}
	}

	public void addWood() {
		inv.addItem(iDex.index[0], 1);
	}
}
