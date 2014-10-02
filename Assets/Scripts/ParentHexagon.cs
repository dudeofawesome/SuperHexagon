using UnityEngine;
using System.Collections;

public class ParentHexagon : MonoBehaviour {

	// Use this for initialization
	// void Start () {
	// 	if (GameEngine.predefPattern.patternType == dPredefPattern.PatternType.TURN180) {
	// 		bool setLast = false;
	// 		for (int i = 0; i < GameEngine.lastHexagon.Length - 1; i++) {
	// 			if (GameEngine.lastHexagon[i] == false) {
	// 				i += 3;
	// 				if (i > 5)
	// 					i = i - 6;
	// 				transform.Find(i + "").gameObject.SetActive(false);

	// 				if (GameEngine.predefPattern.continuePattern) {
	// 					for (int j = 0; j < GameEngine.lastHexagon.Length; j++)
	// 						GameEngine.lastHexagon[j] = true;
	// 					GameEngine.lastHexagon[i] = false;
	// 					setLast = true;
	// 				}
	// 				else {
	// 					GameEngine.predefPattern.patternType = dPredefPattern.PatternType.NONE;
	// 				}
	// 				GameEngine.predefPattern.increment();
	// 			}
	// 		}
	// 		if (!setLast)
	// 			GameEngine.predefPattern.patternType = dPredefPattern.PatternType.NONE;
	// 		GameEngine.nextHex = 60;//80;
	// 	}
	// 	else if (GameEngine.predefPattern.patternType == dPredefPattern.PatternType.BACKANDFORTH) {
	// 		bool setLast = false;
	// 		for (int i = 0; i < 6; i++) {
	// 			transform.Find(i + "").GetComponent<Hexagon>().depth = 5.32f;
	// 		}
	// 		for (int i = 0; i < GameEngine.lastHexagon.Length - 1; i++) {
	// 			if (GameEngine.lastHexagon[i] == false) {
	// 				i += (GameEngine.predefPattern.lastWentRight) ? -1 : 1;
	// 				if (i > 5)
	// 					i = i - 6;
	// 				transform.Find(i + "").gameObject.SetActive(false);

	// 				if (GameEngine.predefPattern.continuePattern) {
	// 					for (int j = 0; j < GameEngine.lastHexagon.Length; j++)
	// 						GameEngine.lastHexagon[j] = true;
	// 					GameEngine.lastHexagon[i] = false;
	// 					setLast = true;
	// 				}
	// 				else {
	// 					GameEngine.predefPattern.patternType = dPredefPattern.PatternType.NONE;
	// 				}
	// 				GameEngine.predefPattern.increment();
	// 			}
	// 		}
	// 		if (!setLast)
	// 			GameEngine.predefPattern.patternType = dPredefPattern.PatternType.NONE;
	// 		GameEngine.nextHex = 40;//80;
	// 	}
	// 	else if (GameEngine.predefPattern.patternType == dPredefPattern.PatternType.SPIRAL) {

	// 	}
	// 	else {
	// 		int i = 0;
	// 		switch ((int) (Random.value * 8)) {
	// 			case 0 : case 1 : case 2 :
	// 				i = (int)(Random.value * 5);
	// 				transform.Find(i + "").gameObject.SetActive(false);
	// 				for (int j = 0; j < GameEngine.lastHexagon.Length; j++)
	// 					GameEngine.lastHexagon[j] = true;
	// 				GameEngine.lastHexagon[i] = false;
	// 				GameEngine.predefPattern.patternType = dPredefPattern.PatternType.TURN180;
	// 				GameEngine.predefPattern.lengthOfPattern = (int) (Random.value * 7);
	// 				GameEngine.nextHex = 60;//80;
	// 				break;
	// 			case 3 : case 4 :
	// 				i = (int)(Random.value * 5);
	// 				transform.Find(i + "").gameObject.SetActive(false);
	// 				i += 2;
	// 				if (i > 5)
	// 					i = i - 6;
	// 				transform.Find(i + "").gameObject.SetActive(false);
	// 				GameEngine.nextHex = 60;//80;
	// 				break;
	// 			case 5 :
	// 				i = (int)(Random.value * 5);
	// 				transform.Find(i + "").gameObject.SetActive(false);
	// 				i += 3;
	// 				if (i > 5)
	// 					i = i - 6;
	// 				transform.Find(i + "").gameObject.SetActive(false);
	// 				GameEngine.nextHex = 60;//80;
	// 				break;
	// 			case 6 :
	// 				i = (int)(Random.value * 5);
	// 				transform.Find(i + "").gameObject.SetActive(false);
	// 				i += 2;
	// 				if (i > 5)
	// 					i = i - 6;
	// 				transform.Find(i + "").gameObject.SetActive(false);
	// 				i += 2;
	// 				if (i > 5)
	// 					i = i - 6;
	// 				transform.Find(i + "").gameObject.SetActive(false);
	// 				GameEngine.nextHex = 60;//80;
	// 				break;
	// 			case 7 :
	// 				for (int j = 0; j < 6; j++) {
	// 					transform.Find(j + "").GetComponent<Hexagon>().depth = 5.32f;
	// 				}
	// 				i = (int)(Random.value * 5);
	// 				transform.Find(i + "").gameObject.SetActive(false);
	// 				for (int j = 0; j < GameEngine.lastHexagon.Length; j++)
	// 					GameEngine.lastHexagon[j] = true;
	// 				GameEngine.lastHexagon[i] = false;
	// 				GameEngine.predefPattern.patternType = dPredefPattern.PatternType.BACKANDFORTH;
	// 				GameEngine.predefPattern.lengthOfPattern = (int) (Random.value * 2) + 4;
	// 				GameEngine.nextHex = 60;//80;
	// 				break;
	// 		}
	// 	}

