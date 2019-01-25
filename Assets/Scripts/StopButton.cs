using UnityEngine;
using UnityEngine.UI;

public class StopButton : MonoBehaviour {

	[SerializeField] private Sprite play;
	[SerializeField] private Sprite pause;
	
	private Image newImage;
	
	void Start(){
		newImage = GetComponent<Image>();
	}
	
	void OnMouseDown(){
		if(Time.timeScale == 0.0f){
			Time.timeScale = 1;
			newImage.sprite = pause;
		}else{
			Time.timeScale = 0.0f;
			newImage.sprite = play;	
		}
	}
}
