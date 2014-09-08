using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class CameraController : MonoBehaviour {
	[SerializeField] private GameObject cameraLeft = null;
	[SerializeField] private GameObject cameraRight = null;
	public bool pulse = true;
	public bool firstPulse = false;
	public readonly float PULSE_RATE = 0.45f;

	// Use this for initialization
	void Start () {
		HOTween.Init(false, false, true);
		HOTween.EnableOverwriteManager();
	}
	
	// Update is called once per frame
	void Update () {
		if (firstPulse) {
			firstPulse = false;
			continuePulse();
		}
	}

	void continuePulse () {
		if (pulse) {
			cameraLeft.camera.fieldOfView = 73f;
			cameraRight.camera.fieldOfView = 73f;
			HOTween.To(cameraLeft.camera, PULSE_RATE, new TweenParms().Prop("fieldOfView", 75f).OnComplete(continuePulse));
			HOTween.To(cameraRight.camera, PULSE_RATE, new TweenParms().Prop("fieldOfView", 75f).OnComplete(continuePulse));
		}
	}

	public void ZoomIn () {
		HOTween.To(cameraLeft.camera, 0.5f, "fieldOfView", 43f);
		HOTween.To(cameraRight.camera, 0.5f, "fieldOfView", 43f);
	}

	public void ZoomOut () {
		HOTween.To(cameraLeft.camera, 0.5f, "fieldOfView", 75f);
		HOTween.To(cameraRight.camera, 0.5f, "fieldOfView", 75f);
	}
}
