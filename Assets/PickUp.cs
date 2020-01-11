using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    private Inventory inventory;
    public GameObject item;

    void Start()
    {
        //
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>(); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //checks for the player tag
        if (other.CompareTag("Player"))
        {
            //repeats the process the number of inventory slots avaleable
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                //checks if the inventory selected is full or not
                if (inventory.isFull[i] == false)
                {
                    //makes the inventory slot currently selected (full)
                    inventory.isFull[i] = true;
                    Instantiate(item, inventory.slots[i].transform, false);
                    Destroy(gameObject);
                    //breaks the process to not repeat for ever
                    break;
                }
            }
        }
    }
}
