using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp;

public class Dispatch : MonoBehaviour
{
	public GameManager gMan;
	Menu menuScript;
	//GameObject popMsg;

	Party p;
	List<GameObject> m;
	//text to display name
	public Text mName_T;
	public Button area_B;

	// Use this for initialization
	void Start ()
	{

		//Find the game manager
		gMan = GameObject.Find ("GameManager_S").GetComponent<GameManager>();
		p = gMan.getParty();
		m = p.getMembers();

		//Find the Menu Script
		menuScript = GameObject.Find("MenuObject").GetComponent<Menu>();
		//popMsg = GameObject.Find ("MessageContainer");

        

		//Call display function
		display();
        transform.localScale = new Vector3((float)0.07029877, (float)0.07029877, 1);
	}
	
	// Update is called once per frame
	void Update ()
	{
		Debug.Log(m[0].GetComponent<Person>().getArea().getName());
	}

	//Displays party members and their locations
	//Buttons to choose what area to send them to
	void display() {

		//Debug.Log("Display Start");

		//this is the next position to place a text at
		Vector3 lastPosition = this.transform.position;

		for(int i = 0; i < m.Count; i++) {

			//get the name for each member in the party
            mName_T.text = m[i].GetComponent<Person>().getName();

			//the first one is instantiated at this scripts position
			//otherwise instantiate them down 150 pixels.
			if (i == 0) {

				//Instantiate the member name
				Text newClone = Instantiate(mName_T, this.transform.position, Quaternion.identity) as Text;

				//Need to set the parent so that it doesn't end up all the way off the screen
				newClone.transform.SetParent(this.transform);

				//Starting position to start instantiating the buttons
				Vector3 bStartPos = new Vector3(this.transform.position.x + 50, this.transform.position.y);
				Vector3 lastPos = bStartPos;

				//This is essentially the same thing we do for the Name of the people
				//but for the Area buttons instead
				for (int j = 0; j < gMan.getAreas().Count; j++) {
					if (j == 0) {
						
						//Instantiate
						Button newButton = Instantiate(area_B, bStartPos, Quaternion.identity) as Button;

						//Sets the text of the button to be the name of the Area
                        newButton.GetComponentInChildren<Text>().text = gMan.getAreas()[j].GetComponent<Area>().getName();

						//Grab the necessary info for the buttons function
						Person a = m[i].GetComponent<Person>();
						Area b = gMan.getAreas()[j].GetComponent<Area>();

						//Set the onclick function for each button.
						newButton.onClick.AddListener(() => moveMember(a, b));

						//Make sure its not off the screen/has the position of its parent in the hierarchy
						newButton.transform.SetParent(this.transform);
					} else {

						//this is so that the buttons are spaced properly
						lastPos = new Vector3(lastPos.x + 100, lastPos.y);
						
						//Instantiate
						Button newButton = Instantiate(area_B, lastPos, Quaternion.identity) as Button;

						//Sets the text of the button to be the name of the Area
                        newButton.GetComponentInChildren<Text>().text = gMan.getAreas()[j].GetComponent<Area>().getName();

						//Grab the necessary info for the buttons function
						Person a = m[i].GetComponent<Person>();
						Area b = gMan.getAreas()[j].GetComponent<Area>();

						//Set the onclick function for each button.
						newButton.onClick.AddListener(() => moveMember(a, b));

						//Make sure its not off the screen/has the position of its parent in the hierarchy
						newButton.transform.SetParent(this.transform);
					}
				}
				//InstantiateButtons();
			} else {

				//reposition the next members info lower than the original
				lastPosition = new Vector3(lastPosition.x, lastPosition.y - 150);

				//Instantiate the member name
				Text newClone = Instantiate(mName_T, lastPosition, Quaternion.identity) as Text;

				//Need to set the parent so that it doesn't end up all the way off the screen
				newClone.transform.SetParent(this.transform);

				//Starting position to start instantiating the buttons
				Vector3 bStartPos = new Vector3(this.transform.position.x + 50, this.transform.position.y);
				Vector3 lastPos = bStartPos;
				
				for (int j = 0; j < gMan.getAreas().Count; j++) {
					if (j == 0) {
						
						//Instantiate
						Button newButton = Instantiate(area_B, bStartPos, Quaternion.identity) as Button;
                        newButton.GetComponentInChildren<Text>().text = gMan.getAreas()[j].GetComponent<Area>().getName();
						newButton.transform.SetParent(this.transform);
					} else {
						
						lastPos = new Vector3(lastPos.x + 100, lastPos.y);
						
						//Instantiate
						Button newButton = Instantiate(area_B, lastPos, Quaternion.identity) as Button;
                        newButton.GetComponentInChildren<Text>().text = gMan.getAreas()[j].GetComponent<Area>().getName();
						
						newButton.transform.SetParent(this.transform);
					}
				}

				//InstantiateButtons();
			}
		}

		//Debug.Log("Display End");
	}

	//Instantiate the area buttons
	void InstantiateButtons() {

		//Starting position to start instantiating the buttons
		Vector3 bStartPos = new Vector3(this.transform.position.x + 50, this.transform.position.y);
		Vector3 lastPos = bStartPos;

		for (int j = 0; j < gMan.getAreas().Count; j++) {
			if (j == 0) {

				//Instantiate
				Button newButton = Instantiate(area_B, bStartPos, Quaternion.identity) as Button;
                newButton.GetComponentInChildren<Text>().text = gMan.getAreas()[j].GetComponent<Area>().getName();
				newButton.transform.SetParent(this.transform);
			} else {

				lastPos = new Vector3(lastPos.x + 100, lastPos.y);

				//Instantiate
				Button newButton = Instantiate(area_B, lastPos, Quaternion.identity) as Button;
                newButton.GetComponentInChildren<Text>().text = gMan.getAreas()[j].GetComponent<Area>().getName();

				newButton.transform.SetParent(this.transform);
			}
		}
	}


    //this function moves member, a, to area, b
	void moveMember(Person a, Area b) {
		a.setArea(b);

        string message = a.getName() + " moved to " + b.getName();

		menuScript.popMessage(message);
	}
}

