using UnityEngine;
using UnityEngine.UI;
using AssemblyCSharp;
using System.Collections;

public class Menu : MonoBehaviour
{

	private GameManager gMan;

    public Animator popMsg;

    public GameObject manne;
	
	public InputField name_field;
	public Text message;
	
	// Use this for initialization
	void Start () {
		gMan = GameObject.Find("GameManager_S").GetComponent<GameManager>();
        popMsg = GameObject.Find("MessageContainer").GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void CreatePerson() {
		if (name_field.text != "") {
			//Person newPerson = Person.create(name_field.text, 0, 0);
			//newPerson.setArea(gMan.getAreaList()[gMan.getAreaDB().findArea("Camp")]); 
            //gMan.getParty().addMember(newPerson);
            GameObject newPerson = Instantiate(manne);
            newPerson.GetComponent<Person>().createPerson(name_field.text, 0, 0);
            newPerson.GetComponent<Person>().setArea(gMan.getAreaList()[gMan.getAreaDB().findArea("Camp")]);
            newPerson.GetComponent<Person>().StartGathering();
            Debug.Log("Current place: " + newPerson.GetComponent<Person>().getArea().getName());
            gMan.getParty().addMember(newPerson);
            
		}
	}
	
	public void moveScene(string scene) {
		Application.LoadLevel(scene);
	}

	int findItem(string a) { 
		for (int i = 0; i < gMan.getIDex().Count (); i++) {
			if (gMan.getIDex().index[i].getName() == a) {
				return i;
			}
		}
		return -1;
	}
	
	public void addItem(string iName) {
		int item = findItem(iName);
		if (item != -1) {
			gMan.getParty().getInventory().addItem(gMan.getIDex().index[item], 1);
		} else {
			Debug.Log("No item to be added");
		}
	}

	public void popMessage(string m) {
		message.text = m;
        popMsg.SetTrigger("FadeIn");
	}
}

