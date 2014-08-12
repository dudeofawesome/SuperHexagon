using UnityEngine;
using System.Collections;

public class dRect3D {
	public Rect left = new Rect();
	public Rect right = new Rect();
	public Rect center = new Rect();

	public dRect3D () {

	}

	public dRect3D (Rect left, Rect right) {
		this.left = left;
		this.right = right;
		this.center = new Rect((left.x + right.x - 400) / 2, (left.y + right.y) / 2, (left.width + right.width) / 2, (left.height + right.height) / 2);
	}
}
