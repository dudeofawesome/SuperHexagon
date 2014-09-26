using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Holoville.HOTween;

public class GameEngine : MonoBehaviour {
	[SerializeField] private GameObject player = null;
	[SerializeField] public GameObject audioMusic = null;
	[SerializeField] public GameObject audioGameOver = null;
	[SerializeField] public GameObject audioGameOverSound = null;
	[SerializeField] public GameObject cameraLeft = null;
	[SerializeField] public GameObject cameraRight = null;
	public static List<GameObject> hexagons = new List<GameObject>();
	public static bool[] lastHexagon = new bool[7];
	public float rotationVelocity = 10;
	public static bool gameOver = true;
	public static int color = 2100;
	public static float startTime = 0;
	public static float endTime = 0;
	private int fixedUpdateCount = 0;
	public static int nextHex = 80;


	[SerializeField] private GameObject prefabHexagon = null;

	public GUISkin unselectedSkin;
	public GUISkin selectedSkin;
	private GUIStyle hexagonFont = new GUIStyle();
	private GUIStyle leftAlign = new GUIStyle();
	private GUIStyle rightAlign = new GUIStyle();

	public enum MenuState
	{
		MAIN,
		LEVELS,
		GAME,
		GAMEOVER
	};
	public static MenuState menuPosition = MenuState.MAIN;

	public enum Button
	{
		NONE,
		START,
		RESTART,
		BACK,
		EXIT
	};
	[SerializeField] private Button buttonSelected = Button.NONE;
	private dRect3D startButton = new dRect3D(new Rect(416, 260, 100, 55), new Rect(66, 260, 100, 55));
	private dRect3D exitButton = new dRect3D(new Rect(634, 260, 100, 55), new Rect(285, 260, 100, 55));
	private dRect3D restartButton = new dRect3D(new Rect(401, 260, 125, 55), new Rect(41, 260, 125, 55));
	private dRect3D timeLabel = new dRect3D(new Rect(410, 80, 100, 55), new Rect(60, 80, 100, 55));
	private dRect3D highScoreLabel = new dRect3D(new Rect(645, 80, 100, 55), new Rect(295, 80, 100, 55));
	private int timeButtonSelected = 0;
	private readonly int timeToSelectButton = 60;
	public int cursorPosition = 200;

	[SerializeField] private Texture cursor = null;
	private float originalWidth = 800;
	private float originalHeight = 480;
	private Vector3 scale;
	Rect rect;
	Vector2 pivot;

