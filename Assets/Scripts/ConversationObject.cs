using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationObject : MonoBehaviour {

	string filename;
	LineValues lineValues;

	ConversationObject(string inputFilename) {
		filename = inputFilename;

		//Open up the file and read the first line
		string line;

		lineValues = new LineValues (line);
	}

	public int getNextLineNumber(int lineNum)
	{
		print ("Getting next line number");
		return -1;
	}

	public int getIDOfNextPhrase(int lineNum)
	{
		print ("Getting the ID of the first of the next phrases. The other two phrases are two after this one.");
		return -1;
	}

	public string getPhrase(int lineNum)
	{
		print ("Getting the phrase at line " + lineNum);
		return "Sample Phrase";
	}

	public void getGeneralRating(int lineNum)
	{
		print ("Getting General Rating");
	}

	public void getImpresses(int lineNum)
	{
		print ("Getting Impresses");
	}

	public void getOffends(int lineNum)
	{
		print ("Getting Offends");
	}


	//private void getLineParts


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
