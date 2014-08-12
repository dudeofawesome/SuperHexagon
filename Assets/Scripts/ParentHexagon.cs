using UnityEngine;
using System.Collections;

public class ParentHexagon : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int i = 0;
		switch ((int) (Random.value * 7)) {
			case 0 : case 1 : case 2 :
				i = (int)(Random.value * 5);
				transform.Find(i + "").gameObject.SetActive(false);
				break;
			case 3 : case 4 :
				i = (int)(Random.value * 5);
				transform.Find(i + "").gameObject.SetActive(false);
				i += 2;
				if (i > 5)
					i = i - 6;
				transform.Find(i + "").gameObject.SetActive(false);
				break;
			case 5 :
				i = (int)(Random.value * 5);
				transform.Find(i + "").gameObject.SetActive(false);
				i += 3;
				if (i > 5)
					i = i - 6;
				transform.Find(i + "").gameObject.SetActive(false);
				break;
			case 6 :
				i = (int)(Random.value * 5);
				transform.Find(i + "").gameObject.SetActive(false);
				i += 2;
				if (i > 5)
					i = i - 6;
				transform.Find(i + "").gameObject.SetActive(false);
				i += 2;
				if (i > 5)
					i = i - 6;
				transform.Find(i + "").gameObject.SetActive(false);
				break;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
