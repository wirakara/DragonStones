using UnityEngine;
using System.Collections;

public class CursorP1Script : MonoBehaviour {

	StartEndScript startEnd;
	GridP1 gridP1;

	float moveValue = 0.16f;

	bool movingH1 = false;
	bool movingV1 = false;

	void Start () {

		startEnd = GetComponent<StartEndScript> ();
		gridP1 = GameObject.Find ("P1Grid").GetComponent<GridP1> ();

		transform.position = new Vector2 (gridP1.GetGridByNumber (12).transform.position.x, 
		                                  gridP1.GetGridByNumber (12).transform.position.y);
	
	}

	void Update () {

		// Cursor P1 Controller
		if (startEnd.P1Playing){
			if (Input.GetKeyDown (KeyCode.D) || (Input.GetAxis ("Horizontal1") == 1 && !movingH1)) {
				MoveHorizontal (moveValue);
				movingH1 = true;

			}

			if (Input.GetKeyDown (KeyCode.A) || (Input.GetAxis ("Horizontal1") == -1 && !movingH1)) {
				MoveHorizontal (-moveValue);
				movingH1 = true;
			}

			if (Input.GetKeyDown (KeyCode.W) || (Input.GetAxis ("Vertical1") == 1 && !movingV1)) {
				MoveVertical (moveValue);
				movingV1 = true;
			}

			if (Input.GetKeyDown (KeyCode.S) || (Input.GetAxis ("Vertical1") == -1 && !movingV1)) {
				MoveVertical (-moveValue);
				movingV1 = true;
			}

			if (Input.GetAxis ("Horizontal1") == 0){
				movingH1 = false;
			}

			if (Input.GetAxis ("Vertical1") == 0){
				movingV1 = false;
			}
		}
	
	}

	void MoveHorizontal (float moveX){

		if (transform.position.x >= gridP1.GetGridByNumber (0).transform.position.x &&
		    transform.position.x <= gridP1.GetGridByNumber (4).transform.position.x){
			
			transform.position = new Vector2 (transform.position.x + moveX, transform.position.y);
		}
		if (transform.position.x <= gridP1.GetGridByNumber (0).transform.position.x){
			transform.position = new Vector2 (gridP1.GetGridByNumber (0).transform.position.x, transform.position.y);
		}
		if (transform.position.x >= gridP1.GetGridByNumber (4).transform.position.x){
			transform.position = new Vector2 (gridP1.GetGridByNumber (4).transform.position.x, transform.position.y);
		}
	}

	void MoveVertical (float moveY){
		
		if (transform.position.y <= gridP1.GetGridByNumber (0).transform.position.y &&
		    transform.position.y >= gridP1.GetGridByNumber (20).transform.position.y){
			
			transform.position = new Vector2 (transform.position.x, transform.position.y + moveY);
		}
		if (transform.position.y >= gridP1.GetGridByNumber (0).transform.position.y){
			transform.position = new Vector2 (transform.position.x, gridP1.GetGridByNumber (0).transform.position.y);
		}
		if (transform.position.y <= gridP1.GetGridByNumber (20).transform.position.y){
			transform.position = new Vector2 (transform.position.x, gridP1.GetGridByNumber (20).transform.position.y);
		}
	}
}
