using UnityEngine;
using System.Collections;

public class ParentHexagon : MonoBehaviour {

	void Start () {
		if (GameEngine.predefPattern.patternType == dPredefPattern.PatternType.TURN180) {
			print("creating turn180");
			bool setLast = false;
			bool disabledFace = false;
			for (int i = 0; i < GameEngine.lastHexagon.Length; i++) {
				if (GameEngine.lastHexagon[i] == false) {
					i += 3;
					if (i > 5)
						i = i - 6;
					transform.Find(i + "").gameObject.SetActive(false);

					if (GameEngine.predefPattern.continuePattern) {
						for (int j = 0; j < GameEngine.lastHexagon.Length; j++)
							GameEngine.lastHexagon[j] = true;
						GameEngine.lastHexagon[i] = false;
						setLast = true;
					}
					else {
						GameEngine.predefPattern.patternType = dPredefPattern.PatternType.NONE;
					}
					GameEngine.predefPattern.increment();
					disabledFace = true;
					break;
				}
			}
			if (!disabledFace) {
				transform.Find(((int) (Random.value * 6)) + "").gameObject.SetActive(false);
			}
			if (!setLast)
				GameEngine.predefPattern.patternType = dPredefPattern.PatternType.NONE;
			GameEngine.nextHex = 60;//80;
		}
		else if (GameEngine.predefPattern.patternType == dPredefPattern.PatternType.BACKANDFORTH) {
			print("creating backandforth");
			bool setLast = false;
			for (int i = 0; i < GameEngine.lastHexagon.Length - 1; i++) {
				if (GameEngine.lastHexagon[i] == false) {
					for (int j = 0; j < 6; j++) {
						if (j != i)
							transform.Find(j + "").GetComponent<Hexagon>().depth = 2.3275f;
					}
					i += (GameEngine.predefPattern.lastWentRight) ? -1 : 1;
					if (i > 5)
						i -= 6;
					if (i < 0)
						i += 6;
					transform.Find(i + "").gameObject.SetActive(false);

					if (GameEngine.predefPattern.continuePattern) {
						for (int j = 0; j < GameEngine.lastHexagon.Length; j++)
							GameEngine.lastHexagon[j] = true;
						GameEngine.lastHexagon[i] = false;
						setLast = true;
					}
					else {
						GameEngine.predefPattern.patternType = dPredefPattern.PatternType.NONE;
					}
					GameEngine.predefPattern.increment();
					break;
				}
			}
			if (!setLast)
				GameEngine.predefPattern.patternType = dPredefPattern.PatternType.NONE;
			GameEngine.nextHex = 35;//80;
		}
		else if (GameEngine.predefPattern.patternType == dPredefPattern.PatternType.SPIRAL) {
			print("creating spiral");
			bool setLast = false;
			for (int i = 0; i < 6; i++) {
				transform.Find(i + "").GetComponent<Hexagon>().depth = 1.995f;
			}
			bool disabledFace = false;
			for (int i = 0; i < GameEngine.lastHexagon.Length - 1; i++) {
				if (GameEngine.lastHexagon[i] == false) {
					i++;
					if (i > 5)
						i = i - 6;
					transform.Find(i + "").gameObject.SetActive(false);

					if (GameEngine.predefPattern.continuePattern) {
						for (int j = 0; j < GameEngine.lastHexagon.Length; j++)
							GameEngine.lastHexagon[j] = true;
						GameEngine.lastHexagon[i] = false;
						setLast = true;
					}
					else {
						GameEngine.predefPattern.patternType = dPredefPattern.PatternType.NONE;
						GameEngine.lastHexagon[i] = false;
					}

					i++;
					if (i > 5)
						i = i - 6;
					transform.Find(i + "").GetComponent<Hexagon>().depth = 0.1f;


					GameEngine.predefPattern.increment();
					disabledFace = true;
					break;
				}
			}
			if (!disabledFace) {
				transform.Find(((int) (Random.value * 6)) + "").gameObject.SetActive(false);
			}
			if (!setLast)
				GameEngine.predefPattern.patternType = dPredefPattern.PatternType.NONE;
			GameEngine.nextHex = 30;
		}
		else {
			print("creating other");
			int i = 0;
			switch ((int) (Random.value * 9)) {
				case 0 : case 1 : case 2 :	// Turn 180
					i = (int)(Random.value * 5);
					transform.Find(i + "").gameObject.SetActive(false);
					for (int j = 0; j < GameEngine.lastHexagon.Length; j++)
						GameEngine.lastHexagon[j] = true;
					GameEngine.lastHexagon[i] = false;
					GameEngine.predefPattern.patternType = dPredefPattern.PatternType.TURN180;
					GameEngine.predefPattern.lengthOfPattern = (int) (Random.value * 6) + 1;
					GameEngine.nextHex = 60;//80;
					break;
				case 3 : case 4 :			// Off On Off On On On
					i = (int)(Random.value * 5);
					transform.Find(i + "").gameObject.SetActive(false);
					i += 2;
					if (i > 5)
						i = i - 6;
					transform.Find(i + "").gameObject.SetActive(false);
					GameEngine.nextHex = 60;
					break;
				case 5 :					// Opposite Sides
					i = (int)(Random.value * 5);
					transform.Find(i + "").gameObject.SetActive(false);
					i += 3;
					if (i > 5)
						i = i - 6;
					transform.Find(i + "").gameObject.SetActive(false);
					GameEngine.nextHex = 60;
					break;
				case 6 :					// Every Other
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
					GameEngine.nextHex = 60;
					break;
				case 7 :					// Back and Forth
					for (int j = 0; j < 6; j++)
						transform.Find(j + "").GetComponent<Hexagon>().depth = 2.66f;
					i = (int)(Random.value * 5);
					transform.Find(i + "").gameObject.SetActive(false);
					for (int j = 0; j < GameEngine.lastHexagon.Length; j++)
						GameEngine.lastHexagon[j] = true;
					GameEngine.lastHexagon[i] = false;
					GameEngine.predefPattern.patternType = dPredefPattern.PatternType.BACKANDFORTH;
					GameEngine.predefPattern.lengthOfPattern = (int) (Random.value * 2) + 4;
					GameEngine.nextHex = 40;
					break;
				case 8 :					// Spiral
					for (int j = 0; j < 6; j++)
						transform.Find(j + "").GetComponent<Hexagon>().depth = 1.995f;
					i = (int)(Random.value * 5);
					transform.Find(i + "").gameObject.SetActive(false);
					for (int j = 0; j < GameEngine.lastHexagon.Length; j++)
						GameEngine.lastHexagon[j] = true;
					GameEngine.lastHexagon[i] = false;
					GameEngine.predefPattern.patternType = dPredefPattern.PatternType.SPIRAL;
					GameEngine.predefPattern.lengthOfPattern = 10;
					GameEngine.nextHex = 30;
					break;
			}
		}

		// GameEngine.nextHex = 80;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
