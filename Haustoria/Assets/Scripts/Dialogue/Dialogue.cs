using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
	public string name = "name";
	
	[TextArea(3, 5)]
	public string[] sentences;
	
	public bool InDialogue;

	public ResponseOption[] responseOptions;

}

[System.Serializable]
public class ResponseOption
{
	public string optionText;
	public Dialogue nextDialogue;
}