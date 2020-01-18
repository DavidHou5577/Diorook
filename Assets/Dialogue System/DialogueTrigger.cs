using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public KeyCode interaction;

    public Dialogue dialogue;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(interaction))
        {
            TriggerDialogue();
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
