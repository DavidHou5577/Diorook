using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 [System.Serializable]
public class Dialogue
{
    //name of the person/interactable object
    public string name;

    //minimum and maximum amount of text boxes
    [TextArea(1, 100)]

    //number of sentences
    public string[] sentences;
}
