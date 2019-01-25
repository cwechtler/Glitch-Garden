using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	[SerializeField] private float autoLoadNextLevelAfter;
	[SerializeField] private string levelTag;
	
	void Start(){
		if(autoLoadNextLevelAfter <= 0){
			Debug.Log("Auto load disabled, use a postive number in seconds");
		}
		else{
		Invoke("LoadNextLevel", autoLoadNextLevelAfter);
		}
	}

	public void LoadLevel (string name){
		Debug.Log("Level load requested for: " + name);
		SceneManager.LoadScene(name);
		Reset();
	}
	
	public void QuitRequest () {
		Debug.Log("Level Quit Request");
		Application.Quit();
	}
	
	public void LoadNextLevel() {
		PlayerPrefs.SetInt (levelTag, 1);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
	
	void Reset(){
		ScoreKeeper.Reset();
	}
}
