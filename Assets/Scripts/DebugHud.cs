using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using AssemblyCSharp;

public class DebugHud : MonoBehaviour {

	public GameManager gMan;

	public Text wood_v, ironOre_v;

    Party p;

	// Use this for initialization
	void Start () {
		gMan = GameObject.Find("GameManager_S").GetComponent<GameManager>();
		wood_v.text = "0";
		ironOre_v.text = "0";
        p = gMan.getParty();
        
	}

	// Update is called once per frame
	void Update () {
        wood_v.text = "" + p.getMembers()[0].GetComponent<Person>().getItemCount("Wood");
		if (gMan.getParty().getInventory().exists(new Item("Iron Ore", 1))) {
            ironOre_v.text = "" + p.getMembers()[0].GetComponent<Person>().getItemCount("Iron Ore");
		}
	}
}
