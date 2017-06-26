using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

	public void StartGame(string newGameName) {
		SceneManager.LoadScene (newGameName);
	}

	public void QuitGame() {
		print("would have quit");
		Application.Quit ();
	}
}
