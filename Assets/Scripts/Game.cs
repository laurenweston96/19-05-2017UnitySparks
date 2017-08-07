using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {

	public Sprite Happy;

	ConversationObject conversation;
	int startPhraseID = 1;
	int score;
	Dater date;

	// Use this for initialization
	void Start () {
		conversation = new ConversationObject("Assets/phrases.txt");

		setPhrasesFromLine(1);

		date = new Dater ();

		Debug.Log ("Your dates is a " + (int)date.getCharacter () + "\nA cowboy is " + (int)Dater.Character.COWBOY);
		if ((int)date.getCharacter () != (int)Dater.Character.COWBOY)
			GameObject.Find ("Character").GetComponent<SpriteRenderer>().enabled = false;
			

		GameObject.Find ("Information Text").GetComponent<Text> ().text = 
			"You are on a date with a " + date.getPersonality().ToString().ToLower() 
			+ " " + date.getCharacter().ToString().ToLower();
		GameObject.Find ("Sentence").GetComponent<Text> ().text = "";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void madeChoice(Button button) {

		if (startPhraseID != 0) {

			// Get the buttons ID: 1, 2 or 3
			int buttonID;
			if (!Int32.TryParse (button.name.Substring (6), out buttonID))
				Debug.Log ("Couldn't parse the end of the button name, "
					+ button.name.Substring (6) + " as a number");
			
			// Get the line number of the phrase you chose
			int choiceLineNum = startPhraseID + buttonID - 1;

			appendChoiceToSentence (choiceLineNum);
			scorePhrase (choiceLineNum);

			// Get the ID of the start of the next phrases
			int nextID = conversation.getIDOfNextPhrase(choiceLineNum);

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

	public void appendChoiceToSentence(int choiceLineNum){
		GameObject.Find("Sentence").GetComponent<Text>().text += 
			conversation.getPhrase(choiceLineNum) + " ";
	}

	public void scorePhrase(int choiceLineNum){

		int rating = 0;
		SpriteRenderer spriteRenderer;
		Sprite Happy;

		// Check if your date is particularly impressed or offended first
		foreach (string impressee in conversation.getImpresses(choiceLineNum))
			if (impressee == "COWBOY") {
				Debug.Log ("Your date loved that");
				rating = 10;

				//Change the sprite to be happy
				//GameObject.Find ("Date").GetComponent<SpriteRenderer> ().sprite = 
					//	Resources.Load("Sprites/Happy.png") as Sprite;
				Sprite sprite = GameObject.Find ("Date").GetComponent<SpriteRenderer> ().sprite;
				if (sprite == null)
					Debug.Log ("Couldn't find the date");
				else {
					Debug.Log (sprite.ToString());
				}
				sprite = (Sprite) Resources.Load<Sprite>("Sprites/Happy");
				if ((Sprite) Resources.Load<Sprite>("Sprites/Happy") == null)
					Debug.Log("Couldn't find asset happy");
				else
					Debug.Log ("Set happy");

				break;
			}

		foreach (string offendee in conversation.getOffends(choiceLineNum))
			if (offendee == "COWBOY") {
				Debug.Log ("Your date hated that");
				rating = -10;

				//Change the sprite to be sad

				break;
			}
		
		// If not, add the general rating
		if (rating == 0) {
			rating = conversation.getGeneralRating (choiceLineNum);

			//Change the sprite to be neutral

		}

		// Append this rating to the total score and set it
		score += rating;
		GameObject.Find("Score").GetComponent<Text>().text = score.ToString();
	}
}
