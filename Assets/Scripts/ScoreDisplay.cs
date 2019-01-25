using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

	void Start () {
		Text myText = GetComponent<Text>();
		myText.text = ScoreKeeper.score.ToString();
		ScoreKeeper.Reset();
	}
}
