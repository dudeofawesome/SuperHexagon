using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using Holoville.HOTween;

public class SBSgui : MonoBehaviour {
	// #if UNITY_ANDROID
	// 	[DllImport("divesensor")]	private static extern int get_m(ref float m0,ref float m1,ref float m2);
	// #endif

	[SerializeField] public GameObject cursor = null;
	[SerializeField] public GameObject super = null;
	[SerializeField] public GameObject hexagon = null;
	[SerializeField] public GameObject start = null;
	[SerializeField] public GameObject exit = null;
	[SerializeField] public GameObject restart = null;
	[SerializeField] public GameObject back = null;
	[SerializeField] public GameObject time = null;
	[SerializeField] public GameObject lastTime = null;
	[SerializeField] public GameObject bestTime = null;

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
	private int timeButtonSelected = 0;
	private readonly int timeToSelectButton = 60;
	public int cursorPosition = 200;

	[SerializeField] public float tilt = 0f;
	Rect rect = new Rect();
	Vector3 v3 = new Vector3();

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		// float x = 0, y = 0, z = 0;
		// #if UNITY_ANDROID
		// 	get_m(ref x, ref y, ref z);
		// #endif




		// tilt = (Input.acceleration.x) * 8;

		switch (menuPosition)  {
			case MenuState.MAIN :
				if (tilt < -2.500812f) {
					v3.Set(9.47f, 2.43f, 2);
					HOTween.To(cursor.transform, 0.5f, "localScale", v3);
					v3.Set(-5.305806f, 1, 4.47749f);
					HOTween.To(cursor.transform, 1f, "localPosition", v3);

					if (buttonSelected == Button.NONE) {
						GameObject.Find("Audio/ButtonHover").GetComponent<AudioSource>().Play();
						buttonSelected = Button.START;
					}
					else if (buttonSelected == Button.START) {
						timeButtonSelected++;
						if (timeButtonSelected >= timeToSelectButton) {
							GameObject.Find("Audio/ButtonPress").GetComponent<AudioSource>().Play();
							GameObject.Find("GameEngine").GetComponent<GameEngine>().startGame();
							timeButtonSelected = 0;
							switchToGame();
						}
					}
				}
				else if (tilt > 3.385096f) {
					v3.Set(8.5f, 2, 2);
					HOTween.To(cursor.transform, 0.5f, "localScale", v3);
					v3.Set(6.128964f, 1, 4.47749f);
					HOTween.To(cursor.transform, 1f, "localPosition", v3);

					if (buttonSelected == Button.NONE) {
						GameObject.Find("Audio/ButtonHover").GetComponent<AudioSource>().Play();
						buttonSelected = Button.EXIT;
					}
					else if (buttonSelected == Button.EXIT) {
						timeButtonSelected++;
						if (timeButtonSelected >= timeToSelectButton) {
							GameObject.Find("Audio/ButtonPress").GetComponent<AudioSource>().Play();
							Application.Quit ();
							timeButtonSelected = 0;
						}
					}
				}
				else {
					v3.Set(2, 2, 2);
					HOTween.To(cursor.transform, 0.5f, "localScale", v3);
					v3.Set(tilt, -1, 3.891185f);
					HOTween.To(cursor.transform, 1f, "localPosition", v3);
					if (buttonSelected != Button.NONE) {
						buttonSelected = Button.NONE;
						timeButtonSelected = 0;
					}
				}
				break;
			case MenuState.GAME :
				time.GetComponent<TextMesh>().text = (Mathf.Round((Time.time - GameEngine.startTime) * 100) / 100) + "";
				break;
			case MenuState.GAMEOVER :
				lastTime.GetComponent<TextMesh>().text = (Mathf.Round((GameEngine.endTime - GameEngine.startTime) * 100) / 100) + "";
				bestTime.GetComponent<TextMesh>().text = "Best: " + PlayerPrefs.GetFloat("HighScore");

				if (tilt < -2.500812f) {
					v3.Set(9.47f, 2.43f, 2);
					HOTween.To(cursor.transform, 0.5f, "localScale", v3);
					v3.Set(-5.305806f, 1, 4.47749f);
					HOTween.To(cursor.transform, 1f, "localPosition", v3);

					if (buttonSelected == Button.NONE) {
						GameObject.Find("Audio/ButtonHover").GetComponent<AudioSource>().Play();
						buttonSelected = Button.RESTART;
					}
					else if (buttonSelected == Button.RESTART) {
						timeButtonSelected++;
						if (timeButtonSelected >= timeToSelectButton) {
							GameObject.Find("Audio/ButtonPress").GetComponent<AudioSource>().Play();
							GameObject.Find("GameEngine").GetComponent<GameEngine>().startGame();
							timeButtonSelected = 0;
							switchToGame();
						}
					}
				}
				else if (tilt > 3.385096f) {
					v3.Set(8.5f, 2, 2);
					HOTween.To(cursor.transform, 0.5f, "localScale", v3);
					v3.Set(6.128964f, 1, 4.47749f);
					HOTween.To(cursor.transform, 1f, "localPosition", v3);

					if (buttonSelected == Button.NONE) {
						GameObject.Find("Audio/ButtonHover").GetComponent<AudioSource>().Play();
						buttonSelected = Button.BACK;
					}
					else if (buttonSelected == Button.BACK) {
						timeButtonSelected++;
						if (timeButtonSelected >= timeToSelectButton) {
							GameObject.Find("Audio/ButtonPress").GetComponent<AudioSource>().Play();
							switchToMain();
							timeButtonSelected = 0;
						}
					}
				}
				else {
					v3.Set(2, 2, 2);
					HOTween.To(cursor.transform, 0.5f, "localScale", v3);
					v3.Set(tilt, -1, 3.891185f);
					HOTween.To(cursor.transform, 1f, "localPosition", v3);
					if (buttonSelected != Button.NONE) {
						buttonSelected = Button.NONE;
						timeButtonSelected = 0;
					}
				}
				break;
		}
	}

	public void hideGUI () {
		cursor.SetActive(false);
		super.SetActive(false);
		hexagon.SetActive(false);
		start.SetActive(false);
		exit.SetActive(false);
		restart.SetActive(false);
		back.SetActive(false);
		time.SetActive(false);
		lastTime.SetActive(false);
		bestTime.SetActive(false);
	}

	public void showGUI () {
		switchToMain();
	}

	public void switchToMain () {
		menuPosition = SBSgui.MenuState.MAIN;
		hideGUI();

		cursor.SetActive(true);
		super.SetActive(true);
		hexagon.SetActive(true);
		start.SetActive(true);
		exit.SetActive(true);
	}

	public void switchToGame () {
		menuPosition = SBSgui.MenuState.GAME;
		hideGUI();

		time.SetActive(true);
	}

	public void switchToGameOver () {
		menuPosition = SBSgui.MenuState.GAMEOVER;
		hideGUI();

		cursor.SetActive(true);
		restart.SetActive(true);
		back.SetActive(true);
		lastTime.SetActive(true);
		bestTime.SetActive(true);
	}

	void OnGUI () {
		rect.Set(Screen.width / 2, 0, 0.1f, Screen.height);
		GUI.Box(rect, "");
	}
}
