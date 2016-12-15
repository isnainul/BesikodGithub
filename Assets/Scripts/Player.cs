using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
	bool isMoving = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			QueueMovement (Vector2.right);
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			QueueMovement (Vector2.left);
		}
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			QueueMovement (Vector2.up);
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			QueueMovement (Vector2.down);
		}

		if (movementQueue.Count > 0 && !isMoving) {
			Move (movementQueue.Dequeue());
		}
	}

	public void QueueMovement(int direction) {
		switch (direction) {
		case 1:
			QueueMovement (Vector2.right);
			break;
		case 2:
			QueueMovement (Vector2.left);
			break;
		case 3:
			QueueMovement (Vector2.up);
			break;
		case 4:
			QueueMovement (Vector2.down);
			break;
		}
	}

	Queue<Vector2> movementQueue = new Queue<Vector2>();
	void QueueMovement(Vector2 direction) {
		movementQueue.Enqueue (direction);
	}

	void Move(Vector2 direction) {
		isMoving = true;
		Collider2D col = Physics2D.OverlapCircle ((Vector2)transform.position + direction, 0.2f,LayerMask.GetMask("Quad"));
		if (col != null && !col.GetComponent<Quad> ().isObstacle) {
			//can move
			StartCoroutine (MoveAnim (col.transform.position));
		} else {
			//cant move
			StartCoroutine (CantMoveAnim ());
		}
	}

	IEnumerator MoveAnim(Vector2 targetPosition) {
		Vector2 startPosition = transform.position;
		float t = 0f;
		while (t < 1f) {
			t += Time.deltaTime * 2f;
			transform.position = Vector2.Lerp(startPosition,targetPosition,t);
			yield return null;
		}
		transform.position = targetPosition;
		yield return new WaitForSeconds (0.1f);
		isMoving = false;

		if (movementQueue.Count <= 0) {
			checkGameOver ();
		}
	}

	IEnumerator CantMoveAnim() {
		Vector2 startPosition = transform.position;
		Vector2 shakeOffset = new Vector2 (0.1f,0f); 

		//shake right
		float t = 0f;
		while (t < 1f) {
			t += Time.deltaTime * 20f;
			transform.position = Vector2.Lerp (startPosition,startPosition+shakeOffset,t);
			yield return null;
		}

		//shake right
		t = 0f;
		while (t < 1f) {
			t += Time.deltaTime * 10f;
			transform.position = Vector2.Lerp (startPosition+shakeOffset,startPosition-shakeOffset,t);
			yield return null;
		}

		//shake right
		t = 0f;
		while (t < 1f) {
			t += Time.deltaTime * 10f;
			transform.position = Vector2.Lerp (startPosition-shakeOffset,startPosition+shakeOffset,t);
			yield return null;
		}

		//shake right
		t = 0f;
		while (t < 1f) {
			t += Time.deltaTime * 20f;
			transform.position = Vector2.Lerp (startPosition+shakeOffset,startPosition,t);
			yield return null;
		}

		transform.position = startPosition;

		yield return new WaitForSeconds (0.1f);

		isMoving = false;
		if (movementQueue.Count <= 0) {
			checkGameOver ();
		}
	}

	void checkGameOver() {
		GameObject.Find ("GameplayManager").GetComponent<GameplayManager> ().checkGameOver ();
	}
}
