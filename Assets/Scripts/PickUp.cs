﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PickUp : MonoBehaviour
{
    public Inventory inventory;
    public GameObject item;
	public TextAsset TheText;
	public int StartLine;
	public int EndLine;
	public DialogueTextReader TheTextBox;
    public bool Tutorial;

    void OnEnable()
    {
        TheTextBox = FindObjectOfType<DialogueTextReader>();
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

        if(Tutorial)
        {
            return;
        }
        
        GetItem();
        TheTextBox.ReloadScript(TheText);
   	    TheTextBox.CurrentLine = StartLine;
   	   	TheTextBox.EndAtLine = EndLine;
    }

    void GetItem()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[i] == false)
            {        
            	TheTextBox.EnableTextBox();
                inventory.isFull[i] = true;
                GameObject obj = Instantiate(item, inventory.slots[i].transform, false);
                obj.name = obj.name.Replace("(Clone)", "").Trim();
                Destroy(gameObject);
                break;
            }        
        }

        this.enabled = false;
    }
}
