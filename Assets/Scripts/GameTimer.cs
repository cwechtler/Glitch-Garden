using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

	[SerializeField] private float levelSeconds;
	private Slider slider;
	private AudioSource audioSource;
	private bool isEndOfLevel = false;
	private LevelManager levelManager;
	private GameObject wonLable;
	private float difficultyLevel;

	void Start () {
		slider = GetComponent<Slider>();	
		audioSource = GetComponent<AudioSource>();
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		FindYouWon();
		wonLable.SetActive(false);	
		difficultyLevel = PlayerPrefsManager.GetDifficulty();
		DifficultySliderValue();
	}

	void FindYouWon (){
		wonLable = GameObject.Find ("Level Unlocked Text");
		if (!wonLable) {
			Debug.LogWarning ("Please create You Won Object");
		}
	}

	void Update () {
		slider.value = Time.timeSinceLevelLoad / levelSeconds;
		
		bool timeIsUp = (Time.timeSinceLevelLoad >= levelSeconds);
		if (timeIsUp && !isEndOfLevel){
			HandleWinCondition ();
		}
	}

	void HandleWinCondition(){
		DestroyAllTaggedObjects();
		audioSource.Play ();
		wonLable.SetActive (true);
		Invoke ("LoadNextLevel", audioSource.clip.length);
		isEndOfLevel = true;
	}
	
	void DestroyAllTaggedObjects(){
		GameObject[] taggedObjectArray = GameObject.FindGameObjectsWithTag("destroyOnWin");
		foreach (GameObject taggedObject in taggedObjectArray){
			Destroy (taggedObject);
		}
	}
	
	void LoadNextLevel(){
		levelManager.LoadNextLevel();
	}
	
	public void DifficultySliderValue(){
		if(difficultyLevel == 1f){
			levelSeconds = 100f;
		}
		if(difficultyLevel == 2f){
			levelSeconds = 120f;
		}
		if(difficultyLevel == 3f){
			levelSeconds = 140f;
		}
	}
}
