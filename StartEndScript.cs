using UnityEngine;
using System.Collections;

public class StartEndScript : MonoBehaviour {

	bool p1Started = false;
	bool p2Started = false;
	bool p1Playing = false;
	bool p2Playing = false;
	bool p1Shock = false;
	bool p2Shock = false;
	bool p1Win = false;
	bool p2Win = false;
	bool afterBlown = false;
	bool afterBlown2 = false;

	int afterBlownTime = 0;
	int afterBlownTimeMax = 60;
	int afterBlownTime2 = 0;
	int afterBlownTimeMax2 = 60;

	TextMesh winText;
	TextMesh burnText1;
	TextMesh burnText2;
	TextMesh stunText1;
	TextMesh stunText2;

	public TextMesh loadingText;
	public TextMesh nextText;

	public bool P1Started {
		get {
			return p1Started;
		}
		set {
			p1Started = value;
		}
	}

	public bool P2Started {
		get {
			return p2Started;
		}
		set {
			p2Started = value;
		}
	}

	public bool P1Playing {
		get {
			return p1Playing;
		}
		set {
			p1Playing = value;
		}
	}

	public bool P2Playing {
		get {
			return p2Playing;
		}
		set {
			p2Playing = value;
		}
	}

	public bool P1Shock {
		get {
			return p1Shock;
		}
		set {
			p1Shock = value;
		}
	}

	public bool P2Shock {
		get {
			return p2Shock;
		}
		set {
			p2Shock = value;
		}
	}

	public bool P1Win {
		get {
			return p1Win;
		}
		set {
			p1Win = value;
		}
	}

	public bool P2Win {
		get {
			return p2Win;
		}
		set {
			p2Win = value;
		}
	}

	public bool AfterBlown {
		get {
			return afterBlown;
		}
		set {
			afterBlown = value;
		}
	}

	public bool AfterBlown2 {
		get {
			return afterBlown2;
		}
		set {
			afterBlown2 = value;
		}
	}

	public int AfterBlownTime {
		get {
			return afterBlownTime;
		}
		set {
			afterBlownTime = value;
		}
	}

	public int AfterBlownTimeMax {
		get {
			return afterBlownTimeMax;
		}
		set {
			afterBlownTimeMax = value;
		}
	}

	public int AfterBlownTime2 {
		get {
			return afterBlownTime2;
		}
		set {
			afterBlownTime2 = value;
		}
	}
	
	public int AfterBlownTimeMax2 {
		get {
			return afterBlownTimeMax2;
		}
		set {
			afterBlownTimeMax2 = value;
		}
	}

	public TextMesh BurnText1 {
		get {
			return burnText1;
		}
		set {
			burnText1 = value;
		}
	}

	public TextMesh BurnText2 {
		get {
			return burnText2;
		}
		set {
			burnText2 = value;
		}
	}

	public TextMesh StunText1 {
		get {
			return stunText1;
		}
		set {
			stunText1 = value;
		}
	}

	public TextMesh StunText2 {
		get {
			return stunText2;
		}
		set {
			stunText2 = value;
		}
	}

	void Start () {

		winText = GameObject.Find ("WinText").GetComponent<TextMesh>();
		burnText1 = GameObject.Find ("BurnText1").GetComponent<TextMesh>();
		burnText2 = GameObject.Find ("BurnText2").GetComponent<TextMesh>();
		stunText1 = GameObject.Find ("StunText1").GetComponent<TextMesh>();
		stunText2 = GameObject.Find ("StunText2").GetComponent<TextMesh>();

		winText.text = " ";
		burnText1.text = " ";
		burnText2.text = " ";
		stunText1.text = " ";
		stunText2.text = " ";

		loadingText.text = " ";
		nextText.text = " ";
	
		p1Playing = true;
		p2Playing = true;

		afterBlownTime = afterBlownTimeMax;
		afterBlownTime2 = afterBlownTimeMax2;

	}

	void Update () {

		if (Input.GetKeyUp (KeyCode.Joystick1Button5) || Input.GetKeyUp (KeyCode.Space)){
			p1Started = true;
		}

		if (Input.GetKeyUp (KeyCode.Joystick2Button5) || Input.GetKeyUp (KeyCode.Keypad0)){
			p2Started = true;
		}

		if (p1Win || p2Win){
			p1Playing = false;
			p2Playing = false;
		}

		if (p1Win && !p2Win){

			winText.text = "West Dragon Wins";
			NextToDo ();
		}

		if (!p1Win && p2Win){
			
			winText.text = "East Dragon Wins";
			NextToDo ();
		}

		if (p1Win && p2Win){
			
			winText.text = "DRAW";
			NextToDo ();
		}

		if (afterBlown) {
			afterBlownTime --;
		}

		if (afterBlownTime <= 0) {
			afterBlownTime = afterBlownTimeMax;
		}

		if (afterBlown2) {
			afterBlownTime2 --;
		}
		
		if (afterBlownTime2 <= 0) {
			afterBlownTime2 = afterBlownTimeMax2;
		}
	
	}

	void NextToDo (){

		nextText.text = "Press ENTER or START to Continue";

		if (Input.GetKeyDown (KeyCode.Joystick1Button7) || Input.GetKeyDown (KeyCode.Joystick2Button7) || Input.GetKeyDown (KeyCode.Return)) {
			LoadLevel ();
		}

	}

	public void LoadLevel (){
		
		StartCoroutine (LevelCoroutine ());
		
	}
	
	IEnumerator LevelCoroutine (){
		
		AsyncOperation async = Application.LoadLevelAsync (0);
		
		while (!async.isDone) {
			float loadProgress = async.progress * 100;
			loadingText.text = "Loading...\n" + loadProgress.ToString ("n0") + "%";
			yield return null;
		}
		
	}

}
