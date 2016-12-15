using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {

	public Quad doorQuad;
	void Start () {
		
	}

	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.name == "Player") {
			doorQuad.isObstacle = false;
			GameObject.Find ("Door").SetActive(false);
			GameObject.Destroy (this.gameObject);
		}
	}
}
