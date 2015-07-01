using UnityEngine;
using AssemblyCSharp;
using System.Collections;
using System.Collections.Generic;

public class AreaDex : MonoBehaviour {
    
    //Just going to plop all the item prefabs in here easy..
    public List<GameObject> AreaBase;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool doesExist(string areaName)
    {
        for (int i = 0; i < AreaBase.Count; i++)
        {
            if (areaName == AreaBase[i].GetComponent<Area>().getName())
            {
                return true;
            }
        }
        return false;
    }

    public GameObject findArea(string areaName)
    {
        for (int i = 0; i < AreaBase.Count; i++)
        {
            if (areaName == AreaBase[i].GetComponent<Area>().getName())
            {
                return AreaBase[i];
            }
        }
        return null;
    }
}
