using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {

	ConversationObject conversation;
	int startPhraseID = 1;

	// Use this for initialization
	void Start () {
		conversation = new ConversationObject("Assets/phrases.txt");

		setPhrasesFromLine(1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void madeChoice(Button button) {

		if (startPhraseID != 0) {

			int choiceID;

			// Get this choices ID
			if (!Int32.TryParse (button.name.Substring (6), out choiceID))
				Debug.Log ("Couldn't parse the end of the button name, "
					+ button.name.Substring (6) + " as a number");

			Debug.Log ("You chose " + (startPhraseID + choiceID - 1)
				+ "\nThe first option was ID " + startPhraseID + " and your choice " 
				+ choiceID + " was added onto this, with 1 subtracted");
			// Get the ID of the start of the next phrases
			int nextID = conversation.getIDOfNextPhrase(startPhraseID + choiceID - 1);


			// Update the text of the three buttons
			if (nextID != 0) {
				setPhrasesFromLine (nextID);
				startPhraseID = nextID;
			} else {
				startPhraseID = 0;
				GameObject.Find ("option1").GetComponentInChildren<Text> ().text = "End";
				GameObject.Find ("option2").GetComponentInChildren<Text> ().text = "of the";
				GameObject.Find ("option3").GetComponentInChildren<Text> ().text = "game!";
			}
		}
	}

	public void setPhrasesFromLine(int firstLineNum) {
		GameObject.Find("option1").GetComponentInChildren<Text> ().text = 
			conversation.getPhrase(firstLineNum);
		GameObject.Find("option2").GetComponentInChildren<Text> ().text = 
			conversation.getPhrase(firstLineNum+1);
		GameObject.Find("option3").GetComponentInChildren<Text> ().text = 
			conversation.getPhrase(firstLineNum+2);
	}
}
