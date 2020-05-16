using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTutorial : MonoBehaviour {

public GameObject[] items;
public GameObject[] DestroyItems;

void OnEnable()
	{
		for (int i = 0; i < items.Length; i++)
		{
			items[i].GetComponent<PickUp>().Tutorial = false;
			items[i].GetComponent<PickUp>().enabled = false;
		}

		for (int i = 0; i < DestroyItems.Length; i++)
		{
			Destroy(DestroyItems[i]);
		}
		
	}
}
