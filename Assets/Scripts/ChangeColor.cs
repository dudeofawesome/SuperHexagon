using UnityEngine;
using System.Collections;

public class ChangeColor : MonoBehaviour {
	public bool independent = false;
	public bool highlight = true;

	int c = 0;
	ColorHSV color = new ColorHSV((int) (0), 1, 1);

	// Use this for initialization
	void Start () {
		if (!highlight) {
			color = new ColorHSV((int) (0), 1, 0.3f);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () {
		if (independent) {
			c++;
			if (c / 10 > 360) {
				c = 0;
			}
		}
		else {
			c = GameEngine.color;
		}
		color.h = (int) (c / 10);
		gameObject.renderer.material.color = color.ToColor();
	}
}
