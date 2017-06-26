using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

	ConversationObject conversation;

	// Use this for initialization
	void Start () {
		conversation = new ConversationObject("phrases.txt");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
