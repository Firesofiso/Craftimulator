using UnityEngine;
using UnityEngine.UI;
using AssemblyCSharp;
using System.Collections;

public class InventoryMenu : MonoBehaviour {

    public GameManager gMan;
    
    //Partay stuff
    Party pT;
    public Transform ptMenuStart;
    public Button dynaButton;
    
    //person texts
    public Button itemButton;
    public Text personName;

    //item stuff
    public Text itemText;

	// Use this for initialization
	void Start () {
        gMan = GameObject.Find("GameManager_S").GetComponent<GameManager>();
        pT = gMan.getParty();
        Person activePerson = gMan.getParty().getMembers()[0].GetComponent<Person>();
        //transform.localScale = new Vector3((float)0.075, (float)0.075, 1);
        displayParty();
        iniPartyInventory();
        iniPersonInventory(activePerson);
        transform.localScale = new Vector3((float)0.07029877, (float)0.07029877, 1);
        

	}
	
	// Update is called once per frame
	void Update () {

	}


    public void iniPartyInventory()
    {
        int rows = pT.getInventory().getMax() / 10;
        int columns = 10;

        int iniX = 50;

        Vector3 titlePos = new Vector3(transform.position.x + 275, transform.position.y + 130);
        Text title = Instantiate(personName, titlePos, Quaternion.identity) as Text;
        title.text = "Party";
        title.fontSize = 20;
        title.transform.SetParent(this.transform);

        Vector3 lastPosition = new Vector3(transform.position.x + iniX, transform.position.y + 80);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (j == 0)
                {
                    Button newItem = Instantiate(itemButton, lastPosition, Quaternion.identity) as Button;
                    newItem.transform.SetParent(this.transform);
                }
                else
                {
                    Vector3 newPosition = new Vector3(lastPosition.x + 50, lastPosition.y);
                    Button newItem = Instantiate(itemButton, newPosition, Quaternion.identity) as Button;
                    newItem.transform.SetParent(this.transform);
                    lastPosition = newPosition;
                }
            }

            //vertical spacing
            lastPosition.y -= 50;

            //reset to the x position
            lastPosition.x = transform.position.x + iniX;
        }
    }

    public void iniPersonInventory(Person a)
    {
        //Debug.Log("Person inventory start");

        Vector3 titlePos = new Vector3(transform.position.x - 200, transform.position.y + 130);
        Text title = Instantiate(personName, titlePos, Quaternion.identity) as Text;
        title.text = a.getName();
        title.fontSize = 20;
        title.transform.SetParent(this.transform);

        Vector3 lastPosition = new Vector3(transform.position.x - 225, transform.position.y + 80);

        for (int i = 0; i < 4; i++)
        {
            //Debug.Log("Row loop start");
            for (int j = 0; j < 2; j++)
            {
                //Debug.Log("column loop start");
                if (j == 0)
                {
                    Button newItem = Instantiate(itemButton, lastPosition, Quaternion.identity) as Button;
                    Text newCountText = Instantiate(itemText, new Vector3(lastPosition.x + 16, lastPosition.y - 12, 0), Quaternion.identity) as Text;


                    //as long as the indices are less than the count in the bag
                    //this code will be run.
                    if (i * (j + 1) < a.getBag().Count())
                    {
                        newCountText.text = "" + a.getBag().item(i * (j + 1)).GetComponent<Item>().getCount();
                        newCountText.transform.SetParent(newItem.transform);
                        GameObject item = Instantiate(a.getBag().item(i * (j + 1)), lastPosition, Quaternion.identity) as GameObject;
                        item.transform.SetParent(newItem.transform);
                    }
                    newItem.transform.SetParent(this.transform);
                }
                else
                {
                    Vector3 newPosition = new Vector3(lastPosition.x + 50, lastPosition.y);
                    Button newItem = Instantiate(itemButton, newPosition, Quaternion.identity) as Button;
                    Text newCountText = Instantiate(itemText, newPosition + new Vector3(75, 0, 0), Quaternion.identity) as Text;
                    //newItemText.text = a.getBag().getItems()[i].getName();
                    //newCountText.text = a.getBag().item(i).getName();
                    newItem.transform.SetParent(this.transform);
                    newCountText.transform.SetParent(this.transform);
                    lastPosition = newPosition;
                }
                //Debug.Log("column loop end");
            }
            

            //Spacing
            lastPosition.y -= 50;

            lastPosition.x = transform.position.x - 225;
            //Debug.Log("Row loop end");
        }

        //Debug.Log("Person inventory end");
    }

    public void displayParty()
    {
        Vector3 lastPosition = ptMenuStart.position + new Vector3(-400, 150, 0);

        for (int i = 0; i < pT.getMembers().Count; i++)
        {
            if (i == 0)
            {
                Button newMember = Instantiate(dynaButton, lastPosition, Quaternion.identity) as Button;
                newMember.transform.SetParent(ptMenuStart);
                newMember.GetComponentInChildren<Text>().text = pT.getMembers()[i].GetComponent<Person>().getName();
            }
            else
            {
                Vector3 newPosition = new Vector3(lastPosition.x, lastPosition.y + 35);
                Button newMember = Instantiate(dynaButton, newPosition, Quaternion.identity) as Button;
                newMember.transform.SetParent(ptMenuStart);
                newMember.GetComponentInChildren<Text>().text = pT.getMembers()[i].GetComponent<Person>().getName();
                lastPosition = newPosition;
            }
        }
    }

}
