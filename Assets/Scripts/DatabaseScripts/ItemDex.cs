using UnityEngine;
using AssemblyCSharp;
using System.Collections;
using System.Collections.Generic;

public class ItemDex : MonoBehaviour {


    //Just going to plop all the item prefabs in here easy..
    public List<GameObject> ItemBase;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool doesExist(string itemName)
    {
        for (int i = 0; i < ItemBase.Count; i++)
        {
            if (itemName == ItemBase[i].GetComponent<Item>().getName())
            {
                return true;
            }
        }
        return false;
    }

    public GameObject findItem(string itemName)
    {
        for (int i = 0; i < ItemBase.Count; i++)
        {
            if (itemName == ItemBase[i].GetComponent<Item>().getName())
            {
                return ItemBase[i];
            }
        }
        return null;  
    }
}
