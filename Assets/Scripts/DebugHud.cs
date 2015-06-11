﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using AssemblyCSharp;

public class DebugHud : MonoBehaviour {

	public GameManager gMan;

	public Text wood_v, ironOre_v;

	// Use this for initialization
	void Start () {
		gMan = GameObject.Find("GameManager_S").GetComponent<GameManager>();
		wood_v.text = "0";
		ironOre_v.text = "0";
	}

	// Update is called once per frame
	void Update () {
		if (gMan.members.getInventory().exists(new Item("Wood", 1))) {
			wood_v.text = "" + gMan.members.getInventory().getItems()[gMan.members.getInventory().itemIndex(new Item("Wood", 1))].getCount();
		}
		if (gMan.members.getInventory().exists(new Item("Iron Ore", 1))) {
			ironOre_v.text = "" + gMan.members.getInventory().getItems()[gMan.members.getInventory().itemIndex(new Item("Iron Ore", 1))].getCount();
		}
	}
}
