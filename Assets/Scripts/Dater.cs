using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dater {

	private Character character;
	private Personality personality;

	public Dater() {

		int noOfCharacterEnums = System.Enum.GetNames (typeof(Character)).Length;
		int noOfPersonalityEnums = System.Enum.GetNames (typeof(Personality)).Length;

		character = (Character) Random.Range(0, noOfCharacterEnums);
		personality = (Personality) Random.Range(0, noOfPersonalityEnums);

		GameObject.Find("TypeOfDateText").GetComponent<Text>().text = 
			personality + " " + character;

		Debug.Log ("Getting as date");
		//setDateImg (character.ToString(), 1);
		//The above line is correct. Just testing what happens if you'd got a cowboy
		setDateImg ("COWBOY", 1);
	}

	public enum Character {
		COWBOY,
		CHAV,
		GOTH
	}

	public enum Personality {
		ROMANTIC,
		LAIDBACK,
		SHY
	}

	public Character getCharacter() {
		return character;
	}

	public Personality getPersonality() {
		return personality;
	}

	// Change the way the date looks. 
	// Emotion here means 0:Sad, 1:Neutral, 2:Happy
	public void setDateImg (string filename, int emotion) {
		
		string suffix = "Error";

		if (emotion < 0 || emotion > 2)
			Debug.Log ("Please give an emotion of 0, 1 or 2. They represent"
			+ " sad, neutral and happy respectively.");
		else {
			switch (emotion) {
			//Sad
			case 0:
				suffix = "S";
				break;
				//Neutral
			case 1:
				suffix = "N";
				break;
				//Happy
			case 2:
				suffix = "H";
				break;
			}

		}

		Sprite spriteToLoad = (Sprite)Resources.Load<Sprite> ("Sprites/" + filename + suffix);

		// USE THIS TO LOAD MULTIPLE SPRITES, CHILD SPRITES, LIKE MY COWBOY EMOTIONS
		//string spriteSheet = AssetDatabase.GetAssetPath( txt );
		//Sprite[] sprites = AssetDatabase.LoadAllAssetsAtPath( spriteSheet )
		//	.OfType<Sprite>().ToArray();

		if (spriteToLoad == null)
			Debug.Log("Can't find sprite " + filename + suffix);
		else
			GameObject.Find ("Date").GetComponent<SpriteRenderer> ().sprite = spriteToLoad;
	}

}
