using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDialogueAtLine : MonoBehaviour {

	public TextAsset TheText;
	public int StartLine;
	public int EndLine;
	public DialogueTextReader TheTextBox;

	// Use this for initialization
	void Start () 
	{
		TheTextBox = FindObjectOfType<DialogueTextReader>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player Interaction Obj(Clone)")
		{
			TheTextBox.ReloadScript(TheText);
			TheTextBox.CurrentLine = StartLine;
			TheTextBox.EndAtLine = EndLine;
			TheTextBox.EnableTextBox();
		}
	}
}
