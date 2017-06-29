using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationObject {

	List<LineValues> allPhraseLines = new List<LineValues>();

	public ConversationObject(string inputFilename) {
		string line;
		LineValues lineValues;

		System.IO.StreamReader file = new System.IO.StreamReader (inputFilename);

		while ((line = file.ReadLine ()) != null) {
			lineValues = new LineValues (line);
			allPhraseLines.Add (lineValues);
		}

		Debug.Log("All lines are now added");
	}

	public int getIDOfNextPhrase(int lineNum)
	{
		return allPhraseLines[lineNum-1].getIDOfNextPhrase();
	}

	public string getPhrase(int lineNum)
	{
		return allPhraseLines[lineNum-1].getPhrase();
	}

	public int getGeneralRating(int lineNum)
	{
		Debug.Log ("Getting General Rating");
		return allPhraseLines[lineNum-1].getGeneralRating();
	}

	public string[] getImpresses(int lineNum)
	{
		Debug.Log ("Getting Impresses");
		return allPhraseLines[lineNum-1].getImpressesArray();
	}

	public string[] getOffends(int lineNum)
	{
		Debug.Log ("Getting Offends");
		return allPhraseLines[lineNum-1].getOffendsArray();
	}
}
