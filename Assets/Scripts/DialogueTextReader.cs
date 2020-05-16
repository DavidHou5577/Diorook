using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class DialogueTextReader : MonoBehaviour{

	public GameObject textBox;
	public TextMeshProUGUI TheText;

    public TextAsset DialogueFile;
    public string[] DialogueLines;

	public int CurrentLine;
	public int EndAtLine;
	public PlayerInteraction move;
	public bool IsActive;
	public bool StopPlayer;

    void Start()
    {
		textBox = GameObject.Find("TextBox");
		move = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInteraction>();
		
        if (DialogueFile != null)
        {
            DialogueLines = (DialogueFile.text.Split('\n'));
        }

		if (EndAtLine == 0)
		{
			EndAtLine = DialogueLines.Length - 1;
		}

		if (IsActive)
		{
			EnableTextBox();
		}
		else
		{
			DisableTextBox();
		}
    }

	void Update()
	{
		TheText.text = DialogueLines[CurrentLine];

		if (!IsActive)
		{
			return;
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			CurrentLine += 1;
		}

		if (CurrentLine > EndAtLine)
		{
			DisableTextBox();
		}
	}

	public void EnableTextBox()
	{
		textBox.SetActive(true);

		move.CanMove = false;
	}

	public void DisableTextBox()
	{
		textBox.SetActive(false);

		move.CanMove = true;
	}
}
