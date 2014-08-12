using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class CameraController : MonoBehaviour {
	[SerializeField] private GameObject cameraLeft = null;
	[SerializeField] private GameObject cameraRight = null;

	// Use this for initialization
	void Start () {
		HOTween.Init(false, false, true);
		HOTween.EnableOverwriteManager();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ZoomIn () {
		HOTween.To(cameraLeft.camera, 0.5f, "fieldOfView", 43);
		HOTween.To(cameraRight.camera, 0.5f, "fieldOfView", 43);
	}

	public void ZoomOut () {
		HOTween.To(cameraLeft.camera, 0.5f, "fieldOfView", 75);
		HOTween.To(cameraRight.camera, 0.5f, "fieldOfView", 75);
	}
}
