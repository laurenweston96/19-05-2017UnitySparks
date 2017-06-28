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
			Debug.Log ("Adding line: " + line);

			lineValues = new LineValues (line);
			allPhraseLines.Add (lineValues);
		}

		Debug.Log("All lines are now added");
	}

	public int getIDOfNextPhrase(int lineNum)
	{
		Debug.Log ("At line number " + lineNum + " we're saying that the next ID is at " + allPhraseLines[lineNum-1].getIDOfNextPhrase());
		return allPhraseLines[lineNum-1].getIDOfNextPhrase();
	}

	public string getPhrase(int lineNum)
	{
		Debug.Log ("Getting the phrase at line " + lineNum);
		return allPhraseLines[lineNum-1].getPhrase();
	}

	public int getGeneralRating(int lineNum)
	{
		Debug.Log ("Getting General Rating");
		return allPhraseLines[lineNum-1].getGeneralRating();
	}

	public void getImpresses(int lineNum)
	{
		Debug.Log ("Getting Impresses");
	}

	public void getOffends(int lineNum)
	{
		Debug.Log ("Getting Offends");
	}
}
