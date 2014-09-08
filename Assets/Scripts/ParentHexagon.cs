using UnityEngine;
using System.Collections;

public class ParentHexagon : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (GameEngine.lastHexagon[6] == false) {
			int i = 0;
			switch ((int) (Random.value * 7)) {
				case 0 : case 1 : case 2 :
					i = (int)(Random.value * 5);
					transform.Find(i + "").gameObject.SetActive(false);
					for (int j = 0; j < GameEngine.lastHexagon.Length; j++)
						GameEngine.lastHexagon[j] = true;
					GameEngine.lastHexagon[i] = false;
					GameEngine.lastHexagon[6] = true;
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
		else {
			bool setLast = false;
			for (int i = 0; i < GameEngine.lastHexagon.Length - 1; i++) {
				if (GameEngine.lastHexagon[i] == false) {
					i += 3;
					if (i > 5)
						i = i - 6;
					transform.Find(i + "").gameObject.SetActive(false);

					if ((int) (Random.value * 2) == 0) {
						for (int j = 0; j < GameEngine.lastHexagon.Length; j++)
							GameEngine.lastHexagon[j] = true;
						GameEngine.lastHexagon[i] = false;
						GameEngine.lastHexagon[6] = true;
						setLast = true;
					}
					else {
						GameEngine.lastHexagon[6] = false;
					}
				}
			}
			if (!setLast)
				GameEngine.lastHexagon[6] = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
