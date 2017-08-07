using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dater {

	private Character character;
	private Personality personality;

	public Dater() {

		int noOfCharacterEnums = System.Enum.GetNames (typeof(Character)).Length;
		int noOfPersonalityEnums = System.Enum.GetNames (typeof(Personality)).Length;

		character = (Character) Random.Range(0, noOfCharacterEnums);
		personality = (Personality) Random.Range(0, noOfPersonalityEnums);
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

}
