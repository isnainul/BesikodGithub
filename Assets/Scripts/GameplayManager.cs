using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameplayManager : MonoBehaviour {

	public int commandNum = 5;
	public Quad endQuad;

	void Start () {
	
	}

	public void  useCommand() {
		commandNum--;
	}

	public void checkGameOver() {
		if (commandNum <= 0) {
			GameObject player = GameObject.Find ("Player");
			Collider2D col = Physics2D.OverlapCircle (player.transform.position,0.2f,LayerMask.GetMask("Quad"));
			if (col.name == endQuad.name) {
				Win ();
			} else {
				Lose ();
			}
		}
	}

	void Win() {
		Debug.Log ("Win");
		if(SceneManager.GetActiveScene().name=="Level1") {
			SceneManager.LoadScene ("Level2");
		} else if(SceneManager.GetActiveScene().name=="Level2") {
			SceneManager.LoadScene ("Level3");
		} else if(SceneManager.GetActiveScene().name=="Level3") {
			SceneManager.LoadScene ("Scene");
		} 
	}

	void Lose() {
		Debug.Log ("Lose");
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}
}
