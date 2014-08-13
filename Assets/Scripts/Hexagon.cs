using UnityEngine;
using System.Collections;

public class Hexagon : MonoBehaviour {

	private bool use2ndSet = false;
	private bool goneNegative = false;

	// Use this for initialization
	void Start () {
		Vector3 _forward = transform.Find("forward").transform.forward;
		transform.position = new Vector3(_forward.x * 35,0.6f,_forward.z * 35);
	}
	
	// Update is called once per frame
	void Update () {
		if (!GameEngine.gameOver) {
			Vector3 _forward = transform.Find("forward").transform.forward;
			transform.position = new Vector3(transform.position.x + _forward.x * -5 * Time.deltaTime,0.6f,transform.position.z + _forward.z * -5 * Time.deltaTime);

			float _distance = Vector3.Distance(transform.position, Vector3.zero);
			if (_distance > 0.9f && !use2ndSet)
				transform.localScale = new Vector3(1, 0.977f + 0.232f * _distance, 1);
			else{
				// print(_distance);
				// Time.timeScale = 0.1f;
				use2ndSet = true;
				if (_distance < 0.1f) {
					goneNegative = true;
				}
				if (_distance > 0.6144f)
					transform.localScale = new Vector3(1, -Mathf.Log(_distance + 0.1f) + 0.86f, 1);
				else {
					// transform.localScale = new Vector3(1, 1.14f, 1);
					if (!goneNegative) {
						transform.localScale = new Vector3(1, 1.071f - 0.083f * _distance, 1);
					}
					else {
						transform.localScale = new Vector3(1, 1.071f + 0.083f * _distance, 1);						
					}
				}
			}
		}
	}

	void OnTriggerEnter (Collider collision) {
		MyOnCollision(collision.gameObject);
	}
	
	void OnCollisionEnter (Collision collision) {
		MyOnCollision(collision.gameObject);
	}

	void MyOnCollision (GameObject go) {
		if (go.tag == "CenterHexagon") {
			GameEngine.hexagons.Remove(gameObject);
			Destroy(gameObject);
		}
		else if (go.tag == "Player") {
			GameObject.Find("Player/Triangle").GetComponent<MeshRenderer>().enabled = false;
			GameObject.Find("GameEngine").GetComponent<GameEngine>().audioMusic.GetComponent<AudioSource>().Stop();
			GameObject.Find("GameEngine").GetComponent<GameEngine>().audioGameOver.GetComponent<AudioSource>().Play();
			GameObject.Find("GameEngine").GetComponent<GameEngine>().audioGameOverSound.GetComponent<AudioSource>().Play();
			GameEngine.gameOver = true;
			GameEngine.endTime = Time.time;
			GameEngine.menuPosition = GameEngine.MenuState.GAMEOVER;
			GameObject.Find("Player").GetComponent<CameraController>().ZoomIn();
			if (Time.time - GameEngine.startTime > PlayerPrefs.GetFloat("HighScore"))
				PlayerPrefs.SetFloat("HighScore", Mathf.Round((Time.time - GameEngine.startTime) * 100) / 100);
		}
	}
}