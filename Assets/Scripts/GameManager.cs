using UnityEngine;
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

		//Initialize the party
		pT = new Party();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Gather Skill: " + pT.getMembers()[0].GetComponent<Person>().getGather());
        Debug.Log("Wood: " + pT.getMembers()[0].GetComponent<Person>().getItemCount("Wood"));

        for (int i = 0; i < pT.getMembers().Count; i++)
        {

        }
	}


	/*~~~GETTERS~~~*/

	public Party getParty() {
		return pT;
	}

    public List<GameObject> getAreas()
    {
        return GetComponent<AreaDex>().AreaBase;
    }

}
