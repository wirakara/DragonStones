using UnityEngine;
using System.Collections;

public class ElementGemP1 : MonoBehaviour {

	StartEndScript startEnd;

	GameObject[] gems;

	GameObject elementBar;

	string gemElement;
	int indexElement = 0;

	int matchValueHL = 0;
	int matchValueHl = 0;
	int matchValueHR = 0;
	int matchValueHr = 0;
	int matchValueVD = 0;
	int matchValueVd = 0;
	int matchValueVU = 0;
	int matchValueVu = 0;

	public int elementValue = 0; // TODO: 1-Fire, 2-Air, 3-Water, 4-Earth

	float distance1 = 0.16f;
	float distance2 = 0.32f;
	float distance = 0;

	bool hold = false;

	void Start () {

		startEnd = GameObject.Find ("CursorP1").GetComponent<StartEndScript> ();
	}

	void Update () {

		LoadResources ();

		if (startEnd.AfterBlownTime == 5) {

			foreach (GameObject elementGem in gems) {
			
				if (elementGem != null) {
					FindMatchGem (-distance1, 0, elementGem);
					FindMatchGem (-distance2, 0, elementGem);
					FindMatchGem (distance1, 0, elementGem);
					FindMatchGem (distance2, 0, elementGem);
					FindMatchGem (0, -distance1, elementGem);
					FindMatchGem (0, -distance2, elementGem);
					FindMatchGem (0, distance1, elementGem);
					FindMatchGem (0, distance2, elementGem);
				}
			}
		}

		if (Input.GetKey (KeyCode.Joystick1Button5) || Input.GetKey (KeyCode.Space)) {
			matchValueHL = 0;
			matchValueHl = 0;
			matchValueHR = 0;
			matchValueHr = 0;
			matchValueVD = 0;
			matchValueVd = 0;
			matchValueVU = 0;
			matchValueVu = 0;

			hold = true;
		}

		if (Input.GetKeyUp (KeyCode.Joystick1Button5) || Input.GetKeyUp (KeyCode.Space)){

			foreach (GameObject elementGem in gems) {

				if (elementGem != null){
					FindMatchGem (-distance1, 0, elementGem);
					FindMatchGem (-distance2, 0, elementGem);
					FindMatchGem (distance1, 0, elementGem);
					FindMatchGem (distance2, 0, elementGem);
					FindMatchGem (0, -distance1, elementGem);
					FindMatchGem (0, -distance2, elementGem);
					FindMatchGem (0, distance1, elementGem);
					FindMatchGem (0, distance2, elementGem);
				}
	
			}
			hold = false;
		}

		//TODO: Self Destroy
		if (startEnd.P1Started && !hold){
			if ((matchValueHL == 1 && matchValueHl == 1) ||
			    (matchValueHr == 1 && matchValueHR == 1) ||
			    (matchValueVD == 1 && matchValueVd == 1) ||
			    (matchValueVu == 1 && matchValueVU == 1) ||
			    (matchValueHl == 1 && matchValueHr == 1) ||
			    (matchValueVd == 1 && matchValueVu == 1)) {

				DestroyGem ();
			}
		}

	}

	void LoadResources () {

		if (elementValue == 1){
			gems = GameObject.FindGameObjectsWithTag ("Fire");
			elementBar = GameObject.Find ("FireBar1");
		}
		if (elementValue == 2){
			gems = GameObject.FindGameObjectsWithTag ("Air");
			elementBar = GameObject.Find ("AirBar1");
		}
		if (elementValue == 3){
			gems = GameObject.FindGameObjectsWithTag ("Water");
			elementBar = GameObject.Find ("WaterBar1");
		}
		if (elementValue == 4){
			gems = GameObject.FindGameObjectsWithTag ("Earth");
			elementBar = GameObject.Find ("EarthBar1");
		}
	}

	void FindMatchGem (float xVal, float yVal, GameObject gem){

		if (transform.position.x + xVal == gem.transform.position.x &&
		    transform.position.y + yVal == gem.transform.position.y){

			if (xVal == -distance1 && yVal == 0)
				matchValueHl = 1;

			if (xVal == -distance2 && yVal == 0)
				matchValueHL = 1;

			if (xVal == distance1 && yVal == 0)
				matchValueHr = 1;
			
			if (xVal == distance2 && yVal == 0)
				matchValueHR = 1;

			if (xVal == 0 && yVal == -distance1)
				matchValueVd = 1;

			if (xVal == 0 && yVal == -distance2)
				matchValueVD = 1;

			if (xVal == 0 && yVal == distance1)
				matchValueVu = 1;
			
			if (xVal == 0 && yVal == distance2)
				matchValueVU = 1;
		}
	}

	void DestroyGem (){

		SpawnOrb ();

		SpawnGem ();

		SpawnFX1 ();

		startEnd.AfterBlown = true;

		Destroy (gameObject);
	}

	void SpawnGem (){
		indexElement = Random.Range (1, 5);
		
		if (indexElement == 1){
			gemElement = "Prefabs/FireGemP1";
		}
		if (indexElement == 2){
			gemElement = "Prefabs/AirGemP1";
		}
		if (indexElement == 3){
			gemElement = "Prefabs/WaterGemP1";
		}
		if (indexElement == 4){
			gemElement = "Prefabs/EarthGemP1";
		}
		
		Instantiate (Resources.Load (gemElement), new Vector2 (transform.position.x,transform.position.y), Quaternion.identity);
	}

	void SpawnFX1 (){
		
		if (elementValue == 1){
			gemElement = "Prefabs/FireGemFX01";
		}
		if (elementValue == 2){
			gemElement = "Prefabs/AirGemFX01";
		}
		if (elementValue == 3){
			gemElement = "Prefabs/WaterGemFX01";
		}
		if (elementValue == 4){
			gemElement = "Prefabs/EarthGemFX01";
		}
		
		Instantiate (Resources.Load (gemElement), new Vector2 (transform.position.x,transform.position.y), Quaternion.identity);
	}

	void SpawnOrb (){
		
		if (elementValue == 1){
			gemElement = "Prefabs/FireGemOrbP1";
		}
		if (elementValue == 2){
			gemElement = "Prefabs/AirGemOrbP1";
		}
		if (elementValue == 3){
			gemElement = "Prefabs/WaterGemOrbP1";
		}
		if (elementValue == 4){
			gemElement = "Prefabs/EarthGemOrbP1";
		}
		
		Instantiate (Resources.Load (gemElement), new Vector2 (transform.position.x,transform.position.y), Quaternion.identity);
	}
}
