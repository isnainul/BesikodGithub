using UnityEngine;
using System.Collections;

public class HelpScript : MonoBehaviour {

	public GameObject[] helps;

	int currentHelp = 0;

	void Start () {
		Reset ();
	}

	public void Reset() {
		currentHelp = 0;
		foreach(GameObject g in helps) {
			g.SetActive (false);
		}
		helps [currentHelp].SetActive (true);
	}

	public void Next() {
		if (currentHelp < helps.Length - 1) { 
			helps [currentHelp].SetActive (false);
			helps [currentHelp + 1].SetActive (true);
			currentHelp++;
		} else {
			gameObject.SetActive (false);
		}
	}
}