	// Use this for initialization
	void Start () {
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		
		HOTween.Init(false, false, true);
		HOTween.EnableOverwriteManager();

		hexagonFont.fontSize = 27;
		hexagonFont.normal.textColor = Color.white;
		leftAlign.alignment = TextAnchor.MiddleLeft;
		leftAlign.normal.textColor = Color.white;
		leftAlign.fontSize = 12;
		rightAlign.alignment = TextAnchor.MiddleRight;
		rightAlign.normal.textColor = Color.white;
		rightAlign.fontSize = 12;
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameOver) {
			// if (Input.GetKey(KeyCode.LeftArrow)) {
			// 	player.transform.Rotate(0, Time.deltaTime * -rotationVelocity, 0);
			// }
			// if (Input.GetKey(KeyCode.RightArrow)) {
			// 	player.transform.Rotate(0, Time.deltaTime * rotationVelocity, 0);
			// }
			if (OpenDiveSensor.noGyroAccessible)
				HOTween.To(player.transform, 1f, "localRotation", Quaternion.Euler(new Vector3(0, (Input.acceleration.x) * 450, 0)));
			// player.transform.localRotation = Quaternion.Euler(new Vector3(0, (Input.acceleration.x) * 450, 0));
		}
		else {
			player.transform.localRotation = Quaternion.Euler(new Vector3(player.transform.localRotation.eulerAngles.x, player.transform.localRotation.eulerAngles.y + 1, player.transform.localRotation.eulerAngles.z));
			HOTween.To(this, 1f, "cursorPosition", (int) ((Input.acceleration.x + 1) * originalWidth / 4));
			// cursorPosition = (int) ((Input.acceleration.x + 1) * originalWidth / 4);
		}
	}

	void FixedUpdate () {
		if (!gameOver){
			fixedUpdateCount++;
			nextHex--;
			if (nextHex < 0){
				newHexagon();
			}

			color--;
			if (color < 0) {
				color = 3600;
			}
		}
		else {
			fixedUpdateCount = 0;

			switch (menuPosition) {
				case MenuState.MAIN :
					if (startButton.center.Contains(new Vector2(cursorPosition, 273))){
						if (buttonSelected != Button.START){
							buttonSelected = Button.START;
							timeButtonSelected = 0;
							GameObject.Find("Audio/ButtonHover").GetComponent<AudioSource>().Play();
						}
						timeButtonSelected++;
						if (timeButtonSelected > timeToSelectButton) {
							startGame();
							timeButtonSelected = 0;
							buttonSelected = Button.NONE;
							GameObject.Find("Audio/ButtonPress").GetComponent<AudioSource>().Play();
						}
					}
					else if (exitButton.center.Contains(new Vector2(cursorPosition, 273))){
						if (buttonSelected != Button.EXIT){
							buttonSelected = Button.EXIT;
							timeButtonSelected = 0;
							GameObject.Find("Audio/ButtonHover").GetComponent<AudioSource>().Play();
						}
						timeButtonSelected++;
						if (timeButtonSelected > timeToSelectButton) {
							Application.Quit();
							timeButtonSelected = 0;
							buttonSelected = Button.NONE;
							GameObject.Find("Audio/ButtonPress").GetComponent<AudioSource>().Play();
						}
					}
					else {
						buttonSelected = Button.NONE;
						timeButtonSelected = 0;
					}
					break;
				case MenuState.GAMEOVER :
					if (restartButton.center.Contains(new Vector2(cursorPosition, 273))){
						if (buttonSelected != Button.RESTART){
							buttonSelected = Button.RESTART;
							timeButtonSelected = 0;
							GameObject.Find("Audio/ButtonHover").GetComponent<AudioSource>().Play();
						}
						timeButtonSelected++;
						if (timeButtonSelected > timeToSelectButton) {
							startGame();
							timeButtonSelected = 0;
							buttonSelected = Button.NONE;
							GameObject.Find("Audio/ButtonPress").GetComponent<AudioSource>().Play();
						}
					}
					else if (exitButton.center.Contains(new Vector2(cursorPosition, 273))){
						if (buttonSelected != Button.BACK){
							buttonSelected = Button.BACK;
							timeButtonSelected = 0;
							GameObject.Find("Audio/ButtonHover").GetComponent<AudioSource>().Play();
						}
						timeButtonSelected++;
						if (timeButtonSelected > timeToSelectButton) {
							menuPosition = MenuState.MAIN;
							timeButtonSelected = 0;
							buttonSelected = Button.NONE;
							GameObject.Find("Audio/ButtonPress").GetComponent<AudioSource>().Play();
						}
					}
					else {
						buttonSelected = Button.NONE;
						timeButtonSelected = 0;
					}
					break;
			}
		}
	}

	void newHexagon () {
		hexagons.Add((GameObject) Instantiate(prefabHexagon));
	}

	void startGame() {
		menuPosition = MenuState.GAME;
		gameOver = false;
		// Application.LoadLevel("Game");
		GameObject.Find("Player/Dive_Camera/Triangle").GetComponent<MeshRenderer>().enabled = true;
		for (int i = 0; i < hexagons.Count; i++) {
			Destroy(hexagons[i]);
		}
		hexagons.Clear();
		player.GetComponent<CameraController>().ZoomOut();
		player.GetComponent<CameraController>().pulse = true;
		player.GetComponent<CameraController>().firstPulse = true;
		GameObject.Find("Audio/Begin").GetComponent<AudioSource>().Play();
		GameObject.Find("Audio/Music").GetComponent<AudioSource>().Play();
		startTime = Time.time;
	}








	void OnGUI ()
	{
		GUI.skin = unselectedSkin;
		
		rect.Set(Screen.width / 2, 0, 1, Screen.height);
		GUI.Box(rect, "");

		scale.x = Screen.width / originalWidth; // calculate hor scale
		scale.y = Screen.height / originalHeight; // calculate vert scale
		scale.z = 1;
		var svMat = GUI.matrix; // save current matrix
		// substitute matrix - only scale is altered from standard
		GUI.matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity, scale);

		switch (menuPosition) {
				
			case MenuState.MAIN:
				if (!Application.genuine) {
					rect.Set(0, 410, 400, 70);
					GUI.Box (rect, "PLEASE BUY");
				}
				
				rect.Set(125,100,130,72);
				GUI.Label(rect, "Super", hexagonFont);
				rect.Set(130,110,200,72);
				GUI.Label(rect, "Hexagon");
				rect.Set(525,100,130,72);
				GUI.Label(rect, "Super", hexagonFont);
				rect.Set(530,110,200,72);
				GUI.Label(rect, "Hexagon");
				
				if (buttonSelected == Button.START)
					GUI.skin = selectedSkin;
				else
					GUI.skin = unselectedSkin;
				if (GUI.Button (startButton.left, "Start")) {
					startGame();
				}
				if (buttonSelected == Button.EXIT)
					GUI.skin = selectedSkin;
				else
					GUI.skin = unselectedSkin;
				if (GUI.Button (exitButton.left, "Exit")) {
					Application.Quit ();
				}
				if (buttonSelected == Button.START)
					GUI.skin = selectedSkin;
				else
					GUI.skin = unselectedSkin;
				if (GUI.Button (startButton.right, "Start")) {
					startGame();
				}
				if (buttonSelected == Button.EXIT)
					GUI.skin = selectedSkin;
				else
					GUI.skin = unselectedSkin;
				if (GUI.Button (exitButton.right, "Exit")) {
					Application.Quit ();
				}
				
				rect.Set(cursorPosition, 273, 30, 30);
				GUI.Label(rect, cursor);
				rect.Set(cursorPosition + 410 - 50, 273, 30, 30);
				GUI.Label(rect, cursor);
				break;
				
			case MenuState.GAME:				
				GUI.Label(timeLabel.left, (Mathf.Round((Time.time - startTime) * 100) / 100) + "", leftAlign);
				GUI.Label(timeLabel.right, (Mathf.Round((Time.time - startTime) * 100) / 100) + "", leftAlign);
				break;
				
			case MenuState.GAMEOVER:
				int _levelEarned = (int) ((endTime - startTime) / 10);
				if (_levelEarned > 6) _levelEarned = 6;
				rect.Set(165,200,150,50);
				GUI.Label(rect, "Level " + _levelEarned);
				rect.Set(530,200,150,50);
				GUI.Label(rect, "Level " + _levelEarned);
				
				if (buttonSelected == Button.RESTART)
					GUI.skin = selectedSkin;
				else
					GUI.skin = unselectedSkin;
				if (GUI.Button (restartButton.left, "Retry")) {
					startGame();
				}
				if (buttonSelected == Button.BACK)
					GUI.skin = selectedSkin;
				else
					GUI.skin = unselectedSkin;
				if (GUI.Button (exitButton.left, "Back")) {
					menuPosition = MenuState.MAIN;
				}
				if (buttonSelected == Button.RESTART)
					GUI.skin = selectedSkin;
				else
					GUI.skin = unselectedSkin;
				if (GUI.Button (restartButton.right, "Retry")) {
					startGame();
				}
				if (buttonSelected == Button.BACK)
					GUI.skin = selectedSkin;
				else
					GUI.skin = unselectedSkin;
				if (GUI.Button (exitButton.right, "Back")) {
					menuPosition = MenuState.MAIN;
				}
				GUI.Label(timeLabel.left, ("Last " + Mathf.Round((endTime - startTime) * 100) / 100), leftAlign);
				GUI.Label(timeLabel.right, ("Last " + Mathf.Round((endTime - startTime) * 100) / 100), leftAlign);
				GUI.Label(highScoreLabel.left, "Best " + PlayerPrefs.GetFloat("HighScore"), rightAlign);
				GUI.Label(highScoreLabel.right, "Best " + PlayerPrefs.GetFloat("HighScore"), rightAlign);

				
				rect.Set(cursorPosition, 273, 30, 30);
				GUI.Label(rect, cursor);
				rect.Set(cursorPosition + 360, 273, 30, 30);
				GUI.Label(rect, cursor);
				break;

			case MenuState.LEVELS:
				rect.Set(0, 20, 800, 460);
				GUI.Box (rect, "");
				rect.Set(50, 20, 550, 85);
				GUI.Label (rect, "Select Visual Style");
				
				menuPosition = MenuState.GAME;
				gameOver = false;
				break;
		}


			
		
		// restore matrix before returning
		GUI.matrix = svMat; // restore matrix
	}
}
