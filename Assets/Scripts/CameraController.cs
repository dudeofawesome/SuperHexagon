using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class CameraController : MonoBehaviour {
	[SerializeField] public OpenDiveSensor diveSensor = null;
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
			diveSensor.zoom = 0.09344f;
			HOTween.To(diveSensor, PULSE_RATE, new TweenParms().Prop("zoom", 0.096f).OnComplete(continuePulse));
		}
	}

	public void ZoomIn () {
		HOTween.To(diveSensor, 0.5f, "zoom", 0.05504f);
	}

	public void ZoomOut () {
		HOTween.To(diveSensor, 0.5f, "zoom", 0.096f);
	}
}
