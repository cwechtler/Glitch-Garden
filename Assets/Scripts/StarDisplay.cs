using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour {

	private Text starText;
	
	private float stars;
	private float difficultyLevel;	
	
	public enum Status {SUCCESS, FAILURE};
	
	
	void Start () {
		starText = GetComponent <Text>();
		difficultyLevel = PlayerPrefsManager.GetDifficulty();
		DifficultySliderValue();
		UpdateDisplay();
	}
	
	public void AddStars (float amount){
		stars += amount;	
		UpdateDisplay();
	}
	
	public Status UseStars(float amount){
		if(stars >= amount){
			stars -= amount;
			UpdateDisplay();
			return Status.SUCCESS;
		}
		return Status.FAILURE;
	}
	
	private void UpdateDisplay(){
		starText.text = stars.ToString();
	}	
	
	public void DifficultySliderValue(){
		if(difficultyLevel == 1f){
			stars = 120f;
		}
		if(difficultyLevel == 2f){
			stars = 100f;
		}
		if(difficultyLevel == 3f){
			stars = 70f;
		}
	}
}
