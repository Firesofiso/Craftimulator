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
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

namespace AssemblyCSharp
{
	public class Area : MonoBehaviour
	{
		public string name;

        //how long the person waits to obtain resource - in seconds
        public int delay;

		public GameObject resource;

		public Area ()
		{

		}


		//---GETTERS & SETTERS---
        public void setDelay(int d)
        {
            delay = d;
        }

        public int getDelay()
        {
            return delay;
        }

		public void setName(string n) {
			name = n;
		}

		public string getName() {
			return name;
		}

		public void setResource(GameObject r) {
			resource = r;
		}

		public GameObject getResource() {
			return resource;
		}
	}
}

