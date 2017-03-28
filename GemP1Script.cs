using UnityEngine;
using System.Collections;

public class GemP1Script : MonoBehaviour {

	StartEndScript startEnd;
	GridP1 gridP1;

	GameObject cursorP1;
	GameObject[] gems;
	GameObject[] fireGems;
	GameObject[] airGems;
	GameObject[] waterGems;
	GameObject[] earthGems;

	float distanceValue = 0.16f;

	bool grab = false;
	bool move = true;
	bool vacantL = false;
	bool vacantR = false;
	bool vacantD = false;
	bool vacantU = false;

	Animator anim;

	void Start () {

		startEnd = GameObject.Find ("CursorP1").GetComponent<StartEndScript> ();
		gridP1 = GameObject.Find ("P1Grid").GetComponent<GridP1> ();
		LoadResources ();
	
	}
	

	void Update () {

		if (startEnd.P1Shock) {
			grab = false;
			move = false;
		}

		if (!grab && !vacantL && !vacantR && !vacantD && !vacantU){

			if (cursorP1.transform.position.x == transform.position.x &&
			    cursorP1.transform.position.y == transform.position.y){

				anim.SetInteger ("Gem", 1);
			}else {
				anim.SetInteger ("Gem", 0);
			}
		}

		if ((Input.GetKeyDown (KeyCode.Joystick1Button5) || Input.GetKeyDown (KeyCode.Space)) && !startEnd.P1Shock) {
			move = true;
		}

		if ((Input.GetKeyDown (KeyCode.Joystick1Button5) || Input.GetKeyDown (KeyCode.Space)) && !startEnd.P1Shock &&
		    cursorP1.transform.position.x == transform.position.x &&
		    cursorP1.transform.position.y == transform.position.y){
			grab = true;
		}

		if (Input.GetKeyUp (KeyCode.Joystick1Button5) || Input.GetKeyUp (KeyCode.Space)){
			grab = false;
			InitialVacants ();
		}

		if (grab && startEnd.P1Playing){
			transform.position = new Vector2 (cursorP1.transform.position.x, cursorP1.transform.position.y);
			anim.SetInteger ("Gem", 2);
		}

		// TODO: Switch to Down-left
		if (cursorP1.transform.position.x == transform.position.x - distanceValue &&
		    cursorP1.transform.position.y == transform.position.y - distanceValue  &&
		    (Input.GetKey (KeyCode.Joystick1Button5) || Input.GetKey (KeyCode.Space)) && startEnd.P1Playing && move){
			
			InitialVacants ();
			vacantD = true;
			vacantL = true;
		}
		
		if (vacantD && vacantL && cursorP1.transform.position.x == transform.position.x && cursorP1.transform.position.y == transform.position.y){
			transform.position = new Vector2 (transform.position.x - distanceValue, transform.position.y - distanceValue);
			InitialVacants ();
		}

		// TODO: Switch to Down-Right
		if (cursorP1.transform.position.x == transform.position.x + distanceValue &&
		    cursorP1.transform.position.y == transform.position.y - distanceValue  &&
		    (Input.GetKey (KeyCode.Joystick1Button5) || Input.GetKey (KeyCode.Space)) && startEnd.P1Playing && move){
			
			InitialVacants ();
			vacantD = true;
			vacantR = true;
		}
		
		if (vacantD && vacantR && cursorP1.transform.position.x == transform.position.x && cursorP1.transform.position.y == transform.position.y){
			transform.position = new Vector2 (transform.position.x + distanceValue, transform.position.y - distanceValue);
			InitialVacants ();
		}

		// TODO: Switch to Up-left
		if (cursorP1.transform.position.x == transform.position.x - distanceValue &&
		    cursorP1.transform.position.y == transform.position.y + distanceValue  &&
		    (Input.GetKey (KeyCode.Joystick1Button5) || Input.GetKey (KeyCode.Space)) && startEnd.P1Playing && move){
			
			InitialVacants ();
			vacantU = true;
			vacantL = true;
		}
		
		if (vacantU && vacantL && cursorP1.transform.position.x == transform.position.x && cursorP1.transform.position.y == transform.position.y){
			transform.position = new Vector2 (transform.position.x - distanceValue, transform.position.y + distanceValue);
			InitialVacants ();
		}

		// TODO: Switch to Up-Right
		if (cursorP1.transform.position.x == transform.position.x + distanceValue &&
		    cursorP1.transform.position.y == transform.position.y + distanceValue  &&
		    (Input.GetKey (KeyCode.Joystick1Button5) || Input.GetKey (KeyCode.Space)) && startEnd.P1Playing && move){
			
			InitialVacants ();
			vacantU = true;
			vacantR = true;
		}
		
		if (vacantU && vacantR && cursorP1.transform.position.x == transform.position.x && cursorP1.transform.position.y == transform.position.y){
			transform.position = new Vector2 (transform.position.x + distanceValue, transform.position.y + distanceValue);
			InitialVacants ();
		}

		// TODO: Switch to left
		if (cursorP1.transform.position.x == transform.position.x - distanceValue &&
		    cursorP1.transform.position.y == transform.position.y &&
		    (Input.GetKey (KeyCode.Joystick1Button5) || Input.GetKey (KeyCode.Space)) && startEnd.P1Playing && move){

			InitialVacants ();
			vacantL = true;
		}

		if (vacantL && cursorP1.transform.position.x == transform.position.x && cursorP1.transform.position.y == transform.position.y){
			transform.position = new Vector2 (transform.position.x - distanceValue, transform.position.y);
			InitialVacants ();
		}

		// TODO: Switch to Right
		if (cursorP1.transform.position.x == transform.position.x + distanceValue &&
		    cursorP1.transform.position.y == transform.position.y &&
		    (Input.GetKey (KeyCode.Joystick1Button5) || Input.GetKey (KeyCode.Space)) && startEnd.P1Playing && move){
			
			InitialVacants ();
			vacantR = true;
		}
		
		if (vacantR && cursorP1.transform.position.x == transform.position.x && cursorP1.transform.position.y == transform.position.y){
			transform.position = new Vector2 (transform.position.x + distanceValue, transform.position.y);
			InitialVacants ();
		}

		// TODO: Switch to Down
		if (cursorP1.transform.position.x == transform.position.x &&
		    cursorP1.transform.position.y == transform.position.y - distanceValue &&
		    (Input.GetKey (KeyCode.Joystick1Button5) || Input.GetKey (KeyCode.Space)) && startEnd.P1Playing && move){
			
			InitialVacants ();
			vacantD = true;
		}
		
		if (vacantD && cursorP1.transform.position.x == transform.position.x && cursorP1.transform.position.y == transform.position.y){
			transform.position = new Vector2 (transform.position.x, transform.position.y - distanceValue);
			InitialVacants ();
		}

		// TODO: Switch to Up
		if (cursorP1.transform.position.x == transform.position.x &&
		    cursorP1.transform.position.y == transform.position.y + distanceValue &&
		    (Input.GetKey (KeyCode.Joystick1Button5) || Input.GetKey (KeyCode.Space)) && startEnd.P1Playing && move){
			
			InitialVacants ();
			vacantU = true;
		}
		
		if (vacantU && cursorP1.transform.position.x == transform.position.x && cursorP1.transform.position.y == transform.position.y){
			transform.position = new Vector2 (transform.position.x, transform.position.y + distanceValue);
			InitialVacants ();
		}

	}

	void LoadResources () {

		cursorP1 = GameObject.Find ("CursorP1");
		anim = GetComponent<Animator> ();
		gems = GameObject.FindGameObjectsWithTag ("Gem");
		fireGems = GameObject.FindGameObjectsWithTag ("Fire");
		airGems = GameObject.FindGameObjectsWithTag ("Air");
		waterGems = GameObject.FindGameObjectsWithTag ("Water");
		earthGems = GameObject.FindGameObjectsWithTag ("Earth");
	}

	void InitialVacants (){
		vacantL = false;
		vacantR = false;
		vacantD = false;
		vacantU = false;
	}

}
