using UnityEngine;
using UnityEngine.UI;

public class StartMenuButton : MonoBehaviour {

	private LevelManager levelManager;
	private Image imageColor;
	
	void Start(){
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		imageColor = GetComponent<Image>();
	}
	
	void OnMouseDown(){
		imageColor.color = Color.grey;
		Invoke ("LoadStartMenu", 1f);
	}
		
	void LoadStartMenu(){
		levelManager.LoadLevel ("Start Menu");
	}
}
