using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDialogueAtLine : MonoBehaviour {

	public TextAsset TheText;
	public int StartLine;
	public int EndLine;
	public DialogueTextReader TheTextBox;
	public bool off;
	public bool HasBat;

	// Use this for initialization

	void OnEnable()
	{
		if (HasBat)
		{
			TheTextBox = FindObjectOfType<DialogueTextReader>();
			TheTextBox.CurrentLine = 7;
		}
		if(!off)
		{
			this.enabled = false;
			off = true;
			return;
		}
		
		if(off)
		{
			TheTextBox = FindObjectOfType<DialogueTextReader>();
			TheTextBox.CurrentLine = StartLine;
			TheTextBox.EndAtLine = EndLine;
			TheTextBox.EnableTextBox();
			off = false;
			this.enabled = false;
		}		
	}
}
