using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTutorial : MonoBehaviour {

public bool HasBat;
public GameObject Chores;
public GameObject[] items;
public GameObject[] Tutorialitems;
public GameObject item;
public Inventory Inventory;
public GameObject obj;

    void Awake()
    {
        Inventory= GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

	void OnEnable()
	{
		if (HasBat)
		{
			if (Inventory.selectedslot != 9)
	        {
		        if (Inventory.isFull[Inventory.selectedslot])
    	        {
    	            obj = Inventory.slots[Inventory.selectedslot].transform.GetChild(0).gameObject;
    	    	    string ItemName = (item.name + " (Inventory)").ToLower();
    	    	    if (obj != null && obj.name.ToLower() == ItemName)
    	      	    {
    	       	       for (int i = 0; i < Tutorialitems.Length; i++)
						{
							Tutorialitems[i].SetActive(false);
						}

						for (int i = 0; i < items.Length; i++)
						{
							items[i].GetComponent<PickUp>().Tutorial = false;
							items[i].GetComponent<PickUp>().enabled = false;
						}

						Chores.SetActive(true);
   		    	    }
        		}
        	}		
		this.enabled = false;
		}
	}
}