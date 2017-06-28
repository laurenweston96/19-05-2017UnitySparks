using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineValues {
	int IDOfNextPhrase;
	string phrase;
	int generalRating;
	//string impresses;
	//string offends;

	public LineValues(string line) {
		
		string[] lineParts = line.Split (',');

		if (lineParts.Length != 5)
			Debug.Log ("There aren't 5 items in the line. There are " + lineParts.Length);

		// ID of the next phrase, if there is one, make sure you can read it as a number
		if (lineParts [0] != "" && !Int32.TryParse (lineParts [0], out IDOfNextPhrase))
			Debug.Log ("We couldn't parse " + lineParts [0] + " as a number for the ID of the next phrase");

		// Phrase
		phrase = lineParts [1];

		// General rating
		if (!Int32.TryParse (lineParts [2], out generalRating))
			Debug.Log ("We couldn't parse " + lineParts [2] + " as a number for the rating");

		//impresses = lineParts [3];

		//offends = lineParts [4];

		Debug.Log ("ID of next phrase: " + IDOfNextPhrase
				+ "\nPhrase: " + phrase
				+ "\nRating: " + generalRating);

	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int getIDOfNextPhrase() {
		Debug.Log( "The ID of the next phrase is " + IDOfNextPhrase);
		return IDOfNextPhrase;
	}

	public string getPhrase() {
		return phrase;
	}

	public int getGeneralRating() {
		return generalRating;
	}


}