	// 	// GameEngine.nextHex = 80;
	// }
	




	void Start () {
		if (GameEngine.predefPattern.patternType == dPredefPattern.PatternType.TURN180) {
			print("creating turn180");
			bool setLast = false;
			for (int i = 0; i < GameEngine.lastHexagon.Length - 1; i++) {
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
				}
			}
			if (!setLast)
				GameEngine.predefPattern.patternType = dPredefPattern.PatternType.NONE;
			GameEngine.nextHex = 60;//80;
		}
		else if (GameEngine.predefPattern.patternType == dPredefPattern.PatternType.BACKANDFORTH) {
			print("creating backandforth");
			bool setLast = false;
			for (int i = 0; i < 6; i++) {
				transform.Find(i + "").GetComponent<Hexagon>().depth = 5.32f;
			}
			for (int i = 0; i < GameEngine.lastHexagon.Length - 1; i++) {
				if (GameEngine.lastHexagon[i] == false) {
					i += (GameEngine.predefPattern.lastWentRight) ? -1 : 1;
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
				}
			}
			if (!setLast)
				GameEngine.predefPattern.patternType = dPredefPattern.PatternType.NONE;
			GameEngine.nextHex = 40;//80;
		}
		else if (GameEngine.predefPattern.patternType == dPredefPattern.PatternType.SPIRAL) {
			print("creating spiral");

		}
		else {
			print("creating other");
			int i = 0;
			switch ((int) (Random.value * 8)) {
				case 0 : case 1 : case 2 :
					i = (int)(Random.value * 5);
					transform.Find(i + "").gameObject.SetActive(false);
					for (int j = 0; j < GameEngine.lastHexagon.Length; j++)
						GameEngine.lastHexagon[j] = true;
					GameEngine.lastHexagon[i] = false;
					GameEngine.predefPattern.patternType = dPredefPattern.PatternType.TURN180;
					GameEngine.predefPattern.lengthOfPattern = (int) (Random.value * 7);
					GameEngine.nextHex = 60;//80;
					break;
				case 3 : case 4 :
					i = (int)(Random.value * 5);
					transform.Find(i + "").gameObject.SetActive(false);
					i += 2;
					if (i > 5)
						i = i - 6;
					transform.Find(i + "").gameObject.SetActive(false);
					GameEngine.nextHex = 60;//80;
					break;
				case 5 :
					i = (int)(Random.value * 5);
					transform.Find(i + "").gameObject.SetActive(false);
					i += 3;
					if (i > 5)
						i = i - 6;
					transform.Find(i + "").gameObject.SetActive(false);
					GameEngine.nextHex = 60;//80;
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
					GameEngine.nextHex = 60;//80;
					break;
				case 7 :
					for (int j = 0; j < 6; j++) {
						transform.Find(j + "").GetComponent<Hexagon>().depth = 5.32f;
					}
					i = (int)(Random.value * 5);
					transform.Find(i + "").gameObject.SetActive(false);
					for (int j = 0; j < GameEngine.lastHexagon.Length; j++)
						GameEngine.lastHexagon[j] = true;
					GameEngine.lastHexagon[i] = false;
					GameEngine.predefPattern.patternType = dPredefPattern.PatternType.BACKANDFORTH;
					GameEngine.predefPattern.lengthOfPattern = (int) (Random.value * 2) + 4;
					GameEngine.nextHex = 60;//80;
					break;
			}
		}

		// GameEngine.nextHex = 80;
	}
	
	//turn180		111
	//backandforth	
	//spiral		
	//other			




	// Update is called once per frame
	void Update () {
	
	}
}
