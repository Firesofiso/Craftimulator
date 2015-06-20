﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using AssemblyCSharp;

//CURRENT PROBLEM
/*
 * I need to figure out an elegant way to handle the giving of resources based on time.
 * Coroutines might be the answer.  I want to give each Person/Area their own coroutine.
 * The problem is that my Person class can't have a coroutine.....
 * there has to be a way I can do a coroutine for each person!!
 * 
 */

public class GameManager : MonoBehaviour {

	//this is to make sure the instance of GameManager is kept through the game.
	public static GameManager instance = null;

	//public Inventory inv;
	public Party pT;

	//data stuff
	//things to hold all the "Static" information
	public List<Recipe> recipeBook;
	public ItemDex iDex;
	public AreaDB aDex;


	//public Text wood_value;

	//Awake is always called before any Start functions
	void Awake()
	{
		//Check if there is a GameManager that has been set
		if (instance == null)
		{			
			//if not set this one as the GameManager
			instance = this;
		} else if (instance != this) {

			//if there is one set and it is different, delete this.
			Destroy(gameObject);    
		}
		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start () {

		//Initialize all the Data
		//Items & Areas & Recipes & Party
		iDex = ItemDex.Load(Path.Combine(Application.dataPath, "XML/ItemDB.xml"));
		aDex = AreaDB.Load(Path.Combine(Application.dataPath, "XML/AreaDB.xml"));
		pT = new Party();

        /*
        for (int i = 0; i < members.getMembers().Count; i++)
        {
            members.getMembers()[i].StartCoroutine("GetResource");
        }
         */

        //needs fixin'
        iniRecipeBook();

	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Gather Skill: " + pT.getMembers()[0].GetComponent<Person>().getGather());
        Debug.Log("Wood: " + pT.getMembers()[0].GetComponent<Person>().getItemCount("Wood"));

        for (int i = 0; i < pT.getMembers().Count; i++)
        {

        }
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

    public IEnumerator giveResource(Person a)
    {
        Debug.Log("Coroutine started");

        float delay;
        if (a.getGather() == 0)
        {
            delay = (float)(a.getArea().getDelay());
        }
        else
        {
            delay = (float)(a.getArea().getDelay() * a.getGather() * 0.05);
        }
        if (a.getArea().getName() != "Camp")
        {
            a.obtainItem(a.getArea().getResource());
            yield return new WaitForSeconds(1f);
        }
    }

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
			pT.getInventory().addItem(iDex.index[item], 1);
		} else {
			Debug.Log("No item to be added");
		}
	}


	/*~~~GETTERS~~~*/

	public Party getParty() {
		return pT;
	}

	public ItemDex getIDex() {
		return iDex;
	}

	public List<Area> getAreaList() {
		return aDex.getAreaList();
	}

	public AreaDB getAreaDB() {
		return aDex;
	}

}
