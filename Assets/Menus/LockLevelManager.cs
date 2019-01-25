using UnityEngine;

public class LockLevelManager : MonoBehaviour {

	[SerializeField] private string[] levelTags;
	[SerializeField] private GameObject[] levelArray;
	[SerializeField] private GameObject[] levelLocks;
	[SerializeField] private bool[] levelUnlocked;

	
	void Start(){
		for(int i = 0; i < levelTags.Length; i++){
			if (PlayerPrefs.GetInt(levelTags[i]) == 0){
				levelUnlocked[i] = false;
			}
			else {
				levelUnlocked[i] = true;
			}
			if(levelUnlocked[i] == true){
				levelArray[i].SetActive (true);
				levelLocks[i].SetActive (false);
			}
			if(levelUnlocked[i] == false){
				levelArray[i].SetActive (false);
				levelLocks[i].SetActive (true);
			}
		}
	}
	
	public void ResetLockedLevels(){
		PlayerPrefs.DeleteKey("level2lock");
		PlayerPrefs.DeleteKey("level3lock");
		PlayerPrefs.DeleteKey("level4lock");
		PlayerPrefs.DeleteKey("level5lock");
		PlayerPrefs.DeleteKey("level6lock");
		PlayerPrefs.DeleteKey("level7lock");
		PlayerPrefs.DeleteKey("level8lock");
		PlayerPrefs.DeleteKey("level9lock");
		Start();
	}
}
