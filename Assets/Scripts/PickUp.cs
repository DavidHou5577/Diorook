using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PickUp : MonoBehaviour
{
    public Image TextBox;
    public TextMeshProUGUI Text;
    public PlayerInteraction player;
    public ObjectDataCache ObjectData;
    public Inventory inventory;
    public GameObject item;
	public TextAsset TheText;
	public int StartLine;
	public int EndLine;
	public DialogueTextReader TheTextBox;

    void OnEnable()
    {
        TheTextBox = FindObjectOfType<DialogueTextReader>();
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        ObjectData = GetComponent<ObjectDataCache>();
        GetItem();
    }

    void GetItem()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[i] == false)
            {
                inventory.isFull[i] = true;
                GameObject obj = Instantiate(item, inventory.slots[i].transform, false);
                obj.name = obj.name.Replace("(Clone)", "").Trim();
                Destroy(gameObject);
                break;
            }
        }
        this.enabled = false;
    }


        void OnTriggerEnter2D(Collider2D other)
	{
        for (int i = 0; i < inventory.slots.Length; i++)
        {
	    	if (inventory.isFull[i] == false && other.name == "Player Interaction Obj(Clone)")
	    	{
	    		TheTextBox.ReloadScript(TheText);
    			TheTextBox.CurrentLine = StartLine;
    			TheTextBox.EndAtLine = EndLine;
    			TheTextBox.EnableTextBox();
                break;
    		}
        }
	}
}
