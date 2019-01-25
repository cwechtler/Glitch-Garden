using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

	public static int score;
	private Text scoreText;
	
	void Start(){
		scoreText = GetComponent<Text>();
		scoreText.text = ScoreKeeper.score.ToString();
	}
	
	public void Score(int points){
		score += points;
		scoreText.text = score.ToString();
	}
	
	public static void Reset(){
		score = 0;
	}

}
