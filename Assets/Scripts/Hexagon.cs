using UnityEngine;
using System.Collections;

public class Hexagon : MonoBehaviour {

	public float depth = 0f;

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

			float _distance = Vector3.Distance(transform.position + (_forward * 1.74f), Vector3.zero);
			float _depth = -4.329758f - (depth * 1.299043f);
			float _dFront = 0.577429f * _distance + 0.75f;
			float _dBack = 0.577143f * (_distance - _depth - 4.329758f) + 1.48f;

			Mesh mesh = GetComponent<MeshFilter>().mesh;
			Vector3[] vertices = mesh.vertices;

			// FRONT AND BACK FACES
			vertices[0].y = -(_dFront);		//front right top
			vertices[1].y = +(_dFront);		//front left top
			vertices[2].y = -(_dFront);		//front right top
			vertices[3].y = +(_dFront);		//front left bottom
			vertices[4].y = +(_dBack);		//back left bottom
			vertices[5].y = -(_dBack);		//back right top
			vertices[6].y = +(_dBack);		//back left top
			vertices[7].y = -(_dBack);		//back right bottom
			// testing depth
			vertices[4].x = _depth;			//back left bottom
			vertices[5].x = _depth;			//back right top
			vertices[6].x = _depth;			//back left top
			vertices[7].x = _depth;			//back right bottom
			// print(vertices[0].x + ", " + vertices[4].x);
			
			// TOP FACE
			vertices[9].y = +(_dFront);		//top left front
			vertices[11].y = -(_dFront);	//top right front
			vertices[8].y = -(_dBack);		//top right back
			vertices[10].y = +(_dBack);		//top left back
			// testing depth
			vertices[8].x = _depth;			//top right back
			vertices[10].x = _depth;		//top left back

			// SIDE FACES
			vertices[12].y = -(_dFront);	//right
			vertices[14].y = -(_dFront);	//right
			vertices[16].y = +(_dFront);	//left
			vertices[18].y = +(_dFront);	//left
			vertices[13].y = -(_dBack);		//right
			vertices[15].y = -(_dBack);		//right
			vertices[17].y = +(_dBack);		//left
			vertices[19].y = +(_dBack);		//left
			// testing depth
			vertices[13].x = _depth;		//right
			vertices[15].x = _depth;		//right
			vertices[17].x = _depth;		//left
			vertices[19].x = _depth;		//left
			
			mesh.vertices = vertices;
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
			GameEngine.hexagons.Remove(transform.parent.gameObject);
			Destroy(transform.parent.gameObject);
		}
		else if (go.tag == "Player") {
			GameObject.Find("Player/Dive_Camera/Triangle").GetComponent<MeshRenderer>().enabled = false;
			GameObject.Find("GameEngine").GetComponent<GameEngine>().audioMusic.GetComponent<AudioSource>().Stop();
			GameObject.Find("GameEngine").GetComponent<GameEngine>().audioGameOver.GetComponent<AudioSource>().Play();
			GameObject.Find("GameEngine").GetComponent<GameEngine>().audioGameOverSound.GetComponent<AudioSource>().Play();
			GameEngine.gameOver = true;
			GameEngine.endTime = Time.time;
			GameEngine.gui.switchToGameOver();
			GameObject.Find("Player").GetComponent<CameraController>().ZoomIn();
			if (Time.time - GameEngine.startTime > PlayerPrefs.GetFloat("HighScore"))
				PlayerPrefs.SetFloat("HighScore", Mathf.Round((Time.time - GameEngine.startTime) * 100) / 100);
		}
	}
}