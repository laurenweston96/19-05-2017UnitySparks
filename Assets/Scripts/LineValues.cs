using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineValues : MonoBehaviour {

	int IDOfNextPhrase;
	string phrase;
	string generalRating;
	string impresses;
	string offends;

	LineValues(string line) {
		
		string[] lineParts = line.Split (',');

		if (Int32.TryParse (lineParts [0], out IDOfNextPhrase)) {
			print ("We parsed this number!");
		} else
			print ("We couldn't parse " + lineParts [0] + " as a number");

		phrase = lineParts [1];

		generalRating = lineParts [2];

		impresses = lineParts [3];

		offends = lineParts [4];

	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
