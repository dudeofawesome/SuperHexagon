using UnityEngine;
using System.Collections;

public class dPredefPattern : MonoBehaviour {
	public enum PatternType {NONE, BACKANDFORTH, SPIRAL, TURN180};
	public PatternType patternType = PatternType.NONE;
	public bool continuePattern = true;
	public bool lastWentRight = false;
	public bool spiralRight = true;
	public int lengthOfPattern = 5;

	public dPredefPattern () {

	}

	public dPredefPattern (PatternType patternType) {
		this.patternType = patternType;
	}

	public void increment () {
		switch (patternType) {
			case PatternType.BACKANDFORTH :
				lastWentRight = !lastWentRight;
				break;
			case PatternType.SPIRAL :
				
				break;
			case PatternType.TURN180 :
				
				break;
		}

		if (lengthOfPattern != -1)
			lengthOfPattern--;
		if (lengthOfPattern > 0) {
			continuePattern = true;
		}
		else {
			continuePattern = false;
			lengthOfPattern = -1;
			GameEngine.predefPattern.patternType = PatternType.NONE;
		}
	}
}
