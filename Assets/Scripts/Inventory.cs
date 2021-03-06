//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{
	public class Inventory
	{
		private List<GameObject> items;

        int max = 30;

		public Inventory ()
		{
			items = new List<GameObject>();
            items.Capacity = max;
		}

		//finds the index of an item in the inventory
		public int itemIndex(GameObject toIndex) {
			for (int i = 0; i < items.Count; i++) {
				if (items[i] == toIndex) {
					return i;
				}
			}
			return -1;
		}

        public int itemIndex(string toIndex)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].GetComponent<Item>().getName() == toIndex)
                {
                    return i;
                }
            }
            return -1;
        }

		//this function checks if there is an item in the inventory
		public bool exists(GameObject doesExist) {
			for (int i = 0; i < items.Count; i++) {
				if (items[i] == doesExist) {
					return true;
				}
			}
			return false;
		}

        public bool exists(string doesExist)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].GetComponent<Item>().getName() == doesExist)
                {
                    return true;
                }
            }
            return false;
        }

		//adds x amount of items to the inventory
		public void addItem(GameObject toAdd, int number) {
            if (exists(toAdd))
            {
                items[itemIndex(toAdd)].GetComponent<Item>().addCount(number);
            }
            else if (Count() + 1 <= max)
            {
                toAdd.GetComponent<Item>().setCount(number);
                items.Add(toAdd);
            }
            else
            {
                GameObject.Find("MenuObject").GetComponent<Menu>().popMessage("Inventory is full");
            }
		}

       

        //this adds an object
		public void addItem(GameObject toAdd) {
            if (exists(toAdd))
            {
                Debug.Log("Adding Count");
                items[itemIndex(toAdd)].GetComponent<Item>().addCount(toAdd.GetComponent<Item>().getCount());
                Debug.Log("Item Count: " + items[itemIndex(toAdd)].GetComponent<Item>().getCount());
            } 
            else if (Count() + 1 <= max)
            {
                Debug.Log("Adding Item");
                items.Add(toAdd);
            }
            else
            {
                GameObject.Find("MenuObject").GetComponent<Menu>().popMessage("Inventory is full");
            }
		}

		//removes an item at index from inventory
		public void removeItem(Item toRemove, int index) {

            items.RemoveAt(index);
		}


		//inventory count
		public int Count() {
			return items.Count;
		}

		public GameObject item(int index) {
			return items[index];
		}

		/*---GETTERS & SETTERS---*/

		//don't know why I would need this but MAAAYBE
		public void setItems(List<GameObject> a) {
			items = a;
		}

		public List<GameObject> getItems() {
			return items;
		}

        public void setMax(int m)
        {
            max = m;
            items.Capacity = m;
        }

        public int getMax()
        {
            return max;
        }



	}
}

